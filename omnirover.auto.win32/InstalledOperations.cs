using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace omnirover.auto
{
    public class InstalledOperations: Dictionary<string, Type>
    {
        private static InstalledOperations instance = null;

        private InstalledOperations()
        {
            this.Add("Open", Assembly.GetCallingAssembly().GetType("omnirover.auto.Operations.OpenOperation"));
            this.Add("Write", Assembly.GetCallingAssembly().GetType("omnirover.auto.Operations.WriteOperation"));
            this.Add("Click", Assembly.GetCallingAssembly().GetType("omnirover.auto.Operations.ClickOperation"));
            this.Add("FocusWindow", Assembly.GetCallingAssembly().GetType("omnirover.auto.Operations.FocusWindowOperation"));
            this.Add("Delay", Assembly.GetCallingAssembly().GetType("omnirover.auto.Operations.DelayOperation"));
            this.Add("MessageBox", Assembly.GetCallingAssembly().GetType("omnirover.auto.Operations.MessageBoxOperation"));
            this.Add("Wait for Window to Open", Assembly.GetCallingAssembly().GetType("omnirover.auto.Operations.WaitForWindowOperation"));

        }

        public static InstalledOperations GetInstance()
        {
            if (instance == null)
                instance = new InstalledOperations();
            return instance;
        }
    }
}
