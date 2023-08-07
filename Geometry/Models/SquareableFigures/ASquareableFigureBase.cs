using Geometry.Contracts;
using System.Drawing;

namespace Geometry.Models.SquareableFigures
{
    public abstract class ASquareableFigureBase : AFigure2dBase, ISquareable
    {
        private double _s;                  // - площадь фигуры


        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="coords"></param>
        protected ASquareableFigureBase(IEnumerable<int> coords) : base(coords)
        {
            this._s = GetSquare();
            this.FillColor = Color.Transparent;
        }


        ///// <summary>
        ///// Уровень вложенности фигуры в другие фигуры
        ///// </summary>
        //[Range(0, int.MaxValue)]
        //public int NestingLevel { get; set; }


        //############################################################################################################
        #region AFigure2dBase

        protected override bool CheckValidation()
        {
            return base.CheckValidation()
                || S <= 0;
        }

        #endregion // AFigure2dBase



        //############################################################################################################
        #region ISquareable

        public double S => _s;

        public Color FillColor { get; set; }

        public Color? LineColor { get; set; }

        #endregion // ISquareable


        /// <summary>
        /// Метод вычисления площади 2D фигуры
        /// </summary>
        /// <returns></returns>
        protected abstract double GetSquare();
        
    }
}
