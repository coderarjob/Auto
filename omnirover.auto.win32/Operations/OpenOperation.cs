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

        public override string OperationString
        {
            get
            {
                return string.Format("Opens: {0}",Arguments[0]);
            }
        }

        public override void Execute()
        {
            if (Arguments[0] is null)
                throw new Exception("Invalid argument.");
            if (Arguments.Count == 1)
                Process.Start(Arguments[0]);
            else
                Process.Start(Arguments[0],Arguments[1]);
        }

        public OpenOperation(ControlIdentity control, string[] args) : base(control, args) { }
    }
}
