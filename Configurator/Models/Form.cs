using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Catel.Data;

namespace Configurator.Models
{
    public class Form : ModelBase, ICloneable
    {
        public string FormName
        {
            get { return GetValue<string>(FormNameProperty); }
            set { SetValue(FormNameProperty, value); }
        }
        public static readonly PropertyData FormNameProperty = RegisterProperty("FormName", typeof(string));

        public string PdfName
        {
            get { return GetValue<string>(PdfNameProperty); }
            set { SetValue(PdfNameProperty, value); }
        }
        public static readonly PropertyData PdfNameProperty = RegisterProperty("PdfName", typeof(string));

        public string Doctype
        {
            get { return GetValue<string>(DoctypeProperty); }
            set { SetValue(DoctypeProperty, value); }
        }
        public static readonly PropertyData DoctypeProperty = RegisterProperty("Doctype", typeof(string));

        public string DataNamePrefix
        {
            get { return GetValue<string>(DataNamePrefixProperty); }
            set { SetValue(DataNamePrefixProperty, value); }
        }
        public static readonly PropertyData DataNamePrefixProperty = RegisterProperty("DataNamePrefix", typeof(string));

        public string Docdesc
        {
            get { return GetValue<string>(DocdescProperty); }
            set { SetValue(DocdescProperty, value); }
        }
        public static readonly PropertyData DocdescProperty = RegisterProperty("Docdesc", typeof(string));

        public string MergeId
        {
            get { return GetValue<string>(MergeIdProperty); }
            set { SetValue(MergeIdProperty, value); }
        }
        public static readonly PropertyData MergeIdProperty = RegisterProperty("MergeId", typeof(string));

        public string Attachment
        {
            get { return GetValue<string>(AttachmentProperty); }
            set { SetValue(AttachmentProperty, value); }
        }
        public static readonly PropertyData AttachmentProperty = RegisterProperty("Attachment", typeof(string));

        public string PdfFilePath
        {
            get { return GetValue<string>(PdfFilePathProperty); }
            set { SetValue(PdfFilePathProperty, value); }
        }
        public static readonly PropertyData PdfFilePathProperty = RegisterProperty("PdfFilePath", typeof(string));

        public ObservableCollection<string> UsedPackages
        {
            get { return GetValue<ObservableCollection<string>>(UsedPackagesProperty); }
            set { SetValue(UsedPackagesProperty, value); }
        }
        public static readonly PropertyData UsedPackagesProperty = RegisterProperty("UsedPackages", typeof(ObservableCollection<string>), new ObservableCollection<string>());

        public ObservableCollection<string> UnusedPackages
        {
            get { return GetValue<ObservableCollection<string>>(UnusedPackagesProperty); }
            set { SetValue(UnusedPackagesProperty, value); }
        }
        public static readonly PropertyData UnusedPackagesProperty = RegisterProperty("UnusedPackages", typeof(ObservableCollection<string>), new ObservableCollection<string>());

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(FormName))
            {
                validationResults.Add(FieldValidationResult.CreateError(FormNameProperty, "the variable 'Form Name' cannot be empty"));
            }

            if (string.IsNullOrEmpty(PdfName))
            {
                validationResults.Add(FieldValidationResult.CreateError(PdfNameProperty, "the variable 'Pdf Name' cannot be empty"));
            }

            if (string.IsNullOrEmpty(PdfFilePath))
            {
                validationResults.Add(FieldValidationResult.CreateError(PdfFilePathProperty, "the variable 'Pdf File Path' cannot be empty"));
            }

            if (UsedPackages != null && UsedPackages.Count <= 0)
            {
                validationResults.Add(FieldValidationResult.CreateError(UsedPackagesProperty, "the variable 'Packages' cannot be empty"));
            }
        }

        public object Clone()
        {
            return new Form
            {
                UnusedPackages = new ObservableCollection<string>(UnusedPackages),
                UsedPackages = new ObservableCollection<string>(UsedPackages),
                Attachment = Attachment,
                DataNamePrefix = DataNamePrefix,
                Docdesc = Docdesc,
                Doctype = Doctype,
                FormName = FormName,
                PdfName = PdfName,
                PdfFilePath = PdfFilePath,
                MergeId = MergeId
            };
        }
    }
}
