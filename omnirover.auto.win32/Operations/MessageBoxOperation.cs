using System.Windows.Forms;
using System;

namespace omnirover.auto.Operations
{
    public class MessageBoxOperation : BaseOperation
    {
        internal class WindowWrapper : IWin32Window
        {
            private IntPtr _handle;
            public WindowWrapper(IntPtr whandle)
            {
                _handle = whandle;
            }
            public IntPtr Handle => _handle;
        }

        public override string Name => "MessageBox";

        public override void Execute()
        {
            if (Args != null)
            {
                IWin32Window owner = null;
                if (Control != null)
                {
                    IntPtr parent;
                    IntPtr control = Control.GetControlHandle(out parent);
                    owner = new WindowWrapper(parent);
                }
                string msg = Args[0];
                MessageBox.Show(owner,msg, "Automation",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        public MessageBoxOperation(ControlIdentity control,string[] args):base(control,args)
        {
            
        }
    }
}
