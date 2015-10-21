using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Configurator.Models;

using Parser.Entities;

namespace Configurator.Services
{
    public static class ConvertorService
    {
        public static ObservableCollection<Form> ElementsToForms(this IEnumerable<Element> elements)
        {
            return new ObservableCollection<Form>(elements.Select(element => new Form
            {
                FormName = element.FormName,
                PdfName = element.PdfName,
                Doctype = element.Doctype,
                DataNamePrefix = element.DataNamePrefix,
                Docdesc = element.Docdesc,
                MergeId = element.MergeId,
                Attachment = element.Attachment,
                PdfFilePath = element.PdfFilePath,
                UsedPackages = new ObservableCollection<string>(element.UsedPackages),
                UnusedPackages = new ObservableCollection<string>(element.UnusedPackages)
            }));
        }
    }
}
