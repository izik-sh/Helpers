using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilitiesForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                string path = System.IO.Directory.GetParent(Environment.CurrentDirectory) + @"\..\..\Encryptions\bin\debug\net6.0-windows\Encryptions.exe";
                Process p = Process.Start(path);

                p.WaitForInputIdle();
                Thread.Sleep(1500); // Allow the process to open it's window
                SetParent(p.MainWindowHandle, tabPage1.Handle);

                string path2 = System.IO.Directory.GetParent(Environment.CurrentDirectory) + @"\..\..\SqlTester\bin\debug\SqlTester.exe";
                Process p2 = Process.Start(path2);

                p2.WaitForInputIdle();
                Thread.Sleep(1500); // Allow the process to open it's window
                SetParent(p2.MainWindowHandle, tabPage2.Handle);

                //string path3 = System.IO.Directory.GetParent(Environment.CurrentDirectory) + @"\..\..\Encryptions\bin\debug\net6.0-windows\Encryptions.exe";
                //Process p3 = Process.Start(path3);

                //p3.WaitForInputIdle();
                //Thread.Sleep(500); // Allow the process to open it's window
                //SetWindowPos(p3.MainWindowHandle, tabPage1.Handle,50,50,500,500,1);

            }
            catch (Exception ex) { }
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
    }
}
