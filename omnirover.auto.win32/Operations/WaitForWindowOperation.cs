﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace omnirover.auto.Operations
{
    class WaitForWindowOperation : BaseOperation
    {
        public override string Name => "Wait for Window to Open";
        public override string OperationString
        {
            get
            {
                return string.Format("Waits for window: '{0}' for max of '{1}' seconds.",
                    Control.WindowTitle,getTimeoutTime());
            }
        }

        public override void Execute()
        {
            
            Boolean windowFound = false;
            float timeout_seconds = getTimeoutTime();
            while(timeout_seconds > 0 && windowFound == false)
            {
                IntPtr handle = Win32API.FindWindowA(null, Control.WindowTitle);
                windowFound = (handle != IntPtr.Zero);
                System.Threading.Thread.Sleep(100);
                timeout_seconds -= 0.1f;
            }
        }

        private float getTimeoutTime()
        {
            float timeout_seconds = 10.0f;
            if (Arguments != null && Arguments.Count > 0)
            {
                int parsedNumber;
                if (int.TryParse(Arguments[0], out parsedNumber))
                    timeout_seconds = (float)parsedNumber;
            }
            return timeout_seconds;
        }

        public WaitForWindowOperation(ControlIdentity control, string[] args) : base(control, args) { }

    }
}
