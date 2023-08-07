using System.ComponentModel.DataAnnotations;

namespace Colors.Models
{
    /// <summary>
    /// Цветовая модель HSB
    /// </summary>
    public class HsbColorModel
    {
        /// <summary>
        /// Цветовой тон
        /// </summary>
        [Range(0, 360)]
        public required int Hue { get; set; }

        /// <summary>
        /// Насыщенность цвета (Чем больше значение, тем «чище» цвет)
        /// </summary>
        [Range(0, 100)]
        public required int Saturation { get; set; }

        /// <summary>
        /// Яркость цвета (Чем меньше значение, тем темнее)
        /// </summary>
        [Range(0, 100)]
        public required int Brightness { get; set; }
    }
}
