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

        public override void Execute()
        {
           if (Args.Count > 0)
            {
                int delay_ms = int.Parse(Args[0]);
                System.Threading.Thread.Sleep(delay_ms);
            }
        }


    }
}
