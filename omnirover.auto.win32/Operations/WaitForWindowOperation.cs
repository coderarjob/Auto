using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace omnirover.auto.Operations
{
    class WaitForWindowOperation : BaseOperation
    {
        public override string Name => "Wait for Window to Open";

        public override void Execute()
        {
            float timeout_seconds = 10.0f;
            Boolean windowFound = false;

            if (Args != null && Args.Count > 0 ) {
                int parsedNumber;
                if (int.TryParse(Args[0], out parsedNumber))
                    timeout_seconds = (float)parsedNumber;
            }
            while(timeout_seconds > 0 && windowFound == false)
            {
                IntPtr handle = Win32API.FindWindowA(null, Control.WindowTitle);
                windowFound = (handle != IntPtr.Zero);
                System.Threading.Thread.Sleep(100);
                timeout_seconds -= 0.1f;
            }
        }

        public WaitForWindowOperation(ControlIdentity control, string[] args) : base(control, args) { }

    }
}
