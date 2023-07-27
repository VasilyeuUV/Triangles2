using Triangles.ViewModels.Windows;
using Triangles.ViewModels.Windows.MainWindow;
using Triangles.Views.Properties;

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

            // - меню
            this.menuItemFile.Text = strings.MenuItemFile;
            this.menuItemClose.Text = strings.MenuItemClose;
            this.menuItemAbout.Text = strings.MenuItemAbout;
            this.menuItemTechTask.Text = strings.MenuItemTechTask;

            this.menuItemClose.DataBindings.Add(
                nameof(this.menuItemClose.Command),
                this.DataContext,
                "MenuViewModel.CloseMainWindowCommand",
                true
                );
            this.menuItemTechTask.DataBindings.Add(
                nameof(this.menuItemClose.Command),
                this.DataContext,
                "MenuViewModel.OpenAboutWindowCommand",
                true
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
