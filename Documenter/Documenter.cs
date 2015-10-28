using System.Xml.Linq;

namespace Documenter
{
    public class Documenter : IDocumenter
    {
        private readonly string _path;

        public XElement Document { get; set; }
        
        public Documenter(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                //do something
            }

            _path = path;
        }

        public XElement OpenDocument()
        {
            Document = XElement.Load(_path);

            return Document;
        }

        public void SaveDocument()
        {
            if (Document != null)
            {
                Document.Save(_path);
            }
        }
    }
}
