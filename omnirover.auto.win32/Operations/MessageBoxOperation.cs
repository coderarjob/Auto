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

        public override string OperationString
        {
            get
            {
                if (Control == null)
                {
                    return string.Format("MessageBox: '{0}'", Arguments[0]);
                }
                else
                {
                    return string.Format("MessageBox: '{0}' To control: ID={1}, Index:{2}, Window: '{3}'",
                            Arguments[0], Control.ControlID, Control.Index, Control.WindowTitle);

                }
            }
        }

        public override void Execute()
        {
            if (Arguments != null)
            {
                IWin32Window owner = null;
                if (Control != null)
                {
                    IntPtr parent;
                    IntPtr control = Control.GetControlHandle(out parent);
                    owner = new WindowWrapper(parent);
                }
                string msg = Arguments[0];
                MessageBox.Show(owner,msg, "Automation",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        public MessageBoxOperation(ControlIdentity control,string[] args):base(control,args)
        {
            
        }
    }
}
