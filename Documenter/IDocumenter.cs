using System.Xml.Linq;

namespace Documenter
{
    public interface IDocumenter
    {
        XElement OpenDocument();

        void SaveDocument();

        //void SaveStep(XElement document);
    }
}
