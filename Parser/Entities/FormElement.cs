namespace Parser.Entities
{
    public class FormElement
    {
        public FormElement()
        {
        }

        public FormElement(Element element)
        {
            FormName = element.FormName;
            PdfName = element.PdfName;
            Doctype = element.Doctype;
            DataNamePrefix = element.DataNamePrefix;
            Docdesc = element.Doctype;
            MergeId = element.MergeId;
            Attachment = element.Attachment;
        }

        public string FormName { get; set; }

        public string PdfName { get; set; }

        public string Doctype { get; set; }

        public string DataNamePrefix { get; set; }

        public string Docdesc { get; set; }

        public string MergeId { get; set; }

        public string Attachment { get; set; }
    }
}
