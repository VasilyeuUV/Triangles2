using Colors.Models;
using System.Drawing;

namespace Colors.Extensions
{
    public static class ColorExtensions
    {

        /// <summary>
        /// HsbModel to Color Converter
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Color ToColor(this HsbColorModel item)
        {
            return HsbToRgb(item);
        }

        /// <summary>
        /// HsbModel to RGB Converter
        /// </summary>
        /// <param name="hsbColorModel"></param>
        /// <returns></returns>
        public static Color HsbToRgb(HsbColorModel hsbColorModel)
        {
            return HsbToRgb(255, hsbColorModel.Hue, hsbColorModel.Saturation, hsbColorModel.Brightness);
        }


        private static Color HsbToRgb(byte alpha, int hue, int saturation, int value)
        {
            if (alpha < 0 || alpha > 255)
                throw new ArgumentOutOfRangeException(nameof(hue), hue, "Alpha must be in the range [0,255]");
            if (hue < 0 || hue > 360)
                throw new ArgumentOutOfRangeException(nameof(hue), hue, "Hue must be in the range [0,360]");
            if (saturation < 0 || saturation > 100)
                throw new ArgumentOutOfRangeException(nameof(saturation), saturation, "Saturation must be in the range [0,100]");
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Value must be in the range [0,100]");

            float s = saturation / 100f;
            float v = value / 100f;

            int Component(int n)
            {
                var k = (n + hue / 60f) % 6;
                var c = v - v * s * Math.Max(Math.Min(Math.Min(k, 4 - k), 1), 0);
                var b = (int)Math.Round(c * 255);
                return b < 0 
                    ? 0 
                    : b > 255 
                        ? 255 
                        : b;
            }

            return Color.FromArgb(alpha, Component(5), Component(3), Component(1));
        }

    }
}
