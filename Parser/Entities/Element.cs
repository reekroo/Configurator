using System.Collections.Generic;

namespace Parser.Entities
{
    public class Element : FormElement
    {
        public Element() 
        {
        }

        public Element(FormElement formElement)
            : base(formElement)
        {
        }

        public string PdfFilePath { get; set; }

        public IEnumerable<string> UsedPackages { get; set; }

        public IEnumerable<string> UnusedPackages { get; set; }
    }
}
