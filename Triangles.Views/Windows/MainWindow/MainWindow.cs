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

            this.DataContext = mainWindowViewModel;

            this.DataBindings.Add(
                nameof(this.Text),
                this.DataContext,
                "Title"
                );

            this.lblMessage.Text = string.Empty;

            // - меню
            this.menuItemFile.Text = strings.MenuItemFile;
            this.menuItemLoad.Text = strings.MenuItemLoad;
            this.menuItemClose.Text = strings.MenuItemClose;
            this.menuItemAbout.Text = strings.MenuItemAbout;
            this.menuItemTechTask.Text = strings.MenuItemTechTask;

            this.menuItemClose.DataBindings.Add(
                nameof(this.menuItemClose.Command),
                this.DataContext,
                "MenuViewModel.CloseMainWindowCommand",
                true
                );
            this.menuItemLoad.DataBindings.Add(
                nameof(this.menuItemLoad.Command),
                this.DataContext,
                "MenuViewModel.OpenFileCommand",
                true
                );
            this.menuItemTechTask.DataBindings.Add(
                nameof(this.menuItemTechTask.Command),
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
