namespace Triangles.Models.Geometry
{
    /// <summary>
    /// Модель входных данных для треугольника
    /// </summary>
    public class TriangleInputDataModel
    {
        /// <summary>
        /// Количество треугольников
        /// </summary>
        public int TrianglesCount { get; set; }


        /// <summary>
        /// Список координат
        /// </summary>
        public IEnumerable<int[]>? Coordinates { get; set; }
    }
}
