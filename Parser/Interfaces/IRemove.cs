using System.Xml.Linq;

using Parser.Entities;

namespace Parser.Interfaces
{
    interface IRemove
    {
        void RemoveFromPackages(string xPath, XElement document, Element param);

        void RemoveFromForms(string xPath, XElement document, Element param);

        void RemoveFromPdfs(string xPath, XElement document, Element param);
    }
}
