using System.Collections.Generic;
using System.Xml.Linq;

using Parser.Entities;

namespace Parser.Interfaces
{
    interface IExtract
    {
        IEnumerable<PdfElement> ExtractPdfs(string xPath, XElement document);

        IEnumerable<FormElement> ExtractForms(string xPath, XElement document);

        IEnumerable<string> ExtractPackages(string xPath, XElement document);
    }
}
