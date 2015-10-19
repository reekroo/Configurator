namespace Configurator.Views
{
    using Catel.Windows;
    using ViewModels;

    public partial class Form
    {
        public Form()
            : this(null) { }

        public Form(FormModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
