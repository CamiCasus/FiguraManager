using SAP.Middleware.Connector;

namespace Infrastructure.Data.Core.Repository.Sap
{
    public class DestinationConfig
    {
        #region Variables

        public const string PoolSize = "5";
        public const string MaxPoolSize = "10";
        public const string TimeOut = "50000";

        #endregion Variables

        #region Propiedades

        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public string SystemNumber { get; set; }
        public string Client { get; set; }
        public string SystemId { get; set; }
        public string SapRouter { get; set; }

        #endregion Propiedades

        #region Metodos

        public RfcConfigParameters GetParameters(string destinationName)
        {
            var parametros = new RfcConfigParameters
            {
                {RfcConfigParameters.AppServerHost, Host},
                {RfcConfigParameters.User, User},
                {RfcConfigParameters.Password, Password},
                {RfcConfigParameters.Name, destinationName}
            };

            if (!string.IsNullOrEmpty(Language))
                parametros.Add(RfcConfigParameters.Language, Language);
            if (!string.IsNullOrEmpty(Client))
                parametros.Add(RfcConfigParameters.Client, Client);
            if (!string.IsNullOrEmpty(SystemNumber))
                parametros.Add(RfcConfigParameters.SystemNumber, SystemNumber);
            if (!string.IsNullOrEmpty(SystemId))
                parametros.Add(RfcConfigParameters.SystemID, SystemId);
            if (!string.IsNullOrEmpty(SapRouter))
                parametros.Add(RfcConfigParameters.SAPRouter, SapRouter);
            if (!string.IsNullOrEmpty(TimeOut))
                parametros.Add(RfcConfigParameters.IdleTimeout, TimeOut);
            if (!string.IsNullOrEmpty(PoolSize))
                parametros.Add(RfcConfigParameters.PoolSize, PoolSize);
            if (!string.IsNullOrEmpty(MaxPoolSize))
                parametros.Add(RfcConfigParameters.MaxPoolSize, MaxPoolSize);

            return parametros;
        }

        #endregion Metodos
    }
}