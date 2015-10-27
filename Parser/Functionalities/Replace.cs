using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

using Parser.Entities;
using Parser.Helpers;
using Parser.Interfaces;

namespace Parser.Functionalities
{
    public class Replace : IReplace
    {
        public void ReplaceInPdfs(string xPath, XElement document, Element previousParam, Element param)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes.Where(node => node.HasAttributes && node.Attribute("Name").Value == previousParam.PdfName && node.Attribute("File").Value == previousParam.PdfFilePath))
            {
                    node.Attribute("Name").Value = param.PdfName;
                    node.Attribute("File").Value = param.PdfFilePath;
            }
        }

        public void ReplaceInForms(string xPath, XElement document, Element previousParam, Element param)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes)
            {
                if (node.HasElements)
                {
                    continue;
                }

                if (!node.HasAttributes || node.Attribute("Name").Value != previousParam.FormName || node.Attribute("Pdf").Value != previousParam.PdfName)
                {
                    continue;
                }

                AttributeHelper.AttributeInNode("Name", previousParam.FormName, param.FormName, node);
                AttributeHelper.AttributeInNode("Pdf", previousParam.PdfName, param.PdfName, node);
                AttributeHelper.AttributeInNode("Doctype", previousParam.Doctype, param.Doctype, node);
                AttributeHelper.AttributeInNode("DataNamePrefix", previousParam.DataNamePrefix, param.DataNamePrefix, node);
                AttributeHelper.AttributeInNode("Docdesc", previousParam.Docdesc, param.Docdesc, node);
                AttributeHelper.AttributeInNode("MergeID", previousParam.MergeId, param.MergeId, node);
                AttributeHelper.AttributeInNode("Attachment", previousParam.Attachment, param.Attachment, node);
            }
        }
        
        public void ReplaceInPackages(string xPath, XElement document, Element previousParam, Element param)
        {
            if (previousParam.FormName != param.FormName)
            {
                foreach (var save in previousParam.UsedPackages.Where(previous => param.UsedPackages.Contains(previous)))
                {
                    ReplaceFormNameInPackage(xPath, document, save, previousParam.FormName, param.FormName);
                }
            }

            foreach (var del in previousParam.UsedPackages.Where(previous => param.UsedPackages.Contains(previous) == false))
            {
                new Remove().RemoveFromPackage(xPath, document, del, previousParam.FormName);
            }

            foreach (var add in param.UsedPackages.Where(package => previousParam.UsedPackages.Contains(package) == false))
            {
                new Add().AddToPackage(ConstPath.Packages, document, add, param.FormName);
            }
        }

        public void ReplaceFormNameInPackage(string xPath, XElement document, string package, string prevFormName, string formName)
        {
            var nodes = document.XPathSelectElements(xPath);

            foreach (var node in nodes.Where(node => node.Name == "Form" && node.Parent.Parent.Attribute("Name").Value == package &&
                                                     node.Attribute("Name") != null && node.Attribute("Name").Value == prevFormName))
            {
                node.Attribute("Name").Value = formName;
            }
        }
        
        public void ReplacePackageForms(string xPath, XElement document, string package, IEnumerable<string> newFormName)
        {
            var nodes = document.XPathSelectElements(xPath);
            var names = newFormName.ToList();

            foreach (var node in nodes.Where(node => node.Name == "Form" && node.Parent.Parent.Attribute("Name").Value == package))
            {
                if (node.HasAttributes && node.Attribute("Name") != null && node.Attribute("Name").Value != names.First())
                {
                    node.Attribute("Name").Value = names.First();
                }
                names.Remove(names.First());
            }
        }
    }
}
