using System.Xml.Linq;

namespace Parser.Helpers
{
    public static class DocumentHelper
    {
        private static string _path;

        public static XElement LoadDocument(string pathToFile)
        {
            if (string.IsNullOrEmpty(pathToFile))
            {
                //do something
            }

            _path = pathToFile;

            return XElement.Load(_path);
        }

        public static void SaveDocument(this XElement document)
        {
            if (document != null)
            {
                document.Save(_path);
            }
        }
    }
}
