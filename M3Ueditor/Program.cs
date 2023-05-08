using M3Ueditor.Class;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace M3Ueditor
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Count() > 0 && (args[0] == "--version" || args[0] == "--ver"))
            {
                // Перенаправить вывод консоли в родительский процесс (перед любыми вызовами Console.WriteLine())
                AttachConsole(ATTACH_PARENT_PROCESS);

                Console.WriteLine(About.AssemblyVersion);

                // Чтобы не ждать нажатия Enter в консоли
                SendKeys.SendWait("{ENTER}");
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
        }
    }
}
