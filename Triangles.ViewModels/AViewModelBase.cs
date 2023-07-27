﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Triangles.ViewModels
{
    /// <summary>
    /// Базовый класс вьюмодели
    /// </summary>
    public abstract class AViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Метод для удобства использования Потребителями 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void InvokePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //############################################################################################################
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion // INotifyPropertyChanged
    }
}
