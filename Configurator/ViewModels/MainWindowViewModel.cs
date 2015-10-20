using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

using Catel.MVVM;
using System.Threading.Tasks;

using Catel.Collections;
using Catel.IoC;
using Catel.Services;

using Configurator.Models;

using Parser.Entities;

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

        public ObservableCollection<Form> FormsCollection { get; set; }

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
                        var f = _parser.Extract();
                        
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

        //public Command SearchCommand
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {
        //            try
        //            {
        //                this.FormsCollection = this.ExecuteSearchedElements(this.Search);
        //            }
        //            catch (Exception ex)
        //            {
        //                _messageService.Show(ex.Message, "Error", MessageButton.YesNo, MessageImage.Warning);
        //            }
        //        });
        //    }
        //}
    }
}
