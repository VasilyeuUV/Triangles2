using System.Drawing;

namespace Triangles.Models.ColorModels
{
    /// <summary>
    /// Модель цветов для bitmap
    /// </summary>
    public class BitmapColorModel
    {
        /// <summary>
        /// Самый светлый цвет
        /// </summary>
        public Color LightestColor { get; set; }


        /// <summary>
        /// Самый тёмный цвет
        /// </summary>
        public Color DarkestColor { get; set; }


        /// <summary>
        /// Цвета, которые допустимо использовать
        /// </summary>
        public Color[]? AllowedColors { get; set; }
    }
}
