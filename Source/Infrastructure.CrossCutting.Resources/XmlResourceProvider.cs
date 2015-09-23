using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Infrastructure.CrossCutting.Resources.Core;

namespace Infrastructure.CrossCutting.Resources
{
    public class XmlResourceProvider : BaseResourceProvider
    {
        private readonly string _filePath;

        public XmlResourceProvider() { }

        public XmlResourceProvider(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(filePath)) throw new FileNotFoundException(
                string.Format("XML Resource file {0} was not found", filePath)
            );
        }

        protected override IList<ResourceEntry> ReadResources()
        {
            var readerSettings = new XmlReaderSettings { IgnoreWhitespace = true };
            var listaResources = new List<ResourceEntry>();

            using (XmlReader reader = XmlReader.Create(_filePath, readerSettings))
            {
                reader.ReadStartElement("resources");
                while (reader.Name == "resource")
                {
                    var resource = (XElement)XNode.ReadFrom(reader);
                    listaResources.Add(new ResourceEntry
                    {
                        Codigo = resource.Attribute("name").Value,
                        Valor = resource.Attribute("value").Value,
                        Idioma = resource.Attribute("culture").Value
                    });
                }

                reader.ReadEndElement();
            }

            return listaResources;
        }

        protected override ResourceEntry ReadResource(string name, string culture)
        {
            var readerSettings = new XmlReaderSettings { IgnoreWhitespace = true };

            using (XmlReader reader = XmlReader.Create(_filePath, readerSettings))
            {
                reader.ReadStartElement("resources");
                while (reader.Name == "resource")
                {
                    var resource = (XElement)XNode.ReadFrom(reader);
                    if (resource.Attribute("name").Value == name && resource.Attribute("culture").Value == culture)
                        return new ResourceEntry
                        {
                            Codigo = resource.Attribute("name").Value,
                            Valor = resource.Attribute("value").Value,
                            Idioma = resource.Attribute("culture").Value
                        };
                }

                reader.ReadEndElement();
            }

            return default(ResourceEntry);
        }
    }
}