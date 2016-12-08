using System;
using System.Windows.Forms;

namespace IoCAndReactiveExtensions.Start
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var container = new Bootstrapper().Execute())
            {
                using (var mainForm = container.Resolve<FormMain>())
                {
                    Application.Run(mainForm);
                }
            }
        }
    }
}
