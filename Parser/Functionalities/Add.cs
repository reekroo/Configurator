using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

using Parser.Entities;
using Parser.Helpers;
using Parser.Interfaces;

namespace Parser.Functionalities
{
    public class Add : IAdd
    {
        public void AddToPackages(string xPath, XElement document, Element element)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var package in element.UsedPackages)
            {
                foreach (var node in nodes.Where(node => node.HasAttributes && node.HasAttributes && node.Attribute("Name") != null && node.Attribute("Name").Value == package))
                {
                    foreach (var child in node.Elements())
                    {
                        if (child.Name != "OutputForms")
                        {
                            continue;
                        }

                        var newNode = new XElement("Form");
                        newNode.SetAttributeValue("Name", element.FormName);
                        child.Add(newNode);
                    }
                }
            }
        }

        public void AddToForms(string xPath, XElement document, Element element)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes)
            {
                node.Add(AttributeHelper.AddNodeToForm(element));
            }
        }

        public void AddToPdfs(string xPath, XElement document, Element element)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes)
            {
                var newNode = new XElement("Pdf");
                newNode.SetAttributeValue("Name", element.PdfName);
                newNode.SetAttributeValue("File", element.PdfFilePath);

                node.Add(newNode);
            }
        }

        public void AddToPackage(string xPath, XElement document, string package, string formName)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes)
            {
                if (node.HasAttributes || node.Attribute("Name") == null ||node.Attribute("Name").Value != package)
                {
                    continue;
                }

                foreach (var child in node.Elements())
                {
                    if (child.Name != "OutputForms")
                    {
                        continue;
                    }

                    var newNode = new XElement("Form");
                    newNode.SetAttributeValue("Name", formName);
                    //node.Parent.AddAfterSelf(newNode);

                    child.Add(newNode);
                }
            }
        }
    }
}
