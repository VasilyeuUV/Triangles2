using Triangles.Contracts.Services.PathService;
using Triangles.Contracts.Settings.AboutWindowSettings;

namespace Triangles.Infrastructure.Settings.AboutWindowSettings
{
    /// <summary>
    /// Оболочка для настройек окна "О программе"
    /// </summary>
    internal class AboutWindowMementoWrapper : AWindowMementoWrapperBase<AboutWindowMemento>, IAboutWindowMementoWrapper
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="pathService"></param>
        public AboutWindowMementoWrapper(IPathService pathService)
            : base(pathService)
        {
        }

        protected override string MementoName => "AboutWindowMemento";
    }
}
