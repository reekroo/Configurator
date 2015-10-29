using System.Xml.Linq;

namespace Documenter.Interfaces
{
    public interface IDocumenter
    {
        XElement OpenDocument();

        void SaveDocument();

        //void SaveStep(XElement document);
    }
}
