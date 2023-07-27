namespace Triangles.Contracts.Services.PathService
{
    /// <summary>
    /// Контракт сервиса для работы с путями к файлам и каталогам
    /// </summary>
    public interface IPathService
    {
        /// <summary>
        /// Путь к каталогу приложения для сохранения настроек (для потребителя)
        /// </summary>
        string ApplicationSettingsFolder { get; }


        /// <summary>
        /// Путь к каталогу, где лежит исполняемый файл
        /// </summary>
        string ApplicationFolder { get; }
    }
}
