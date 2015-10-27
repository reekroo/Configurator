using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

using Parser.Entities;
using Parser.Interfaces;

namespace Parser.Functionalities
{
    public class Remove : IRemove
    {
        public void RemoveFromPdfs(string xPath, XElement document, Element param)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes.Where(node => node.HasElements == false && node.HasAttributes && 
                                                     node.Attribute("Name") != null && node.Attribute("Name").Value == param.PdfName &&
                                                     node.Attribute("File") != null && node.Attribute("File").Value == param.PdfFilePath))
            {
                node.Remove();
            }
        }

        public void RemoveFromForms(string xPath, XElement document, Element param)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes.Where(node => node.HasElements == false && node.HasAttributes &&
                                                     node.Attribute("Name") != null && node.Attribute("Name").Value == param.FormName &&
                                                     node.Attribute("Pdf") != null && node.Attribute("Pdf").Value == param.PdfName))
            {
                node.Remove();
            }
        }

        public void RemoveFromPackages(string xPath, XElement document, Element param)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes.Where(node => node.Name == "Form" && node.Attribute("Name") != null && node.Attribute("Name").Value == param.FormName))
            {
                node.Remove();
            }
        }

        public void RemoveFromPackage(string xPath, XElement document, string package, string formName)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes.Where(node => node.HasAttributes && node.Attribute("Name") != null && node.Attribute("Name").Value == formName &&
                                                     node.Parent.Parent.Attribute("Name").Value == package))
            {
                node.Remove();
            }
        }
    }
}
