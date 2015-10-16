using System.Collections.Generic;

using Parser.Entities;

namespace Parser.Interfaces
{
    interface IParser
    {
        IEnumerable<Element> Extract();

        bool Add(Element param);

        bool Remove(Element param);

        bool Edit(Element oldParam, Element newParam);
    }
}
