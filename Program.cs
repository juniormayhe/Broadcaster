// *** Updated 7/19/2017 7:30 PM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcaster
{
    static class Program
    {
        static Mutex mutex = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());



            bool result;
            mutex = new Mutex(false, "C13B1D39-53F5-4DC4-BCF1-95A3ADA697A4", out result);

            if (!result)
            {
                //ja existe instancia rodando
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());

            GC.KeepAlive(mutex);
        }
    }
}
