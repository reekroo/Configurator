namespace Configurator.Views
{
    using Catel.Windows;
    using ViewModels;

    public partial class FormView
    {
        public FormView()
            : this(null) { }

        public FormView(FormViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
