using System.Drawing;
using Triangles.Contracts;
using Triangles.Contracts.Services.UserDialogService;
using Triangles.Models.ColorModels;
using Triangles.ViewModels.Properties;

namespace Triangles.ViewModels.ContentViewModels.Triangles
{
    public partial class TriangleCollectionViewModel : AViewModelBase, ITriangleCollectionViewModel
    {
        private string? _nestingLevelMax;
        private Bitmap _bitmap;
        private BitmapColorModel _triangleColors;
        private readonly IUserDialogService _userDialog;


        /// <summary>
        /// CTOR
        /// </summary>
        public TriangleCollectionViewModel(
            IUserDialogService userDialog
            )
        {
            this._bitmap = new Bitmap(Const.WEIDT_MAXVALUE, Const.HEIGHT_MAXVALUE);
            this._triangleColors = new BitmapColorModel();
            this._userDialog = userDialog;
        }



        /// <summary>
        /// Максимальный уровень вложенности
        /// </summary>
        public string? NestingLevelMax
        {
            get => _nestingLevelMax;
            set => Set(ref _nestingLevelMax, value);
        }


        /// <summary>
        /// 
        /// </summary>
        public Bitmap Bitmap
        {
            get => _bitmap;
            set => Set(ref _bitmap, value);
        }


        public BitmapColorModel TriangleColors
        {
            get => _triangleColors;
            set => Set(ref _triangleColors, value);
        }


    //########################################################################################################
    #region ITriangleCollectionViewModel

    public async Task InitializeAsync()
        {
            _userDialog.OpenFile(
                strings.SelectTrianglesCoordsFile,
                out string? filePath,
                "Text files (*.txt) | *.txt"
                );

            try
            {
                var triangleInputDataCollection = await GetTrianglesInputData(filePath);
                if (triangleInputDataCollection == null
                    || triangleInputDataCollection.Coordinates == null
                    || triangleInputDataCollection.Coordinates.Count() < 1
                    )
                {
                    _userDialog.ShowError(strings.ErrMsgTitle, strings.ErrMsgInvalidData);
                    return;
                }

                TriangleColors = InitAllowedColors(triangleInputDataCollection.TrianglesCount);
                var triangles = GetTriangles(triangleInputDataCollection.Coordinates);

                var commonMatrix = await Task.Run(() => GetCommonMatrix(triangles, TriangleColors?.AllowedColors));
                if (commonMatrix == null)
                    throw new InvalidDataException(strings.CommonMatrixIsNull);
                NestingLevelMax = GetMaxNestingLevel(commonMatrix).ToString();

                Bitmap bitmap = new Bitmap(Const.WEIDT_MAXVALUE, Const.HEIGHT_MAXVALUE);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.Transparent);
                    foreach (var triangle in triangles)
                        g.FillPolygon(new SolidBrush(triangle.FillColor), triangle.Coordinates);
                }
                Bitmap = bitmap;
            }
            catch (FileNotFoundException ex)
            {
                _userDialog.ShowError(strings.ErrMsgOpenFileTitle, ex.Message);
                NestingLevelMax = strings.Error;
                Bitmap = new Bitmap(Const.WEIDT_MAXVALUE, Const.HEIGHT_MAXVALUE);
            }
            catch (Exception ex)
            {
                _userDialog.ShowError(strings.ErrMsgTitle, ex.Message);
                NestingLevelMax = strings.Error;
                Bitmap = new Bitmap(Const.WEIDT_MAXVALUE, Const.HEIGHT_MAXVALUE);
            }
        }


        #endregion // ITriangleCollectionViewModel
    }
}
