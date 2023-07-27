using Triangles.ViewModels.Windows;
using Triangles.ViewModels.Windows.AboutWindow;

namespace Triangles.Views.Windows.AboutWindow
{
    public partial class AboutWindow : Form, IAboutWindow
    {
        public AboutWindow(IAboutWindowViewModel aboutWindowViewModel)
        {
            InitializeComponent();
            
            this.DataContext = aboutWindowViewModel;
        }


        //########################################################################################################
        #region IAboutWindow

        bool IWindow.Activate()
        {
            this.Activate();
            return Form.ActiveForm == this;
        }

        #endregion // IAboutWindow
    }
}
