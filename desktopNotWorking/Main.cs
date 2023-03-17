using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace desktopNotWorking
{
    public partial class Main : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_COMMAND = 0x111;
        const int MIN_ALL_UNDO = 416;

        List<ImageForm> ImageFormList = new List<ImageForm>();
        int timerTicks;
        public Main(List<ImageForm> imageFormList)
        {
            InitializeComponent();
            ImageFormList = imageFormList;




        }

        private void timerTick(object sender, EventArgs e)
        {
            this.Focus();
            timerTicks++;
            if (timerTicks > 10) { 
                
                
                foreach (ImageForm imageForm in ImageFormList)
                {
                    imageForm.Show();
                    imageForm.Focus();


                }
                timer1.Tick -= timerTick;
            }
        }

        private void WhenClosed(object sender, FormClosedEventArgs e)
        {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL_UNDO, IntPtr.Zero);
        }
    }
}
