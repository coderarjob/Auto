using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static omnirover.auto.Win32API;

namespace omnirover.auto.APITest
{
    public partial class Form1 : Form
    {
        ControlIdentity currentIdentity = null;
        ExecutionList currentProgram = new ExecutionList();

        bool _continueSpying = false;
        List<IntPtr> handles;
        List<Int32> controlIDs;
        public Form1()
        {
            InitializeComponent();
            handles = new List<IntPtr>();
            controlIDs = new List<Int32>();
        }

        void Spy()
        {
            StringBuilder sbTitle = new StringBuilder();
            StringBuilder sbClass = new StringBuilder();
            handles.Clear();
            controlIDs.Clear();

            listBox1.Items.Clear();
            IntPtr prevhandle = IntPtr.Zero;
            while (_continueSpying)
            {
                Win32API.Point p;
                GetCursorPos(out p);

                IntPtr handle = Win32API.WindowFromPoint(p);//ChildWindowFromPoint(GetAncestor(WindowFromPoint(p), 2), p);

                if (handle != prevhandle)
                {
                    int dlgID = GetDlgCtrlID(handle);
                    listBox1.Items.Add(string.Format("{0:X} / {1}", handle.ToInt64(), dlgID));

                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    handles.Add(handle);
                    controlIDs.Add(dlgID);

                    WindowGraphics.RevomeRectangle(prevhandle);
                    WindowGraphics.DrawRectangle(handle);
                }
                prevhandle = handle;
                Application.DoEvents();
            }
        }

        private void StartSpyButton_Click(object sender, EventArgs e)
        {
            if (_continueSpying == false)
            {
                StartSpyButton.Text = "Stop Spy";
                _continueSpying = true;
                Spy();
            }
            else
            {
                _continueSpying = false;
                StartSpyButton.Text = "Start Spy";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SendMessage(handles[listBox1.SelectedIndex], WM_CHAR, 65, 10);
            //IntPtr dlgHwnd = FindWindowA(null,"Calculator");
            //if (dlgHwnd.ToInt32() == 0)
            //{
            //    MessageBox.Show("Calculator not found");
            //    return;
            //}

            //int controlID = 186;
            //IntPtr cntrlHwnd = GetDlgItem(dlgHwnd,controlID);
            //MessageBox.Show(cntrlHwnd.ToInt32().ToString());
            SendMessage(currentIdentity.GetControlHandle(), WM_CHAR, '1', 10);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1 || _continueSpying) return;

            IntPtr controlHwnd = handles[listBox1.SelectedIndex];
            int id = controlIDs[listBox1.SelectedIndex];

            currentIdentity = ControlIdentity.Create(controlHwnd, id);
            FillControlInformationIntoUI(currentIdentity);
        }

        private void FillControlInformationIntoUI(ControlIdentity identity)
        {
            WindowTitleTextBox.Text = identity.WindowTitle;
            ControlIndexTextBox.Text = identity.Index.ToString();
            ControlIDTextBox.Text = identity.ControlID.ToString();

            IntPtr parent;
            IntPtr control = identity.GetControlHandle(out parent);
            windowHwndTextBox.Text = parent.ToString("x");
            ControlHwndLabel.Text = control.ToString("x");
        }

        private void FindControlButton_Click(object sender, EventArgs e)
        {
            
            currentIdentity = new ControlIdentity(WindowTitleTextBox.Text,
                Int32.Parse( ControlIndexTextBox.Text),
                Int32.Parse(ControlIDTextBox.Text));
            FillControlInformationIntoUI(currentIdentity);
        }

        private void GetTextButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            GetWindowTextA(currentIdentity.GetControlHandle(), sb, 255);
            MessageBox.Show(sb.ToString());
        }

        private void ClickButton_Click(object sender, EventArgs e)
        {
            //SetFocus(currentIdentity.WindowHwnd);
            //ShowWindow(currentIdentity.WindowHwnd, 1);
            //ShowWindowAndSetFocus(currentIdentity.WindowHwnd);
            //SendMessage(currentIdentity.ControlHwnd, BM_CLICK, 0, 0);
        }

        private void ListButton_Click(object sender, EventArgs e)
        {
            IntPtr windowHandle;
            windowHandle = new IntPtr(Int32.Parse(windowHwndTextBox.Text,System.Globalization.NumberStyles.HexNumber));

            List<IntPtr> list = new List<IntPtr>();
            Win32API.GetListOfChildWindows(windowHandle, list);
            Form4 listWindow = new Form4();
            listWindow.ShowDialog(list,
                    new IntPtr(int.Parse(ControlHwndLabel.Text,System.Globalization.NumberStyles.HexNumber)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddInstalledOperationsToList();
        }

        private void AddInstalledOperationsToList()
        {
            foreach (var op in InstalledOperations.GetInstance())
            {
                InstalledCommandsList.Items.Add(op.Key);
            }
        }

        private void ReloadProgramList()
        {
            ProgramList.Items.Clear();
            foreach (BaseOperation step in currentProgram)
            {
                //string listItemString = String.Format("{0} > window:'{1}' control:'{2}' Arg:'{3}'",
                //    step.Name,
                //    ((step.Control != null) ? step.Control.WindowTitle : "n/a"),
                //    ((step.Control != null) ? string.Format($"ID:{step.Control.ControlID}, Index:{step.Control.Index}") : "n/a"),
                //    ((step.Arguments != null) ? string.Join(",", step.Arguments.ToArray()) : "n/a"));

                ProgramList.Items.Add(step.OperationString);
            }
        }

        private BaseOperation CreateOperationUsingCurrentUIValues()
        {
            BaseOperation newOperation;
            String OperationName = InstalledCommandsList.Text;
            ControlIdentity control = null;
            if (CurrentControlRadioButton.Checked)
                control = currentIdentity;
            string[] args = ArgumentsTextBox.Text.Split(',');

            newOperation = OperationFactory.CreateOperation(OperationName, control, args);
            return newOperation;
        }
        private void AddOperationButton_Click(object sender, EventArgs e)
        {
            currentProgram.Add(CreateOperationUsingCurrentUIValues());
            ReloadProgramList();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            int listIndex = 0;
            foreach (BaseOperation thisOperation in currentProgram)
            {
                ProgramList.SelectedIndex = listIndex;
                thisOperation.Execute();
                //System.Threading.Thread.Sleep(1000);
                listIndex++;
            }

            ProgramList.ClearSelected();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Automation files|*.auto";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                currentProgram.Save(saveFileDialog1.FileName);
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Automation files|*.auto";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentProgram = ExecutionList.OpenFile(openFileDialog1.FileName);
                ReloadProgramList();
            }
        }

        private void InsertOperationButton_Click(object sender, EventArgs e)
        {
            int SelectedIndex = ProgramList.SelectedIndex;
            if (SelectedIndex != -1)
            {
                currentProgram.Insert(SelectedIndex, CreateOperationUsingCurrentUIValues());
                ReloadProgramList();
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            currentProgram.Clear();
            ReloadProgramList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ProgramList.SelectedIndex > -1)
            {
                currentProgram.RemoveAt(ProgramList.SelectedIndex);
                ReloadProgramList();
            }
        }
    }
}
