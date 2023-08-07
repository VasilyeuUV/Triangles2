using Colors.Extensions;
using Colors.Models;
using Geometry.Models.SquareableFigures.TriangleModels;
using System.Drawing;
using Triangles.Models.ColorModels;
using Triangles.Models.Geometry;
using Triangles.ViewModels.Properties;

namespace Triangles.ViewModels.ContentViewModels.Triangles
{
    public partial class TriangleCollectionViewModel
    {

        //########################################################################################################
        #region Init triangles

        /// <summary>
        /// Создание треугольников
        /// </summary>
        /// <param name="triangleInputDataCollection"></param>
        /// <param name="triangleBackgroundColors"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private IEnumerable<TriangleNestedModel> GetTriangles(IEnumerable<int[]> coordinates)
        {
            List<TriangleNestedModel> triangles = new List<TriangleNestedModel>();
            foreach (var coord in coordinates)
            {
                var triangle = new TriangleNestedModel(coord);
                triangles.Add(triangle);
            }
            var orderedTriangles = triangles.OrderByDescending(t => t.S);
            return orderedTriangles;
        }


        /// <summary>
        /// Формирование общей матрицы изображений
        /// </summary>
        /// <param name="triangles"></param>
        /// <returns></returns>
        private int[,] GetCommonMatrix(IEnumerable<TriangleNestedModel> triangles, Color[]? allowedColors)
        {
            if (allowedColors == null)
                throw new ArgumentNullException(nameof(allowedColors));

            var maxX = (int)triangles.Max(p => p.Coordinates.Max(c => c.X));
            var maxY = (int)triangles.Max(p => p.Coordinates.Max(c => c.Y));
            var commonMatrix = new int[maxX, maxY];

            int maxLevel = 0;
            foreach (var triangle in triangles)
            {
                SummArray(commonMatrix, triangle);
                maxLevel = commonMatrix.Cast<int>().Max();
                triangle.FillColor = allowedColors[triangle.NestingLevel - 1];
            }

            return commonMatrix;
        }


        //private Task<int[,]> GetCommonMatrixAsync(IEnumerable<TriangleNestedModel> triangles, Color[]? allowedColors)
        //{
        //    if (allowedColors == null)
        //        throw new ArgumentNullException(nameof(allowedColors));

        //    var maxX = (int)triangles.Max(p => p.Coordinates.Max(c => c.X));
        //    var maxY = (int)triangles.Max(p => p.Coordinates.Max(c => c.Y));
        //    var commonMatrix = new int[maxX, maxY];

        //    int maxLevel = 0;
        //    foreach (var triangle in triangles)
        //    {
        //        SummArray(commonMatrix, triangle.Mask);
        //        maxLevel = commonMatrix.Cast<int>().Max();
        //        triangle.FillColor = allowedColors[triangle.NestingLevel - 1];
        //    }

        //    return commonMatrix;
        //}



        private void SummArray(int[,] commonMatrix, TriangleNestedModel triangle)
        {
            var triangleNestingLevel = GetMaxNestingLevel(triangle.Mask);
            for (int i = 0; i < triangle.Mask.GetLength(0); i++)
                for (int j = 0; j < triangle.Mask.GetLength(1); j++)
                {
                    commonMatrix[i, j] += triangle.Mask[i, j];
                    if (triangle.Mask[i, j] != 0
                        && commonMatrix[i, j] > triangleNestingLevel)
                        triangleNestingLevel = commonMatrix[i, j];
                }
            triangle.NestingLevel = triangleNestingLevel;
        }


        /// <summary>
        /// Получение уровня вложенности
        /// </summary>
        /// <param name="commonMatrix"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private int GetMaxNestingLevel(int[,] commonMatrix)
        {
            return commonMatrix
                .Cast<int>()
                .Max();
        }

        #endregion // Init triangles



        //########################################################################################################
        #region Triangle input data

        private async Task<TriangleInputDataModel?> GetTrianglesInputData(string? filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)
                || !File.Exists(filePath)
                )
                throw new FileNotFoundException($"{strings.FileNotFound}: {filePath}");

