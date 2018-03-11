using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static omnirover.auto.Win32API;

namespace omnirover.auto
{
    public class ControlIdentity
    {
        public Int32 Index;
        public Int32 ControlID;
        public string WindowTitle;

        public ControlIdentity(string windowTitle,int index, Int32 id)
        {
            this.Index = index;
            this.WindowTitle = windowTitle;
            this.ControlID = id;
        }

        public IntPtr GetControlHandle()
        {
            IntPtr parent;
            return GetControlHandle(out parent);
        }

        public IntPtr GetControlHandle(out IntPtr parentHandle)
        {
            IntPtr controlhandle;
            IntPtr windowHandle;

            //attempt using GetDlgItem
            Console.WriteLine("Trying using GetDlgItem...");
            windowHandle = Win32API.FindWindowA(null, this.WindowTitle);
            controlhandle = Win32API.GetDlgItem(windowHandle, this.ControlID);

            //If previous attempt failed, then try getting handle from Index
            if (controlhandle == IntPtr.Zero)
            {
                Console.WriteLine("Trying using GetWindowHandleFromIndex...");
                if (this.Index == -1)
                {
                    controlhandle = windowHandle;
                }
                else
                {
                    controlhandle = Win32API.GetWindowHandleFromIndex(this.WindowTitle, this.Index, out windowHandle);
                }
            }

            Console.WriteLine($"Got Handle {controlhandle.ToString("x")}");

           
            parentHandle = windowHandle;
            return controlhandle;
        }

        public static ControlIdentity Create(IntPtr controlHandle,Int32 controlID)
        {
            ControlIdentity identity;
            IntPtr parent = Win32API.GetAncestor(controlHandle, 2);
            int titleLength = GetWindowTextLength(parent);
            StringBuilder title = new StringBuilder();
            GetWindowTextA(parent, title, titleLength+1);

            //get controlID
            int id = Win32API.GetDlgCtrlID(controlHandle);

            //get index;
            int index = Win32API.GetWindowIndexFromWindowHandle(parent, controlHandle);

            identity = new ControlIdentity(title.ToString(), index, id);
            return identity;
        }
    }
}
