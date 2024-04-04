using System;
using System.Windows.Forms;
using TongItsGame.Forms;

namespace TongItsGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable visual styles for the application.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create the main form and run the application.
            Application.Run(new StartForm());
        }
    }
}