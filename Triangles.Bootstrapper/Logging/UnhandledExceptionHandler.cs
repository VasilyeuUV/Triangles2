using NLog;


namespace Triangles.Bootstrapper.Logging
{
    internal class UnhandledExceptionHandler : IUnhandledExceptionHandler
    {
        private static readonly ILogger Logger = LogManager.GetLogger(nameof(UnhandledExceptionHandler));       // - логгер


        //######################################################################################################################
        #region IUnhandledExceptionHandler

        public void Handle(UnhandledExceptionEventArgs args)
        {
            Exception ex = (Exception)args.ExceptionObject;
            Logger.Error(ex);                   // - логирование ошибки и передача Exception
            //args.Handled = true;                // - сообщаем подсистеме WPF, что обработали возникшее исключение
        }

        #endregion // IUnhandledExceptionHandler

    }
}
