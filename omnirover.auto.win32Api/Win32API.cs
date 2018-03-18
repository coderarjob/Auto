using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace omnirover.auto
{
    public class Win32API
    {
        private static List<IntPtr> handles = new List<IntPtr>();
        public delegate void EnumChildWindowsProc(IntPtr hwnd, int lparam);

        #region APIs

        /*
        UINT WINAPI SendInput(
              _In_ UINT    nInputs,
              _In_ LPINPUT pInputs,
              _In_ int     cbSize
            ); 
        */
        [DllImport("user32")]
        public static extern int SendInput(int inputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32")]
        public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32")]
        public static extern int UpdateWindow(IntPtr hwnd);

        [DllImport("user32")]
        public static extern Boolean GetUpdateRect(IntPtr hWnd, out RECT lpRect, Boolean bErase);

        [DllImport("user32")]
        public static extern Boolean InvalidateRect(IntPtr hWnd, IntPtr lpRect, Boolean bErase);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point _lpPoint);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point p);

        [DllImport("user32.dll")]
        public static extern IntPtr GetAncestor(IntPtr Hwnd, int gaFlag);

        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPoint(IntPtr parentHandle, Point p);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextA(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int GetClassNameA(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowA(string className, string windowName);

        [DllImport("user32.dll")]
        public static extern bool SetWindowText(IntPtr handle, string title);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int GetDlgCtrlID(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDlgItem(IntPtr dlgHwnd, int cltrlID);

        [DllImport("user32.dll")]
        public static extern bool EnumChildWindows(IntPtr parentHwnd, EnumChildWindowsProc enumProc, int lParam);

        [DllImport("user32.dll")]
        public static extern bool GetWindowText(IntPtr Hwnd, StringBuilder sb, int max);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String className, String windowName);

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr WHND);

        [DllImport("user32.dll")]
        public static extern IntPtr ShowWindow(IntPtr WHND, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr BringWindowToTop(IntPtr WHND);

        [DllImport("user32.dll")]
        public static extern IntPtr SetForegroundWindow(IntPtr WHND);
        #endregion //APIs

        #region Constants
        public const int WM_CHAR = 0x0102;
        public const int BM_CLICK = 0x00F5;
        public const int WM_SETFOCUS = 0x0007;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_SHOWNORMAL = 1;
        public const int INPUT_MOUSE = 0;
        public const int INPUT_KEYBOARD = 1;
        public const int INPUT_HARDWARE = 2;
        public const int KEYEVENTF_KEYUP = 2;
        #endregion

        #region Structures

        /*
        typedef struct tagMOUSEINPUT {
          LONG      dx; //32bit
          LONG      dy; /32bit
          DWORD     mouseData; //32bit
          DWORD     dwFlags; //32bit
          DWORD     time; //32bit
          ULONG_PTR dwExtraInfo; //64bit on 64bit system else 32bit
        } MOUSEINPUT, *PMOUSEINPUT;  
        */
        [StructLayout(LayoutKind.Sequential,Pack =1)]
        public struct MOUSEINPUT
        {
            public Int32 dx;
            public Int32 dy;
            public Int32 mouseData;
            public Int32 dwFlags;
            public Int32 time;
            public Int32 dwExtraIndo;
        }

        /*
         typedef struct tagKEYBDINPUT {
          WORD      wVk; //16bit
          WORD      wScan; //16bit
          DWORD     dwFlags; //32bit
          DWORD     time; //32bit
          ULONG_PTR dwExtraInfo; //64bit
        } KEYBDINPUT, *PKEYBDINPUT;
         */
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct KEYBDINPUT
        {
            public Int16 wVK;
            public Int16 wScan;
            public Int32 dwFlags;
            public Int32 time;
            public Int32 dwExtraIndo;
        }

        /*
         typedef struct tagHARDWAREINPUT {
              DWORD uMsg; //32bit
              WORD  wParamL; //32bit
              WORD  wParamH; //32bit
            } HARDWAREINPUT, *PHARDWAREINPUT;
         */
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HARDWAREINPUT
        {
            public Int32 uMsg;
            public Int16 wParamL;
            public Int16 wParamH;
        }
        /*
        typedef struct tagINPUT {
              DWORD type;
              union {
                MOUSEINPUT    mi;
                KEYBDINPUT    ki;
                HARDWAREINPUT hi;
              };
            } INPUT, *PINPUT; 
        */
        [StructLayout(LayoutKind.Explicit,Pack =1)]
        public struct INPUT_UNION
        {
            [FieldOffset(0)] public MOUSEINPUT mi;
            [FieldOffset(0)] public KEYBDINPUT ki;
            [FieldOffset(0)] public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential,Pack =1)]
        public struct INPUT
        {
            public Int32 type;
            public INPUT_UNION input;
        }

        public struct Point
        {
            public int x;
            public int y;
        }

        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public System.Drawing.Rectangle ToRectangle()
            {
                return new System.Drawing.Rectangle(Left, Top, Width, Height);
            }

            public int Width { get { return Right - Left; } }
            public int Height { get { return Bottom - Top; } }
        }
        #endregion

        public static int SendKey(char key, bool isKeyReleased)
        {
            return SendKey(ASCIIEncoding.ASCII.GetBytes(new char[] { key })[0],isKeyReleased);
        }

        public static int SendKey(Int16 key,bool isKeyReleased)
        {
            INPUT newInput = new INPUT() ;
            newInput.type = INPUT_KEYBOARD;
            newInput.input.ki.wVK = key;
            newInput.input.ki.wScan = 0;
            newInput.input.ki.dwFlags = 0;
            if (isKeyReleased)
                newInput.input.ki.dwFlags = (1 << (KEYEVENTF_KEYUP - 1));
            newInput.input.ki.dwExtraIndo = 0;
            newInput.input.ki.time = 0;

            return SendInput(1, new INPUT[] { newInput }, Marshal.SizeOf(typeof(INPUT)));
        }

        public static int GetWindowIndexFromWindowHandle(IntPtr windowHandle,IntPtr controlhandle)
        {
            List<IntPtr> handles = new List<IntPtr>();
            GetListOfChildWindows(windowHandle, handles);
            int index = handles.FindIndex((h) => controlhandle == h);
            return index;
        }

        public static IntPtr GetWindowHandleFromIndex(string windowName,int childIndex, out IntPtr parentWindow)
        {
            List<IntPtr> handles = new List<IntPtr>();
            IntPtr wHWND = FindWindowA(null, windowName);
            GetListOfChildWindows(wHWND, handles);
            IntPtr controlHandle = handles[childIndex];

            parentWindow = wHWND;
            return controlHandle;
        }

        public static void GetListOfChildWindows(IntPtr topWindowhandle,List<IntPtr> list)
        {
            List<IntPtr> immediateChildren = new List<IntPtr>();
            handles.Clear();
            EnumChildWindows(topWindowhandle, EnumWindowsProc, 0);
            immediateChildren.AddRange(handles);

            foreach (IntPtr child in immediateChildren)
            {
                list.Add(child);
                GetListOfChildWindows(child, list);
            }
        }

        private static void EnumWindowsProc(IntPtr hwnd, int lparam)
        {
            handles.Add(hwnd);
        }

        public static void ShowWindowAndSetFocus(IntPtr HWND,int showWindowFlag = SW_RESTORE )
        {
            ShowWindow(HWND, showWindowFlag);
            SetForegroundWindow(HWND);
            SendMessage(HWND, WM_SETFOCUS, 0, 0);
        }
    }
}
