using System.Drawing;
using Triangles.Contracts;
using Triangles.Contracts.Services.UserDialogService;

namespace Triangles.ViewModels.ContentViewModels
{
    public class MainContentViewModel : AViewModelBase, IMainContentViewModel
    {
        private readonly IUserDialogService _userDialog;

        private string? _nestingLevelMax;
        private Bitmap _bitmap = new(Const.HEIGHT_MAXVALUE, Const.WEIDT_MAXVALUE);
        //private AllowedColors? _allowedColors;

        /// <summary>
        /// CTOR
        /// </summary>
        public MainContentViewModel(
            IUserDialogService userDialog
            )
        {
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
        /// Канвас для рисования
        /// </summary>
        public Bitmap Bitmap
        {
            get => _bitmap;
            set => Set(ref _bitmap, value);
        }


        //#########################################################################################################
        #region IMainContentViewModel

        public async Task InitializeAsync()
        {
            var triangles = 0;
        }

        #endregion // IMainContentViewModel

    }
}
