using System.Collections.Generic;
using System.Xml.Linq;

using Parser.Entities;

namespace Parser.Interfaces
{
    interface IParser
    {
        IEnumerable<Element> Extract();

        XElement Add(Element param);

        XElement Remove(Element param);

        XElement Edit(Element oldParam, Element newParam);
    }
}
