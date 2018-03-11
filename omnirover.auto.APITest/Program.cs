using System.Windows.Forms;
using System;
namespace omnirover.auto.APITest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ExecutionList l = new ExecutionList
            {
                { OperationFactory.CreateOperation("Open",
                            null,
                            new string[] { "Notepad.exe" })
                },

                { OperationFactory.CreateOperation("Write",
                            new auto.ControlIdentity("Untitled - Notepad", 0,15),
                            new string[] { "Arjob Mukherjee" })
                },

                { OperationFactory.CreateOperation("Click",
                            new auto.ControlIdentity("Form2", 1,0), 
                            null)
                },

                 { OperationFactory.CreateOperation("Click",
                            new auto.ControlIdentity("Form2", 0,0),
                            null)
                }

            };
            //foreach (BaseOperation item in l)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    item.Execute();
            //}


            Application.Run(new Form1());
            //IntPtr hndl = FindWindowA(0, "Untitled - Notepad");
            ////SetWindowText(hndl, "Arjob");
            //MessageBox.Show(hndl.ToInt32().ToString());
            //SendMessage(hndl, WM_CHAR, 65, 10);
        }

        private static void Foo(string[] args)
        {

        }
    }
}
