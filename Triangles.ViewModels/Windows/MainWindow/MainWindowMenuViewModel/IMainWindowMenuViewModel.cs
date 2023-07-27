﻿using System.Windows.Input;

namespace Triangles.ViewModels.Windows.MainWindow.MainWindowMenuViewModel
{
    /// <summary>
    /// Контракт для меню главного окна
    /// </summary>
    public interface IMainWindowMenuViewModel
    {
        /// <summary>
        /// Для уведомления о закрытии главного окна
        /// </summary>
        event Action? MainWindowClosingRequested;

        /// <summary>
        /// Для уведомления о создании нового контента
        /// (интерфейс для контента для уведомления главного окна, что был создан контент)
        /// </summary>
        event Action<IMainWindowContentViewModel>? ContentViewModelChanged;


        /// <summary>
        /// Команда закрытия главного окна
        /// </summary>
        ICommand CloseMainWindowCommand { get; }

        /// <summary>
        /// Команда на открытие окна "О программе"
        /// </summary>
        ICommand OpenAboutWindowCommand { get; }

        ///// <summary>
        ///// Команда получения авторов книг от API
        ///// </summary>
        //ICommand OpenAuthorCollectionCommand { get; }

        /// <summary>
        /// Команда Открытие файла
        /// </summary>
        ICommand OpenFileCommand { get; }


        /// <summary>
        /// Закрытие окна "О программе"
        /// </summary>
        void CloseAboutWindow();
    }
}
