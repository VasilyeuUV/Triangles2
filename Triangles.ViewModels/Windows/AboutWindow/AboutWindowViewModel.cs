using Triangles.Contracts.Services.PathService;
using Triangles.Contracts.Settings.AboutWindowSettings;
using Triangles.ViewModels.Properties;

namespace Triangles.ViewModels.Windows.AboutWindow
{
    /// <summary>
    /// Вьюмодель окна "О программе"
    /// </summary>
    public class AboutWindowViewModel : AWindowViewModelBase<IAboutWindowMementoWrapper>, IAboutWindowViewModel
    {
        private readonly IPathService _pathService;
        private readonly Uri _techTaskFilePath;


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="windowMementoWrapper"></param>
        public AboutWindowViewModel(
            IAboutWindowMementoWrapper windowMementoWrapper,
            IPathService pathService
            //IApplicationVersionProvider applicationVersionProvider
            )
            : base(windowMementoWrapper)
        {

            //Version = $"Version {applicationVersionProvider.Version.ToString(3)}";
            this._pathService = pathService;
            this._techTaskFilePath = new Uri(
                Path.Combine(_pathService.ApplicationFolder, @"Resources/AxxonSoft_C#_task_triangles.pdf")
                );

        }


        //############################################################################################################################################
        #region AWindowViewModelBase

        public override string Title => strings.AboutFormTitle;


        #endregion // AWindowViewModelBase



        ///// <summary>
        ///// Версия приложения
        ///// </summary>
        //public string Version { get; }


        public Uri TechTaskFilePath => _techTaskFilePath;

    }
}
