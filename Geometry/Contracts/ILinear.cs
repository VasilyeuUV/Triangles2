using System.Drawing;

namespace Geometry.Contracts
{
    /// <summary>
    /// Контракт линейоного объекта
    /// </summary>
    public interface ILinear
    {
        /// <summary>
        /// Цвет линии, точки границы
        /// </summary>
        Color? LineColor { get; }
    }
}
