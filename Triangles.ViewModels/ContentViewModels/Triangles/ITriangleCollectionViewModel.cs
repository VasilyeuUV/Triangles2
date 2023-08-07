using Triangles.ViewModels.Windows.MainWindow;

namespace Triangles.ViewModels.ContentViewModels.Triangles
{
    /// <summary>
    /// Интерфейс для коллекции треугольников
    /// </summary>
    public interface ITriangleCollectionViewModel : IMainWindowContentViewModel
    {
        /// <summary>
        /// Инициализация данных
        /// </summary>
        /// <returns></returns>
        Task InitializeAsync();
    }
}
