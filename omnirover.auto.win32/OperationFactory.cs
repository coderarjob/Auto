using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace omnirover.auto
{
    public class OperationFactory
    {
        public static BaseOperation CreateOperation(string OperationName,ControlIdentity contol,string[] args)
        {
            Type t = InstalledOperations.GetInstance()[OperationName];
            Object o  = Activator.CreateInstance(t,new object[] { contol, args });
            if (o is BaseOperation bo) return bo;
            throw new Exception($"Invalid Operation '{OperationName}'");
        }
    }
}
