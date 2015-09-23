using System.Collections.Generic;
using SAP.Middleware.Connector;

namespace Infrastructure.Data.Core.Repository.Sap
{
    public class InMemoryDestinationConfiguration : IDestinationConfiguration
    {
        private readonly Dictionary<string, RfcConfigParameters> _availableDestinations;

        public InMemoryDestinationConfiguration()
        {
            _availableDestinations = new Dictionary<string, RfcConfigParameters>();
        }

        public RfcConfigParameters GetParameters(string destinationName)
        {
            RfcConfigParameters foundDestination = null;
            _availableDestinations.TryGetValue(destinationName, out foundDestination);
            return foundDestination;
        }

        public bool ChangeEventsSupported()
        {
            return true;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public void AddOrEditDestination(RfcConfigParameters parameters)
        {
            string name = parameters[RfcConfigParameters.Name];

            if (_availableDestinations.ContainsKey(name))
            {
                RfcConfigurationEventArgs eventArgs = new RfcConfigurationEventArgs(RfcConfigParameters.EventType.CHANGED, parameters);

                if (ConfigurationChanged != null)
                {
                    ConfigurationChanged(name, eventArgs);
                }
            }

            _availableDestinations[name] = parameters;
            string tmp = "Application server";
            bool isLoadValancing = parameters.TryGetValue(RfcConfigParameters.LogonGroup, out tmp);
            if (isLoadValancing)
            {
                tmp = "Load balancing";
            }
        }

        public void RemoveDestination(string name)
        {
            if (_availableDestinations.Remove(name))
            {
                if (ConfigurationChanged != null)
                {
                    ConfigurationChanged(name, new RfcConfigurationEventArgs(RfcConfigParameters.EventType.DELETED));
                }
            }
        }
    }
}