using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace omnirover.auto.APITest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public delegate void EnumChildWindowsProc(IntPtr hwnd, int lparam);

        [DllImport("user32.dll")]
        private static extern int GetDlgCtrlID(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDlgItem(IntPtr dlgHwnd, int cltrlID);

        [DllImport("user32.dll")]
        private static extern int GetDlgItemText(IntPtr dlgHwnd, int cltrlID, StringBuilder sb, int max);

        [DllImport("user32.dll")]
        private static extern int GetDlgItemText(IntPtr dlgHwnd, int cltrlID, out bool lpTranslated, bool isSigned);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr dlgHwnd, int msg, int wparam, int lparam);

        [DllImport("user32.dll")]
        private static extern IntPtr GetAncestor(IntPtr Hwnd, int gaFlag);

        [DllImport("user32.dll")]
        private static extern IntPtr GetParent(IntPtr dlgHwnd);

        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr parentHwnd, EnumChildWindowsProc enumProc, int lParam);

        [DllImport("user32.dll")]
        private static extern bool GetWindowText(IntPtr Hwnd, StringBuilder sb, int max);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(String className, String windowName);

        private const int BM_CLICK = 0x00F5;

        List<IntPtr> handles = new List<IntPtr>();

        private void Form2_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //-------------------------------------------------
            IntPtr cHwnd = findChildControl2("Calculator", 133);
            GetWindowText(cHwnd, sb, 255);
            MessageBox.Show(sb.ToString());
            return;
            //--------------------------------------------------
            IntPtr objHandle = new IntPtr(0xE05C4);
            IntPtr parentHandle = GetAncestor(objHandle, 2);//GetParent(objHandle);
            MessageBox.Show(parentHandle.ToInt64().ToString("X"));

            handles.Clear();
            EnumChildWindows(parentHandle, EnumWindowsProc, 0);
            printWindows(handles);
            MessageBox.Show(findChildWindowIndex(objHandle, handles).ToString());
            //IntPtr dlgHandle = new IntPtr(0x00040E58);
            //IntPtr CtrlHandle = new IntPtr(0x00040E64);
            int id = GetDlgCtrlID(objHandle);
            MessageBox.Show(id.ToString());
            //IntPtr childHwnd = GetDlgItem(parentHandle, id);
            //MessageBox.Show(childHwnd.ToInt64().ToString("X"));

            //GetDlgItemText(parentHandle, id,sb, 255);
            GetWindowText(parentHandle, sb, 255);
            MessageBox.Show(sb.ToString());

            GetWindowText(objHandle, sb, 255);
            MessageBox.Show(sb.ToString());
            //bool output;
            //int idFromText =  GetDlgItemText(dlgHandle, id,out output, false);
            //MessageBox.Show(idFromText.ToString() + " " + output.ToString());
            //SendMessage(CtrlHandle, BM_CLICK, 0, 0);
        }

        private IntPtr findChildControl(string windowName, int childID)
        {
            IntPtr parentWindow = FindWindow(null, windowName);
            MessageBox.Show(parentWindow.ToInt64().ToString("X"));

            IntPtr childHwnd = GetDlgItem(parentWindow, childID);
            MessageBox.Show(childHwnd.ToInt64().ToString("X"));
            return childHwnd;
        }

        private IntPtr findChildControl2(string windowName, int childIndex)
        {
            IntPtr parentWindow = FindWindow(null, windowName);
            MessageBox.Show(parentWindow.ToInt64().ToString("X"));

            handles.Clear();
            EnumChildWindows(parentWindow, EnumWindowsProc, 0);

            IntPtr childHwnd = handles[childIndex];
            MessageBox.Show(childHwnd.ToInt64().ToString("X"));
            return childHwnd;
        }

        private void EnumWindowsProc(IntPtr hwnd, int lparam)
        {
            handles.Add(hwnd);
        }

        private void printWindows(List<IntPtr> handles)
        {
            foreach (IntPtr item in handles)
            {
                Console.WriteLine(item.ToInt64().ToString("X"));
            }
        }

        private int findChildWindowIndex(IntPtr childHwnd, List<IntPtr> handles)
        {
            return handles.IndexOf(childHwnd);
        }
    }
}
