using System.Drawing;

namespace Geometry.Contracts
{
    /// <summary>
    /// Контракт объекта, имеющего площадь
    /// </summary>
    internal interface ISquareable : ILineable
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        double S { get; }


        /// <summary>
        /// Цвет заливки фигуры
        /// </summary>
        Color? FillColor { get; }
    }
}
