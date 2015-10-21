using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

using Catel.MVVM;
using System.Threading.Tasks;

using Catel.Data;
using Catel.IoC;
using Catel.Services;

using Configurator.Models;
using Configurator.Services;


namespace Configurator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly IMessageService _messageService;
        private readonly IDependencyResolver _dependencyResolver;

        private Parser.Parser _parser;

        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IPleaseWaitService pleaseWaitService, 
                                   IMessageService messageService, IDependencyResolver dependencyResolver)
        {
            _uiVisualizerService = uiVisualizerService;
            _pleaseWaitService = pleaseWaitService;
            _messageService = messageService;
            _dependencyResolver = dependencyResolver;
        }

        public override string Title { get { return "Configurator"; } }

        public ObservableCollection<string> Packages { get; set; }

        private string ConfigFilePath { get; set; }

        public string Search { get; set; }

        public ObservableCollection<Form> FormsCollection
        {
            get { return GetValue<ObservableCollection<Form>>(FormsCollectionProperty); }
            set { SetValue(FormsCollectionProperty, value); }
        }
        public static readonly PropertyData FormsCollectionProperty = RegisterProperty("FormsCollection", typeof(ObservableCollection<Form>));
        
        public ObservableCollection<Form> DoublicateCollection = new ObservableCollection<Form>();
        
        
        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
        }

        protected override async Task CloseAsync()
        {
            await base.CloseAsync();
        }


        public Command OpenFileCommand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        var openFileService = _dependencyResolver.Resolve<IOpenFileService>();
                        openFileService.Filter = "config file (.config)|*.config";

                        if (!openFileService.DetermineFile())
                        {
                            return;
                        }

                        _pleaseWaitService.Show("Waiting...");

                        ConfigFilePath = openFileService.FileName;

                        _parser = new Parser.Parser(ConfigFilePath);

                        Packages = new ObservableCollection<string>(_parser.ExtractPackages());
                        FormsCollection = _parser.Extract().ElementsToForms();
                        DoublicateCollection = FormsCollection;

                        //Backuper.BackupConfig(this.ConfigFilePath);

                        _pleaseWaitService.UpdateStatus("...succeed");
                        Thread.Sleep(1000);

                        _pleaseWaitService.Hide();
                    }
                    catch (Exception ex)
                    {
                        _messageService.ShowAsync(ex.Message, "Error", MessageButton.OK, MessageImage.Warning);
                    }
                });
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        FormsCollection = ExecuteSearchedElements(Search);
                    }
                    catch (Exception ex)
                    {
                        _messageService.ShowAsync(ex.Message, "Error", MessageButton.OK, MessageImage.Warning);
                    }
                });
            }
        }


        private ObservableCollection<Form> ExecuteSearchedElements(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return DoublicateCollection;
            }

            search = search.ToUpper().Trim();
            var q = DoublicateCollection.Where(form => (string.IsNullOrEmpty(form.FormName) == false && form.FormName.ToUpper().Contains(search)) ||
                                                        (string.IsNullOrEmpty(form.PdfName) == false && form.PdfName.ToUpper().Contains(search)) ||
                                                        (string.IsNullOrEmpty(form.Doctype) == false && form.Doctype.ToUpper().Contains(search)));
            var results = new ObservableCollection<Form>(q);
            return results;
        }

    }
}
