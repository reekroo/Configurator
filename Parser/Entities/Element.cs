using System.Collections.Generic;

namespace Parser.Entities
{
    public class Element : FormElement
    {
        public string PdfFilePath { get; set; }

        public IList<string> UsedPackages { get; set; }

        public IList<string> UnusedPackages { get; set; }
    }
}
