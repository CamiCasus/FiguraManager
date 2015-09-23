using System.Configuration;

namespace Infrastructure.Data.Core.Repository.Sap
{
    public class SapConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("ConfigurationValues")]
        public SapConfiguration Configuration
        {
            get { return (SapConfiguration)this["ConfigurationValues"]; }
        }
    }

    public class SapConfiguration : ConfigurationElement
    {
        [ConfigurationProperty("Host", IsRequired = true)]
        public string Host
        {
            get { return (string) this["Host"]; }
        }

        [ConfigurationProperty("User", IsRequired = true)]
        public string User
        {
            get { return (string)this["User"]; }
        }

        [ConfigurationProperty("Password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["Password"]; }
        }

        [ConfigurationProperty("SystemNumber", IsRequired = true)]
        public string SystemNumber
        {
            get { return (string)this["SystemNumber"]; }
        }

        [ConfigurationProperty("Client", IsRequired = true)]
        public string Client
        {
            get { return (string)this["Client"]; }
        }

        [ConfigurationProperty("SystemId", IsRequired = true)]
        public string SystemId
        {
            get { return (string)this["SystemId"]; }
        }

        [ConfigurationProperty("Ambiente", IsRequired = false)]
        public string Ambiente
        {
            get { return (string)this["Ambiente"]; }
        }

        [ConfigurationProperty("Language", IsRequired = false)]
        public string Language
        {
            get { return (string)this["Language"]; }
        }

        [ConfigurationProperty("SapRouter", IsRequired = false)]
        public string SapRouter
        {
            get { return (string)this["SapRouter"]; }
        }

    }
}