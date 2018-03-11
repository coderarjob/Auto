using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace omnirover.auto.APITest
{
    class ControlIdentity
    {
        #region WINAPI
            public delegate void EnumChildWindowsProc(IntPtr hwnd, int lparam);

            [DllImport("user32.dll")]
            private static extern IntPtr GetAncestor(IntPtr Hwnd, int gaFlag);

            [DllImport("user32.dll")]
            private static extern bool EnumChildWindows(IntPtr parentHwnd, EnumChildWindowsProc enumProc, int lParam);

            [DllImport("user32.dll")]
            private static extern bool GetWindowText(IntPtr Hwnd, StringBuilder sb, int max);

            [DllImport("user32.dll")]
            private static extern IntPtr FindWindow(String className, String windowName);
        #endregion

        public int Index { get; protected set; }
        public String WindowName { get; protected set; }
        public IntPtr WindowHwnd { get; protected set; }
        public IntPtr ControlHwnd { get; protected set; }

        private static List<IntPtr> handles = new List<IntPtr>();

        public ControlIdentity(String windowName, IntPtr windowHwnd, IntPtr controlHwnd, int controlIndex)
        {
            this.WindowHwnd = windowHwnd;
            this.ControlHwnd = controlHwnd;
            this.Index = controlIndex;
            this.WindowName = windowName;
        }

        public static ControlIdentity GetControlIdentity(IntPtr controlHwnd)
        {
            IntPtr parentHandle = GetAncestor(controlHwnd, 2);
            int controlIndex = Win32API.GetWindowIndexFromWindowHandle(parentHandle, controlHwnd);

            StringBuilder sb = new StringBuilder();
            int textLength = Win32API.GetWindowTextLength(parentHandle);
            Win32API.GetWindowTextA(parentHandle, sb, textLength+1);
            return new ControlIdentity(sb.ToString(), parentHandle, controlHwnd, controlIndex);
        }

        public static ControlIdentity GetControlHwnd(string windowName,int controlIndex)
        {
            IntPtr parentHandle;
            //IntPtr childHandle = findChildControl(windowName, controlIndex,out parentHandle);
            IntPtr childHandle = Win32API.GetWindowHandleFromIndex(windowName, controlIndex, out parentHandle);

            return new ControlIdentity(windowName, parentHandle, childHandle, controlIndex);
        }

        private static IntPtr findChildControl(string windowName, int childIndex, out IntPtr parentWindow)
        {
            parentWindow = FindWindow(null, windowName);
            handles.Clear();
            EnumChildWindows(parentWindow, EnumWindowsProc, 0);

            IntPtr childHwnd = handles[childIndex];
            return childHwnd;
        }

        private static void EnumWindowsProc(IntPtr hwnd, int lparam)
        {
            handles.Add(hwnd);
        }

        private static int findChildWindowIndex(IntPtr childHwnd, List<IntPtr> handles)
        {
            return handles.IndexOf(childHwnd);
        }

    }
}
