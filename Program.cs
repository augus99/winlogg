using System;
using System.Windows.Forms;

namespace Winlogg {
    static class Program {
        [STAThread] static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
