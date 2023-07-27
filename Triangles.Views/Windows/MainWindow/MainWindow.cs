using Triangles.ViewModels.Windows;
using Triangles.ViewModels.Windows.MainWindow;

namespace Triangles.Views.Windows.MainWindow
{
    public partial class MainWindow : Form, IMainWindow
    {
        public MainWindow(IMainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();

            // Переданная вьюмодель является контекстом данных для окна.
            DataContext = mainWindowViewModel;

            this.DataBindings.Add(
                nameof(this.Text),
                this.DataContext,
                "Title"
                );
        }



        //########################################################################################################
        #region // IMainWindow

        bool IWindow.Activate()
        {
            this.Activate();
            return Form.ActiveForm == this;
        }

        #endregion // IMainWindow
    }
}
