using System.Windows.Input;
using Triangles.Contracts.Factories;
using Triangles.Contracts.Services.UserDialogService;
using Triangles.ViewModels.Commands;
using Triangles.ViewModels.ContentViewModels.Triangles;
using Triangles.ViewModels.Properties;
using Triangles.ViewModels.Windows.AboutWindow;

namespace Triangles.ViewModels.Windows.MainWindow.MainWindowMenuViewModel
{
    /// <summary>
    /// ViewModel меню главного окна
    /// </summary>
    public class MainWindowMenuViewModel : IMainWindowMenuViewModel
    {
        private readonly IWindowManager _windowManager;

        // - вьюмодели
        private IAboutWindowViewModel? _aboutWindowViewModel;

        // - сервисы
        private readonly IUserDialogService _userDialog;

        // - фабрики
        private readonly IFactory<IAboutWindowViewModel> _aboutWindowViewModelFactory;                  // - фабрика для вьюмодели окна "О программе"
        //private readonly IFactory<IAuthorCollectionViewModel> _authorCollectionViewModelFactory;    // - фабрика вьюмодели коллекции авторов
        private readonly IFactory<ITriangleCollectionViewModel> _triangleCollectionViewModelFactory;    // - фабрика вьюмодели коллекции треугольников

        // - команды
        private readonly Command _closeMainWindowCommand;                    // - команда закрытия главного окна
        private readonly Command _openAboutWindowCommand;                    // - команда открытия окна "О программе"
        //private readonly AsyncCommand _openAuthorCollectionCommand;          // - команда для получения коллекции Авторов
        //private readonly Command _throwExceptionCommand;                     // - команда имитации исключительной ситуации
        private readonly AsyncCommand _openFileCommand;                     // - команда открытия файла


        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowMenuViewModel(
            IWindowManager windowManager,
            IFactory<IAboutWindowViewModel> aboutWindowViewModelFactory,
            IUserDialogService userDialog,
            IFactory<ITriangleCollectionViewModel> triangleCollectionViewModelFactory
            //IFactory<IAuthorCollectionViewModel> authorCollectionViewModelFactory
            )
        {
            this._windowManager = windowManager;
            this._aboutWindowViewModelFactory = aboutWindowViewModelFactory;
            this._userDialog = userDialog;
            //this._authorCollectionViewModelFactory = authorCollectionViewModelFactory;
            this._triangleCollectionViewModelFactory = triangleCollectionViewModelFactory;

            _closeMainWindowCommand = new Command(CloseMainWindow);
            _openAboutWindowCommand = new Command(OpenAboutWindow);
            //_openAuthorCollectionCommand = new AsyncCommand(OpenAuthorCollectionAsync);
            //_throwExceptionCommand = new Command(() => throw new Exception("Test exception"));
            _openFileCommand = new AsyncCommand(OpenFileAsync);
        }


        //######################################################################################################################
        #region EVENTS

        /// <summary>
        /// Действия на событие закрытия окна "О программе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnAboutWindowClosed(object? sender, EventArgs e)
        {
            // - отписываемся от события и обнуляем текущщий экземпдяр вьюмодел
            if (sender is IWindow window)
            {
                window.Closed -= OnAboutWindowClosed;
                _aboutWindowViewModel = null;
            }
        }

        #endregion // EVENTS


        /// <summary>
        /// Закрытие главного окна
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void CloseMainWindow()
        {
            MainWindowClosingRequested?.Invoke();
        }


        /// <summary>
        /// Открыть окно "О программе"
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void OpenAboutWindow()
        {
            if (_aboutWindowViewModel == null)
            {
                _aboutWindowViewModel = _aboutWindowViewModelFactory.Create();
                var aboutWindow = _windowManager.Show(_aboutWindowViewModel);
                aboutWindow.Closed += OnAboutWindowClosed;
                return;
            }
            else
            {
                _windowManager.Show(_aboutWindowViewModel);
            }

        }


        /// <summary>
        /// Открытие файла
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private async Task OpenFileAsync()
        {
            var triangleCollectionViewModel = _triangleCollectionViewModelFactory.Create();
            await triangleCollectionViewModel.InitializeAsync();

            ContentViewModelChanged?.Invoke(triangleCollectionViewModel);
        }


        ///// <summary>
        ///// Получение списка авторов книг
        ///// </summary>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //private async Task OpenAuthorCollectionAsync()
        //{
        //    //var authorCollectionViewModel = _authorCollectionViewModelFactory.Create();
        //    await authorCollectionViewModel.InitializeAsync();                          // - здесь отработает логика запроса данных от REST-сервиса

        //    ContentViewModelChanged?.Invoke(authorCollectionViewModel);
        //}


        //######################################################################################################################
        #region IMainWindowMenuViewModel

        public event Action? MainWindowClosingRequested;
        public event Action<IMainWindowContentViewModel>? ContentViewModelChanged;

        public ICommand CloseMainWindowCommand => _closeMainWindowCommand;
        public ICommand OpenAboutWindowCommand => _openAboutWindowCommand;
        //public ICommand OpenAuthorCollectionCommand => _openAuthorCollectionCommand;
        //public ICommand ThrowExceptionCommand => _throwExceptionCommand;
        public ICommand OpenFileCommand => _openFileCommand;

        public void CloseAboutWindow()
        {
            if (_aboutWindowViewModel != null)
                _windowManager.Close(_aboutWindowViewModel);        // - закрытие окна "О программе"
        }


        #endregion // IMainWindowMenuViewModel
    }
}