            string text = string.Empty;
            using (var reader = new StreamReader(filePath))
            {
                text = await reader.ReadToEndAsync();
            }

            return string.IsNullOrEmpty(text)
                ? null
                : ParseTriangles(text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }


        /// <summary>
        /// Получение входных данных для треугольников
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private TriangleInputDataModel ParseTriangles(string[] lines)
        {
            if (lines == null)
                throw new InvalidDataException(strings.ErrMsgInvalidData);

            int.TryParse(lines[0], out var triangleCount);
            if (triangleCount != lines.Length - 1)
                throw new InvalidDataException(strings.ErrMsgInvalidData);

            var triangleInputDataModel = new TriangleInputDataModel
            {
                TrianglesCount = triangleCount,
                Coordinates = ParseCoordinates(lines)
            };
            return triangleInputDataModel;
        }


        /// <summary>
        /// Парсинг координат
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        private IEnumerable<int[]> ParseCoordinates(string[]? lines)
        {
            if (lines == null
                || lines.Length < 2
                || !int.TryParse(lines[0].Trim(), out int figureCount)
                || figureCount != lines.Length - 1
                )
                throw new InvalidDataException(strings.InvalidInputData);

            foreach (var line in lines.Skip(1))
            {
                int value = 0;
                var result = line
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(item => int.TryParse(item, out value))
                    .Select(x => value)
                    .ToArray();
                yield return result;
            }
        }

        #endregion // Triangle input data



        //########################################################################################################
        #region Colors

        /// <summary>
        /// Инициализация допустимых цветов для заливки треугольников
        /// </summary>
        /// <param name="trianglesCount"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private BitmapColorModel InitAllowedColors(int trianglesCount)
        {
            var lightestColor = new HsbColorModel
            {
                Hue = 90,
                Saturation = 30,
                Brightness = 100,
            };
            var darkestColor = new HsbColorModel
            {
                Hue = 150,
                Saturation = 100,
                Brightness = 30,
            };

            var bitmapColorModel = new BitmapColorModel
            {
                LightestColor = lightestColor.ToColor(),
                DarkestColor = darkestColor.ToColor()
            };
            bitmapColorModel.AllowedColors = SelectColors(trianglesCount, lightestColor, darkestColor)
                    ?.ToArray();

            return bitmapColorModel;
        }


        /// <summary>
        /// Выбор допустимых цветов
        /// </summary>
        /// <param name="trianglesCount"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Color[] SelectColors(int count, HsbColorModel lightestColor, HsbColorModel darkestColor)
        {
            if (count < 1)
             return new Color[1] { darkestColor.ToColor() };

            var hueDiap = darkestColor.Hue - lightestColor.Hue;
            if (hueDiap < 1)
                throw new InvalidDataException(nameof(hueDiap));

            var propertiesCount = typeof(HsbColorModel).GetProperties().Count();
            var percentStep = Math.Round((float)(hueDiap / count * 100M / hueDiap) * propertiesCount, 2);

            var hue = lightestColor.Hue;
            var saturation = lightestColor.Saturation;
            var brightness = lightestColor.Brightness;

            var hueStep = (int)(hueDiap * percentStep / 100);
            var saturationStep = (int)((darkestColor.Saturation - lightestColor.Saturation) * percentStep / 100);
            var brightnessStep = (int)((darkestColor.Brightness - lightestColor.Brightness) * percentStep / 100);

            List<Color> usedColors = new List<Color>();
            for (int i = 1, j = 1; i <= count; i++)
            {
                if (i == j)
                    hue += hueStep;
                if (i == j + 1)
                {
                    saturation += saturationStep;
                    if (saturation > 100)
                        saturation = 100;
                }
                if (i == j + 2)
                {
                    brightness += brightnessStep;
                    if (brightness < 0)
                        brightness = 0;
                    j = i + 1;
                }

                var usedHsb = new HsbColorModel
                {
                    Hue = hue,
                    Saturation = saturation,
                    Brightness = brightness
                };

                usedColors.Add(usedHsb.ToColor());
            };

            return usedColors.ToArray();
        }


        #endregion // Colors
    }
}
