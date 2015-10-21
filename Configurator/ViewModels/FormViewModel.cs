using System.Collections.ObjectModel;
using System.Windows.Input;

using Catel.Data;

using Configurator.Models;

namespace Configurator.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class FormViewModel : ViewModelBase
    {
        public FormViewModel()
        {
        }
        
        public FormViewModel(Form form = null)
        {
            FormObject = form ?? new Form();
        }

        public FormViewModel(ObservableCollection<string> packges, Form form = null)
        {
            FormObject = form ?? new Form
                                     {
                                         UnusedPackages = new ObservableCollection<string>(packges)
                                     };
        }
        
        public override string Title { get { return "View model title"; } }


        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
        }

        protected override async Task CloseAsync()
        {
            await base.CloseAsync();
        }
        

        public string SelectedUsedPackage { get; set; }

        public string SelectedUnusedPackage { get; set; }
        

        [Model]
        public Form FormObject
        {
            get { return GetValue<Form>(FormObjectProperty); }
            set { SetValue(FormObjectProperty, value); }
        }
        public static readonly PropertyData FormObjectProperty = RegisterProperty("FormObject", typeof(Form));

        [ViewModelToModel("FormObject", "FormName")]
        public string FormName
        {
            get { return GetValue<string>(FormNameProperty); }
            set { SetValue(FormNameProperty, value); }
        }
        public static readonly PropertyData FormNameProperty = RegisterProperty("FormName", typeof(string));

        [ViewModelToModel("FormObject", "PdfName")]
        public string PdfName
        {
            get { return GetValue<string>(PdfNameProperty); }
            set { SetValue(PdfNameProperty, value); }
        }
        public static readonly PropertyData PdfNameProperty = RegisterProperty("PdfName", typeof(string));

        [ViewModelToModel("FormObject", "Doctype")]
        public string Doctype
        {
            get { return GetValue<string>(DoctypeProperty); }
            set { SetValue(DoctypeProperty, value); }
        }
        public static readonly PropertyData DoctypeProperty = RegisterProperty("Doctype", typeof(string));

        [ViewModelToModel("FormObject", "DataNamePrefix")]
        public string DataNamePrefix
        {
            get { return GetValue<string>(DataNamePrefixProperty); }
            set { SetValue(DataNamePrefixProperty, value); }
        }
        public static readonly PropertyData DataNamePrefixProperty = RegisterProperty("DataNamePrefix", typeof(string));

        [ViewModelToModel("FormObject", "Docdesc")]
        public string Docdesc
        {
            get { return GetValue<string>(DocdescProperty); }
            set { SetValue(DocdescProperty, value); }
        }
        public static readonly PropertyData DocdescProperty = RegisterProperty("Docdesc", typeof(string));

        [ViewModelToModel("FormObject", "MergeId")]
        public string MergeId
        {
            get { return GetValue<string>(MergeIdProperty); }
            set { SetValue(MergeIdProperty, value); }
        }
        public static readonly PropertyData MergeIdProperty = RegisterProperty("MergeId", typeof(string));

        [ViewModelToModel("FormObject", "Attachment")]
        public string Attachment
        {
            get { return GetValue<string>(AttachmentProperty); }
            set { SetValue(AttachmentProperty, value); }
        }
        public static readonly PropertyData AttachmentProperty = RegisterProperty("Attachment", typeof(string));

        [ViewModelToModel("FormObject", "PdfFilePath")]
        public string PdfFilePath
        {
            get { return GetValue<string>(PdfFilePathProperty); }
            set { SetValue(PdfFilePathProperty, value); }
        }
        public static readonly PropertyData PdfFilePathProperty = RegisterProperty("PdfFilePath", typeof(string));

        [ViewModelToModel("FormObject", "UsedPackages")]
        public ObservableCollection<string> UsedPackages
        {
            get { return GetValue<ObservableCollection<string>>(UsedPackagesProperty); }
            set { SetValue(UsedPackagesProperty, value); }
        }
        public static readonly PropertyData UsedPackagesProperty = RegisterProperty("UsedPackages", typeof(ObservableCollection<string>));

        [ViewModelToModel("FormObject", "UnusedPackages")]
        public ObservableCollection<string> UnusedPackages
        {
            get { return GetValue<ObservableCollection<string>>(UnusedPackagesProperty); }
            set { SetValue(UnusedPackagesProperty, value); }
        }
        public static readonly PropertyData UnusedPackagesProperty = RegisterProperty("UnusedPackages", typeof(ObservableCollection<string>));

        
        public Command<MouseEventArgs> Edit
        {
            get
            {
                return new Command<MouseEventArgs>(OnEditExecute, OnEditCanExecute);
            }
        }

        private bool OnEditCanExecute(MouseEventArgs e)
        {
            return true;
        }

        private void OnEditExecute(MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedUsedPackage) == false)
            {
                UnusedPackages.Add(SelectedUsedPackage);
                UsedPackages.Remove(SelectedUsedPackage);
            }

            if (string.IsNullOrEmpty(SelectedUnusedPackage) == false)
            {
                UsedPackages.Add(SelectedUnusedPackage);
                UnusedPackages.Remove(SelectedUnusedPackage);
            }
        }
    }
}
