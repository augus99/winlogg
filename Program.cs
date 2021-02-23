using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Winlogg {
    static class Program {
        [STAThread] static void Main() {
            using (Mutex mutex = new Mutex(false, Assembly.GetExecutingAssembly().GetHashCode().ToString())) {
                if (!mutex.WaitOne(0, false)) {
                    MessageBox.Show($"The application is already running on another process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GC.Collect();
                
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new App());
            }
        }
    }
}
