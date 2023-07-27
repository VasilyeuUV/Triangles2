using Microsoft.Web.WebView2.Core;
using Triangles.ViewModels.Windows;
using Triangles.ViewModels.Windows.AboutWindow;

namespace Triangles.Views.Windows.AboutWindow
{
    public partial class AboutWindow : Form, IAboutWindow
    {
        public AboutWindow(IAboutWindowViewModel aboutWindowViewModel)
        {
            InitializeComponent();
            InitializeAsync();

            this.DataContext = aboutWindowViewModel;

            this.DataBindings.Add(
                nameof(this.Text),
                this.DataContext,
                "Title"
                );

            this.webView.DataBindings.Add(
                nameof(this.webView.Source),
                this.DataContext,
                "TechTaskFilePath"
                );
        }


        private async void InitializeAsync()
        {

            await this.webView.EnsureCoreWebView2Async(null);
            this.webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            this.webView.CoreWebView2.Settings.HiddenPdfToolbarItems = CoreWebView2PdfToolbarItems.Print 
                | CoreWebView2PdfToolbarItems.Save 
                | CoreWebView2PdfToolbarItems.SaveAs;
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
