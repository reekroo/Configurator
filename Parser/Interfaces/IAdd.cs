using System.Xml.Linq;

using Parser.Entities;

namespace Parser.Interfaces
{
    interface IAdd
    {
        void AddToPdfs(string xPath, XElement document, Element element);

        void AddToForms(string xPath, XElement document, Element element);

        void AddToPackages(string xPath, XElement document, Element element);
    }
}
