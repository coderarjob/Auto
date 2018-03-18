using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static omnirover.auto.Win32API;
namespace omnirover.auto.Operations
{
    public class FocusWindowOperation:BaseOperation
    {
        public override string Name => "FocusWindow";

        public override string OperationString
        {
            get
            {
                return string.Format("Focuses on control: ID={0}, Index:{1}, Window: '{2}'",
                    Control.ControlID, Control.Index, Control.WindowTitle);
            }
        }

        public override void Execute()
        {
            IntPtr parentHandle;
            IntPtr controlHandle = Control.GetControlHandle(out parentHandle);
            ShowWindowAndSetFocus(parentHandle);
        }

        public FocusWindowOperation(ControlIdentity control, string[] args) : base(control, args) { }
    }
}
