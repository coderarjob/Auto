using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace omnirover.auto.APITest
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(List<IntPtr> list,IntPtr toBeSearched)
        {
            foreach (IntPtr item in list)
            {
                string itemString = string.Format($"{item.ToInt32().ToString("x")}{((item == toBeSearched) ? "*":"")}");
                listBox1.Items.Add(itemString);
            }
            return base.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
