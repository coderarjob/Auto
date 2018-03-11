using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static omnirover.auto.Win32API;
namespace omnirover.auto.Operations
{
    public class WriteOperation : BaseOperation
    {
        public override string Name => "Write";

        public override void Execute()
        {
            IntPtr parentHandle;
            IntPtr controlHandle = Control.GetControlHandle(out parentHandle);
            char[] cs = Args[0].ToCharArray();
            foreach (char c in cs)
                SendMessage(controlHandle, WM_CHAR, c, 1);
           
        }

        public WriteOperation(ControlIdentity control, string[] args) : base(control, args) { }

    }
}
