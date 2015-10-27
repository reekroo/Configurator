using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Configurator.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class PackageViewModel : ViewModelBase
    {
        public PackageViewModel(ObservableCollection<string> packages, string path)
        {
            var parser = new Parser.Parser(path);

            Packages = new Dictionary<string, ObservableCollection<string>>();

            foreach (var package in packages)
            {
                Packages.Add(package, new ObservableCollection<string>(parser.ExtractPackageForms(package)));
            }
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

        public Dictionary<string, ObservableCollection<string>> Packages { get; set; }
    }
}
