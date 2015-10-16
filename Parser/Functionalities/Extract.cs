using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

using Parser.Entities;
using Parser.Helpers;
using Parser.Interfaces;

namespace Parser.Functionalities
{
    public class Extract : IExtract
    {
        public IEnumerable<PdfElement> ExtractPdfs(string xPath, XElement document)
        {
            var nodes = document.XPathSelectElements(xPath);

            var result = new List<PdfElement>();

            foreach (var node in nodes.Where(node => node.HasElements == false && node.HasAttributes && node.Attribute("Name") != null &&
                                             string.IsNullOrEmpty(node.Attribute("Name").Value) == false && node.Attribute("File") != null &&
                                             string.IsNullOrEmpty(node.Attribute("File").Value) == false))
            {
                result.Add(new PdfElement
                {
                    PdfFilePath = node.Attribute("Pdf").Value,
                    PdfName = node.Attribute("Name").Value
                });
            }

            return result;
        }

        public IEnumerable<FormElement> ExtractForms(string xPath, XElement document)
        {
            var nodes = document.XPathSelectElements(xPath);

            var result = new List<FormElement>();

            foreach (var node in nodes.Where(node => node.HasElements == false && node.HasAttributes &&
                                             node.Attribute("Name") != null && string.IsNullOrEmpty(node.Attribute("Name").Value) == false &&
                                             node.Attribute("Pdf") != null && string.IsNullOrEmpty(node.Attribute("Pdf").Value) == false))
            {
                result.Add(AttributeHelper.AttributeValueFromFormNode(node));
            }

            return result;
        }
        
        public IEnumerable<string> ExtractPackages(string xPath, XElement document)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var atttribute in nodes.Where(node => node.HasAttributes).Attributes())
            {
                yield return atttribute.Value;
            }
        }

        public IEnumerable<string> ExtractUsedPackages(string xPath, XElement document, string formName)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes.Where(node => node.Name == "Form" && node.Attribute("Name") != null && node.Attribute("Name").Value == formName))
            {
                var package = node.Parent.Parent;

                if (package.Attribute("Name") != null)
                {
                    yield return package.Value;
                }
            }
        }

        public IEnumerable<string> ExtractUnusedPackages(string xPath, XElement document, string formName)
        {
            var used = ExtractUsedPackages(xPath, document, formName);
            var packages = ExtractPackages(xPath, document);

            var unused = packages.Intersect(used);

            return unused;
        }

        public IEnumerable<string> ExtractFormsFromPackage(string xPath, XElement document, string packageName)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes.Where(node => node.HasAttributes && node.Attribute("Name") != null && node.Attribute("Name").Value == packageName))
            {
                foreach (var child in node.Elements().Where(child => child.Name == "OutputForms"))
                {
                    foreach (var ch in child.Elements().Where(ch => ch.Name == "Form" && ch.Attribute("Name") != null))
                    {
                        yield return ch.Value;
                    }
                }
            }
        }
    }
}
