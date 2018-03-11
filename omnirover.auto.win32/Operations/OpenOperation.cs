using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace omnirover.auto.Operations
{
    public class OpenOperation : BaseOperation
    {
        public override string Name => "Open";

        public override void Execute()
        {
            if (Args[0] is null)
                throw new Exception("Invalid argument.");
            if (Args.Count == 1)
                Process.Start(Args[0]);
            else
                Process.Start(Args[0],Args[1]);
        }

        public OpenOperation(ControlIdentity control, string[] args) : base(control, args) { }
    }
}
