namespace Triangles.Models.FileDataModels
{
    /// <summary>
    /// Модель входных данных координат
    /// </summary>
    public class  InputCoordinatesDataModel
    {
        /// <summary>
        /// Количество геометрических фигур
        /// </summary>
        public int GeometricFiguresCount { get; set; }


        /// <summary>
        /// Список координат
        /// </summary>
        public IEnumerable<int[]>? Coordinates { get; set; }
    }
}
