using Triangles.ViewModels.Windows.MainWindow;

namespace Triangles.ViewModels.ContentViewModels
{
    public interface IMainContentViewModel : IMainWindowContentViewModel          // - это контентная вьюмодель
    {
        /// <summary>
        /// Отвечает за инициализацию данных
        /// </summary>
        /// <returns></returns>
        Task InitializeAsync();
    }
}
