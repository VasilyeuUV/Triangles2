using Triangles.Bootstrapper;

namespace Triangles
{
    internal static class Program
    {
        private static string appGuid = "3ae4924c-bfe8-402c-a879-7b8e10013751";          // - appGuid для Mutex-a
        private static ApplicationBootstrapper? _bootstrapper;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Mutex для запрета повторного запуска приложения
            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Внимание! Программа уже запущена. Запуск копии заблокирован", "Программа сообщает:");
                    return;
                }

                GC.Collect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();

                _bootstrapper = new ApplicationBootstrapper();

                // Add the event handler for handling UI thread exceptions to the event.
                Application.ThreadException += new ThreadExceptionEventHandler(Form_UIThreadException);

                // Set the unhandled exception mode to force all Windows Forms errors
                // to go through our handler.
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                // Add the event handler for handling non-UI thread exceptions to the event. 
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledExceptionRaised);

                var MainForm = _bootstrapper.CreateApplication();
                Application.Run(MainForm.Run());
            }
        }

        private static void Form_UIThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private static void OnUnhandledExceptionRaised(object sender, UnhandledExceptionEventArgs e)
        {
            if (_bootstrapper is null)
                return;

            var unhandledExceptionHandler = _bootstrapper.CreateUnhandledExceptionHandler();
            unhandledExceptionHandler.Handle(e);
        }
    }
}