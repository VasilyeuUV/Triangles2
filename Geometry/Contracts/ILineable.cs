using System.Drawing;

namespace Geometry.Contracts
{
    /// <summary>
    /// Контракт линейоного объекта
    /// </summary>
    public interface ILineable
    {
        /// <summary>
        /// Цвет линии, точки границы
        /// </summary>
        public Color? LineColor { get; set; }
    }
}
