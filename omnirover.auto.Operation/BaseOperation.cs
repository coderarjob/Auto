using System;
using System.Collections.Generic;

namespace omnirover.auto
{
    public abstract class BaseOperation
    {       
        public ControlIdentity Control { get; protected set; }
        abstract public String Name { get; }
        abstract public void Execute();
        public String Value { get; protected set; }
        public List<String> Arguments { get => Args; }
        public List<String> Args = null;

        public BaseOperation(ControlIdentity control,string[] args)
        {
            Control = control;
            if (!(args is null))
                Args = new List<string>(args);
        }
    }
}
