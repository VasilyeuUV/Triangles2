using Geometry.Extensions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Geometry.Models
{
    /// <summary>
    /// Геометрическая фигура на плоскости
    /// </summary>
    internal abstract class AFigure2dBase
    {
        private const int _DIMENSION = 2;                                   // - количество измерений для 2D


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="coords">Значения координат в виде масиива </param>
        protected AFigure2dBase(IEnumerable<int> coords)
        {
            this.Coordinates = AddCoordinates(coords).ToArray();
            this.Mask = GetMask(this.Coordinates);
        }


        /// <summary>
        /// Координаты геометрической фигуры на плоскости
        /// </summary>
        public Point[]? Coordinates { get; private set; }


        /// <summary>
        /// Маска фигуры
        /// </summary>
        public int[,]? Mask { get; set; }


        /// <summary>
        /// Валидация фигуры
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckValidation()
        {
            return Coordinates is null
                || Coordinates.Length <= 0;
        }


        /// <summary>
        /// Создать и добавить координаты точек
        /// </summary>
        /// <param name="coords"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static IEnumerable<Point> AddCoordinates(IEnumerable<int> coords)
        {
            foreach (var coord in coords.Split(_DIMENSION))
            {
                if (coord.Count() == _DIMENSION)
                    yield return new Point(coord.First(), coord.Last());                
            }
        }



        private int[,]? GetMask(Point[] coordinates)
        {
            var maxH = (int)coordinates.Max(coord => coord.X);
            var maxW = (int)coordinates.Max(coord => coord.Y);
            var bitmap = new Bitmap(maxH, maxW);
            var maskArray = new int[maxH * maxW];

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                g.FillPolygon(new SolidBrush(Color.Green), coordinates);

                Rectangle rect = new Rectangle(0, 0, maxH, maxW);
                BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
                byte[] rgbValues = new byte[bytes];
                Marshal.Copy(ptr, rgbValues, 0, bytes);

                for (int counter = 0, k = 0; counter < rgbValues.Length; counter += 4, k++)
                {
                    if (
                        rgbValues[counter] != 0               // blue
                        || rgbValues[counter + 1] != 0        // green
                        || rgbValues[counter + 2] != 0        // red
                        )
                        ++maskArray[k];
                }
                Marshal.Copy(rgbValues, 0, ptr, bytes);
                bitmap.UnlockBits(bmpData);
            }

            var mask = maskArray.ToArray2D(maxW);
            return mask;
        }
    }
}
