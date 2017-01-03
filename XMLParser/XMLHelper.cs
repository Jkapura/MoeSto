using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace XMLParser
{
    public class XMLHelper
    {
        public XmlReaderSettings settings { get; set; }
        public XmlSchemaSet schemas { get; set; }

        public XMLHelper(string pathToFile)
        {
            settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            schemas = new XmlSchemaSet();
            schemas.Add(null, new XmlTextReader(pathToFile));
            settings.Schemas = schemas;

        }
        public void ValidateXml(Stream stream)
        {
            XmlReader reader = XmlReader.Create(stream, settings);
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            XPathNavigator navigator = document.CreateNavigator();
            ValidationEventHandler validation = new ValidationEventHandler(SchemaValidationHandler);
            navigator.MoveToChild("Company", null);
            //XmlWriter writer = navigator.InsertAfter();
            navigator.MoveToChild("Name", null);
            navigator.MoveToChild("Type", null);
            navigator.MoveToChild("Unp", null);
            navigator.MoveToChild("CatalogUrl", null);
            navigator.MoveToChild("Address", null);
            navigator.MoveToChild("Email", null);
            navigator.MoveToChild("Phones", null);
            navigator.MoveToChild("FoundOnCardone", null);
            navigator.MoveToChild("CardoneStatus", null);
            navigator.MoveToChild("CardoneContractNo", null);
            navigator.MoveToChild("CardoneContractStatus", null);
            navigator.MoveToChild("Coordinates", null);
            document.Validate(validation);
        }

        private void SchemaValidationHandler(object sender, ValidationEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
