﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static omnirover.auto.Win32API;

namespace omnirover.auto.Operations
{
    public class ClickOperation: BaseOperation
    {
        public override string Name => "Click";
        public override string OperationString
        {
            get
            {
                return string.Format("Clickes on control: ID={0}, Index:{1}, Window: '{2}'",
                    Control.ControlID, Control.Index, Control.WindowTitle);
            }
        }

        public override void Execute()
        {
            IntPtr parentHandle;
            IntPtr controlHandle = Control.GetControlHandle(out parentHandle);
            ShowWindowAndSetFocus(parentHandle);
            SendMessage(controlHandle, BM_CLICK, 0, 0);

        }

        public ClickOperation(ControlIdentity control, string[] args) : base(control, args) { }
    }
}
