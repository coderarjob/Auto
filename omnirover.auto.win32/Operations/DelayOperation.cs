using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace omnirover.auto.Operations
{
    public class DelayOperation : BaseOperation
    {
        public DelayOperation(ControlIdentity control, string[] args):base(control,args)
        {
          
        }

        public override string Name => "Delay";

        public override string OperationString
        {
            get
            {
                return string.Format("Delays for '{0}' ms.",Arguments[0]);
            }
        }

        public override void Execute()
        {
           if (Arguments.Count > 0)
            {
                int delay_ms = int.Parse(Arguments[0]);
                System.Threading.Thread.Sleep(delay_ms);
            }
        }


    }
}
