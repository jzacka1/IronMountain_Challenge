using Iron_Mountain_Coding_Challenge.Repository;
using Serilog;
using System;
using System.Windows.Forms;
using Unity;

namespace Iron_Mountain_Coding_Challenge
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            var container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IMessageProvider, MessageProvider>(TypeLifetime.Singleton);
            container.RegisterType<ILoggingService, LoggingService>(TypeLifetime.Singleton);
            var mainForm = container.Resolve<Form1>();

            Application.Run(mainForm);
        }
    }
}
