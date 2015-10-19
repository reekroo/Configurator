namespace Configurator.Views
{
    using Catel.Windows;
    using ViewModels;

    public partial class PackageView
    {
        public PackageView()
            : this(null) { }

        public PackageView(PackageViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
