using Iron_Mountain_Coding_Challenge.Repository;
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

            var container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            var mainForm = container.Resolve<Form1>();

            Application.Run(mainForm);
        }
    }
}
