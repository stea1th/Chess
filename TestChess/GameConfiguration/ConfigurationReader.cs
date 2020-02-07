using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestChess.GameConfiguration
{
    class ConfigurationReader
    {
        public string ConfigurationPath { get; }

        public ConfigurationReader() =>
            ConfigurationPath = Path.Combine(Environment.CurrentDirectory, @"GameConfiguration\", "Configuration.xml");

        public Configuration GetConfiguration() => ParseConfiguration(File.ReadAllText(ConfigurationPath));

        private Configuration ParseConfiguration(string path)
        {
            using var reader = XmlReader.Create(ToStream(path.Trim()), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return (Configuration)new XmlSerializer(typeof(Configuration)).Deserialize(reader);
        }

        private Stream ToStream(string @this) => new MemoryStream(Encoding.UTF8.GetBytes(@this ?? string.Empty));

    }
}
