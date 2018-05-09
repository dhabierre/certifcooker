namespace CertifCooker.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    internal class ConfigurationManager
    {
        private static readonly string ConfigFile = @"Data\Configuration.xml";

        public static string ConfigFilePath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFile);
            }
        }

        public static ConfigurationAutoFill GetAutoFill()
        {
            return GetConfiguration().AutoFill;
        }

        public static ConfigurationCertificate GetCertificate(string name)
        {
            return GetConfiguration().Certificates.FirstOrDefault(i => i.Name == name);
        }

        public static IEnumerable<ConfigurationCertificate> GetCertificates()
        {
            return GetConfiguration().Certificates;
        }

        private static Configuration GetConfiguration()
        {
            var serializer = new XmlSerializer(typeof(Configuration));

            using (var reader = new StreamReader(ConfigFilePath))
            {
                return (Configuration)serializer.Deserialize(reader);
            }
        }
    }
}