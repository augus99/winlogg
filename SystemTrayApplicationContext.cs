using System;
using System.Drawing;
using System.Windows.Forms;

namespace Winlogg {
    public abstract class SystemTrayApplicationContext: ApplicationContext {
        protected bool Released { get; private set; }
        protected NotifyIcon NotifyIcon { get; }
        protected ContextMenuStrip ContextMenuStrip { get; }

        protected SystemTrayApplicationContext(string tooltip) {
            ContextMenuStrip = new ContextMenuStrip();
            NotifyIcon = new NotifyIcon();
            
            Application.ApplicationExit += SystemTrayApplicationExitHandler;
            
            ContextMenuStrip.ShowImageMargin = false;
            ContextMenuStrip.BackColor = SystemColors.Control;
            
            NotifyIcon.Text = tooltip;
            NotifyIcon.Visible = true;
            NotifyIcon.ContextMenuStrip = ContextMenuStrip;
            NotifyIcon.MouseClick += TrayIconClickHandler;
            NotifyIcon.MouseDoubleClick += TrayIconDoubleClickHandler;
        }

        protected virtual void OnApplicationExit(EventArgs e) => ReleaseResources();
        protected virtual void OnTrayIconClick(MouseEventArgs e) { }
        protected virtual void OnTrayIconDoubleClick(MouseEventArgs e) { }

        private void SystemTrayApplicationExitHandler(object sender, EventArgs e) => OnApplicationExit(e);
        private void TrayIconClickHandler(object sender, MouseEventArgs e) => OnTrayIconClick(e);
        private void TrayIconDoubleClickHandler(object sender, MouseEventArgs e) => OnTrayIconDoubleClick(e);

        private void ReleaseResources() { 
            if (!Released) {
                Released = true;
                ContextMenuStrip.Dispose();
                NotifyIcon.Visible = false;
                NotifyIcon.Dispose();
            }
        }
    }
}