using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Catel.MVVM;
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

        public Form SelectedForm
        {
            get { return GetValue<Form>(SelectedFormProperty); }
            set { SetValue(SelectedFormProperty, value); }
        }
        public static readonly PropertyData SelectedFormProperty = RegisterProperty("SelectedForm", typeof(Form));
        
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
                        _messageService.ShowAsync(ex.Message, "Error", MessageButton.OK, MessageImage.Error);
                    }
                    finally
                    {
                        _pleaseWaitService.Hide();
                    }
                });
            }
        }

        private Command _saveFileCommand;
        public Command SaveFileCommand
        {
            get
            {
                return _saveFileCommand ?? (_saveFileCommand = new Command(() =>
                {

                },
                () => string.IsNullOrEmpty(ConfigFilePath) == false));
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
                        _messageService.ShowAsync(ex.Message, "Error", MessageButton.OK, MessageImage.Error);
                    }
                });
            }
        }

        private Command _addCommand;
        public Command AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new Command(() =>
                {
                    var viewModel = new FormViewModel(Packages);

                    _uiVisualizerService.ShowDialog(viewModel, (sender, e) =>
                    {
                        if (!(e.Result ?? false))
                        {
                            return;
                        }

                        _pleaseWaitService.Show("Waiting...");

                        var succeed = _parser.Add(viewModel.FormObject.FormToElement());

                        if (succeed)
                        {
                            FormsCollection.Add(viewModel.FormObject);
                            _pleaseWaitService.UpdateStatus("...succeed");
                        }
                        else
                        {
                            _pleaseWaitService.UpdateStatus("...fail");
                        }
                        Thread.Sleep(1000);

                        _pleaseWaitService.Hide();
                    });
                },
                () => string.IsNullOrEmpty(ConfigFilePath) == false));
            }
        }
        
        private Command _editCommand;
        public Command EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new Command(() =>
                {
                    var copyForm = SelectedForm.Clone() as Form;
                    var viewModel = new FormViewModel(SelectedForm);

                    _uiVisualizerService.ShowDialog(viewModel, (sender, e) =>
                    {
                        if (!(e.Result ?? false))
                        {
                            return;
                        }
                        _pleaseWaitService.Show("Waiting...");

                        var succeed = _parser.Edit(copyForm.FormToElement(), viewModel.FormObject.FormToElement());

                        if (succeed)
                        {
                            _pleaseWaitService.UpdateStatus("...succeed");
                        }
                        else
                        {
                            _pleaseWaitService.UpdateStatus("...fail");
                        }
                        Thread.Sleep(1000);

                        _pleaseWaitService.Hide();
                    });
                },
                () => SelectedForm != null));
            }
        }
        
        private Command _removeCommand;
        public Command RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new Command(async () =>
                {
                    if (await _messageService.ShowAsync("Are you realy want to remove it?", "Attention!", MessageButton.YesNo, MessageImage.Warning) != MessageResult.Yes)
                    {
                        return;
                    }

                    _pleaseWaitService.Show("Waiting...");

                    var succeed = _parser.Remove(SelectedForm.FormToElement());

                    FormsCollection.Remove(SelectedForm);

                    if (succeed)
                    {
                        FormsCollection.Remove(SelectedForm);
                        _pleaseWaitService.UpdateStatus("...succeed");
                    }
                    else
                    {
                        _pleaseWaitService.UpdateStatus("...fail");
                    }
                    Thread.Sleep(1000);

                    _pleaseWaitService.Hide();
                },
                () => SelectedForm != null));
            }
        }

        private Command _formatFormsCommand;
        public Command FormatFormsCommand
        {
            get
            {
                return _formatFormsCommand ?? (_formatFormsCommand = new Command(() =>
                {
                    try
                    {
                        var viewModel = new PackageViewModel(Packages, ConfigFilePath);

                        _uiVisualizerService.ShowDialog(viewModel, (sender, e) =>
                        {
                            if (!(e.Result ?? false))
                            {
                                return;
                            }

                            FormatElementsInPackages(viewModel.Packages);
                        });
                    }
                    catch (Exception ex)
                    {
                        _messageService.ShowAsync(ex.Message, "Error", MessageButton.OK, MessageImage.Error);
                    }
                },
                () => string.IsNullOrEmpty(ConfigFilePath) == false));
            }
        }


        private void FormatElementsInPackages(Dictionary<string, ObservableCollection<string>> packages)
        {
            foreach (var package in packages.Keys)
            {
                _parser.EditPackageForms(package, packages[package]);
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