using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Configurator.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class PackageViewModel : ViewModelBase
    {
        public PackageViewModel(ObservableCollection<string> packages, XElement document)
        {
            var parser = new Parser.Parser(document);

            Packages = new Dictionary<string, ObservableCollection<string>>();

            foreach (var package in packages)
            {
                Packages.Add(package, new ObservableCollection<string>(parser.ExtractPackageForms(package)));
            }
        }
        
        public override string Title { get { return "Packages"; } }

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
