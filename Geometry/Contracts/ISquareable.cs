using System.Drawing;

namespace Geometry.Contracts
{
    /// <summary>
    /// Контракт объекта, имеющего площадь
    /// </summary>
    internal interface ISquareable : ILinear
    {
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        double S { get; }


        /// <summary>
        /// Цвет заливки фигуры
        /// </summary>
        Color FillColor { get; }
    }
}
