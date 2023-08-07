using Geometry.Models.SquareableFigures.TriangleModels;
using System.ComponentModel.DataAnnotations;

namespace Triangles.Models.Geometry
{
    public class TriangleNestedModel : TriangleModel
    {

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="coords"></param>
        public TriangleNestedModel(IEnumerable<int> coords) : base(coords)
        {
        }


        /// <summary>
        /// Уровень вложенности фигуры в другие фигуры
        /// </summary>
        [Range(0, int.MaxValue)]
        public int NestingLevel { get; set; }

    }
}
