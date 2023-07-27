﻿using Triangles.Contracts.Factories;
using Triangles.Contracts.Settings.MainWindowSettings;
using Triangles.ViewModels.Properties;
using Triangles.ViewModels.Windows.MainWindow.MainWindowMenuViewModel;

namespace Triangles.ViewModels.Windows.MainWindow
{
    /// <summary>
    /// Класс вьюмодели главного окна приложения
    /// </summary>
    public class MainWindowViewModel : AWindowViewModelBase<IMainWindowMementoWrapper>, IMainWindowViewModel
    {
        private readonly IWindowManager _windowManager;                                             // - менеджер окон
        private IMainWindowContentViewModel? _contentViewModel;


        /// <summary>
        /// CTOR
        /// </summary>
        public MainWindowViewModel(
            IMainWindowMementoWrapper mainWindowMementoWrapper,
            IWindowManager windowManager,
            IFactory<IMainWindowMenuViewModel> mainWindowMenuViewModelFactory
            //IFactory<IMainWindowStatusBarViewModel> mainWindowStatusBarViewModelFactory
            )
            : base(mainWindowMementoWrapper)
        {
            this._windowManager = windowManager;

            MenuViewModel = mainWindowMenuViewModelFactory.Create();
            //StatusBarViewModel = mainWindowStatusBarViewModelFactory.Create();

            MenuViewModel.MainWindowClosingRequested += OnMainWindowClosingRequested;
            MenuViewModel.ContentViewModelChanged += OnContentViewModelChanged;
        }


        //############################################################################################################
        #region AWindowViewModelBase

        public override string Title => strings.MainFormTitle;


        public override void WindowClosing()
        {
            base.WindowClosing();

            MenuViewModel.CloseAboutWindow();       // - закрытие окна "О программе"
        }

        #endregion // AWindowViewModelBase


        /// <summary>
        /// Вьюмодель меню главного окна
        /// </summary>
        public IMainWindowMenuViewModel MenuViewModel { get; }


        /// <summary>
        /// Вьюмодель строки состояния главного окна
        /// </summary>
        //public IMainWindowStatusBarViewModel StatusBarViewModel { get; }


        /// <summary>
        /// Вьюмодель контента главного окна
        /// </summary>
        public IMainWindowContentViewModel? ContentViewModel
        {
            get => _contentViewModel;
            private set => Set(ref _contentViewModel, value);
        }



        //############################################################################################################
        #region EVENTS


        /// <summary>
        /// Действия на событие закрытия главного окна
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void OnMainWindowClosingRequested()
        {
            _windowManager.Close(this);
        }


        /// <summary>
        /// Действие на изменение контента главного окна
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnContentViewModelChanged(IMainWindowContentViewModel contentViewModel)
        {
            ContentViewModel = contentViewModel;
        }

        #endregion // EVENTS


        //############################################################################################################
        #region IMainWindowViewModel


        public void Dispose()
        {
            MenuViewModel.MainWindowClosingRequested -= OnMainWindowClosingRequested;
            MenuViewModel.ContentViewModelChanged -= OnContentViewModelChanged;

            //StatusBarViewModel.Dispose();
        }

        #endregion // IMainWindowViewModel
    }
}
