using System.Xml.Linq;

using Parser.Entities;

namespace Parser.Interfaces
{
    interface IReplace
    {
        void ReplaceInPdfs(string xPath, XElement document, Element previousParam, Element param);

        void ReplaceInForms(string xPath, XElement document, Element previousParam, Element param);

        void ReplaceInPackages(string xPath, XElement document, Element previousParam, Element param);
    }
}
