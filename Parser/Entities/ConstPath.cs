namespace Parser.Entities
{
    public static class ConstPath
    {
        public const string Packages = @"//Output/Packages/Package[@Name]";

        public const string Pdfs = @"//Pdfs/Pdf[@Name][@File]";

        public const string FormsInPackages = @"//Output/Packages/Package[@Name]/OutputForms/Form[@Name]";

        public const string Forms = @"//Forms//Form[@Name][@Pdf]";

        public const string Form = @"//Forms";

        public const string Pdf = @"//Pdfs";
    }
}
