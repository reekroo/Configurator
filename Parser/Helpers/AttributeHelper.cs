using System.Xml.Linq;

using Parser.Entities;

namespace Parser.Helpers
{
    public static class AttributeHelper
    {
        public static XElement AddNodeToForm(Element param)
        {
            var node = new XElement("Form");

            var formElement = new FormElement(param);
            var properties = formElement.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(formElement, null);

                if (value != null && string.IsNullOrEmpty(value.ToString()))
                {
                    AddAttributeInNode(property.Name, value.ToString(), node);
                }
            }
            
            return node;
        }

        public static FormElement AttributeValueFromFormNode(XElement node)
        {
            var formElement = new FormElement();
            var properties = formElement.GetType().GetProperties();
            
            foreach (var property in properties)
            {
                var value = ExtractAttributeValueFromNode(property.Name, node);
                property.SetValue(formElement, value, null);
            }

            return formElement;
        }

        public static void AttributeInNode(string attribute, string oldValue, string newValue, XElement node)
        {
            //string.IsNullOrEmpty
            if (oldValue == newValue)
            {
                return;
            }

            if (oldValue == null && newValue != null)
            {
                AddAttributeInNode(attribute, newValue, node);
            }

            if (newValue == null && oldValue != null)
            {
                RemoveAttributeFromNode(attribute, node);
            }

            if (oldValue != null && newValue != null && oldValue != newValue)
            {
                ReplaceAttributeFromNode(attribute, newValue, node);
            }
        }

        private static void AddAttributeInNode(string attributeName, string attributeValue, XElement node)
        {
            if (node.Attribute(attributeName) == null)
            {
                node.SetAttributeValue(attributeName, attributeValue);
            }
        }

        private static void RemoveAttributeFromNode(string attributeName, XElement node)
        {
            var n = node.Attribute(attributeName);

            if (n != null)
            {
                n.Remove();
            }
        }

        private static void ReplaceAttributeFromNode(string attributeName, string attributeValue, XElement node)
        {
            var n = node.Attribute(attributeName);

            if (n != null)
            {
                n.Value = attributeValue;
            }
        }

        private static string ExtractAttributeValueFromNode(string attributeName, XElement node)
        {
            if (attributeName == "FormName")
            {
                attributeName = "Name";
            }

            if (attributeName == "PdfName")
            {
                attributeName = "Pdf";
            }

            var n = node.Attribute(attributeName);
            return n != null ? n.Value : null;
        }
    }
}
