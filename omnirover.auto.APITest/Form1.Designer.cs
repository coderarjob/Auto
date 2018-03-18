namespace omnirover.auto.APITest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartSpyButton = new System.Windows.Forms.Button();
            this.SetTextButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ControlIDTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.windowHwndTextBox = new System.Windows.Forms.TextBox();
            this.ListButton = new System.Windows.Forms.Button();
            this.ClickButton = new System.Windows.Forms.Button();
            this.GetTextButton = new System.Windows.Forms.Button();
            this.FindControlButton = new System.Windows.Forms.Button();
            this.ControlIndexTextBox = new System.Windows.Forms.TextBox();
            this.WindowTitleTextBox = new System.Windows.Forms.TextBox();
            this.ControlHwndLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgramList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.InsertOperationButton = new System.Windows.Forms.Button();
            this.AddOperationButton = new System.Windows.Forms.Button();
            this.ArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.CurrentControlRadioButton = new System.Windows.Forms.RadioButton();
            this.NoControlRadioButton = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.InstalledCommandsList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OpenButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.NewButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartSpyButton
            // 
            this.StartSpyButton.Location = new System.Drawing.Point(13, 13);
            this.StartSpyButton.Name = "StartSpyButton";
            this.StartSpyButton.Size = new System.Drawing.Size(75, 23);
            this.StartSpyButton.TabIndex = 0;
            this.StartSpyButton.Text = "Start Spy";
            this.StartSpyButton.UseVisualStyleBackColor = true;
            this.StartSpyButton.Click += new System.EventHandler(this.StartSpyButton_Click);
            // 
            // SetTextButton
            // 
            this.SetTextButton.Location = new System.Drawing.Point(289, 55);
            this.SetTextButton.Name = "SetTextButton";
            this.SetTextButton.Size = new System.Drawing.Size(75, 23);
            this.SetTextButton.TabIndex = 1;
            this.SetTextButton.Text = "Set text";
            this.SetTextButton.UseVisualStyleBackColor = true;
            this.SetTextButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(13, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(386, 173);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ControlIDTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.windowHwndTextBox);
            this.groupBox1.Controls.Add(this.ListButton);
            this.groupBox1.Controls.Add(this.ClickButton);
            this.groupBox1.Controls.Add(this.GetTextButton);
            this.groupBox1.Controls.Add(this.FindControlButton);
            this.groupBox1.Controls.Add(this.ControlIndexTextBox);
            this.groupBox1.Controls.Add(this.SetTextButton);
            this.groupBox1.Controls.Add(this.WindowTitleTextBox);
            this.groupBox1.Controls.Add(this.ControlHwndLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 175);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Identity";
            // 
            // ControlIDTextBox
            // 
            this.ControlIDTextBox.Location = new System.Drawing.Point(124, 149);
            this.ControlIDTextBox.Name = "ControlIDTextBox";
            this.ControlIDTextBox.Size = new System.Drawing.Size(62, 20);
            this.ControlIDTextBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Control ID:";
            // 
            // windowHwndTextBox
            // 
            this.windowHwndTextBox.Location = new System.Drawing.Point(124, 62);
            this.windowHwndTextBox.Name = "windowHwndTextBox";
            this.windowHwndTextBox.Size = new System.Drawing.Size(108, 20);
            this.windowHwndTextBox.TabIndex = 11;
            // 
            // ListButton
            // 
            this.ListButton.Location = new System.Drawing.Point(289, 140);
            this.ListButton.Name = "ListButton";
            this.ListButton.Size = new System.Drawing.Size(48, 23);
            this.ListButton.TabIndex = 10;
            this.ListButton.Text = "List";
            this.ListButton.UseVisualStyleBackColor = true;
            this.ListButton.Click += new System.EventHandler(this.ListButton_Click);
            // 
            // ClickButton
            // 
            this.ClickButton.Location = new System.Drawing.Point(289, 111);
            this.ClickButton.Name = "ClickButton";
            this.ClickButton.Size = new System.Drawing.Size(75, 23);
            this.ClickButton.TabIndex = 9;
            this.ClickButton.Text = "Click";
            this.ClickButton.UseVisualStyleBackColor = true;
            this.ClickButton.Click += new System.EventHandler(this.ClickButton_Click);
            // 
            // GetTextButton
            // 
            this.GetTextButton.Location = new System.Drawing.Point(289, 82);
            this.GetTextButton.Name = "GetTextButton";
            this.GetTextButton.Size = new System.Drawing.Size(75, 23);
            this.GetTextButton.TabIndex = 8;
            this.GetTextButton.Text = "Get text";
            this.GetTextButton.UseVisualStyleBackColor = true;
            this.GetTextButton.Click += new System.EventHandler(this.GetTextButton_Click);
            // 
            // FindControlButton
            // 
            this.FindControlButton.Location = new System.Drawing.Point(289, 29);
            this.FindControlButton.Name = "FindControlButton";
            this.FindControlButton.Size = new System.Drawing.Size(100, 23);
            this.FindControlButton.TabIndex = 4;
            this.FindControlButton.Text = "Find control";
            this.FindControlButton.UseVisualStyleBackColor = true;
            this.FindControlButton.Click += new System.EventHandler(this.FindControlButton_Click);
            // 
            // ControlIndexTextBox
            // 
            this.ControlIndexTextBox.Location = new System.Drawing.Point(124, 92);
            this.ControlIndexTextBox.Name = "ControlIndexTextBox";
            this.ControlIndexTextBox.Size = new System.Drawing.Size(62, 20);
            this.ControlIndexTextBox.TabIndex = 7;
            // 
            // WindowTitleTextBox
            // 
            this.WindowTitleTextBox.Location = new System.Drawing.Point(124, 26);
            this.WindowTitleTextBox.Name = "WindowTitleTextBox";
            this.WindowTitleTextBox.Size = new System.Drawing.Size(153, 20);
            this.WindowTitleTextBox.TabIndex = 6;
            // 
            // ControlHwndLabel
            // 
            this.ControlHwndLabel.AutoSize = true;
            this.ControlHwndLabel.Location = new System.Drawing.Point(121, 128);
            this.ControlHwndLabel.Name = "ControlHwndLabel";
            this.ControlHwndLabel.Size = new System.Drawing.Size(91, 13);
            this.ControlHwndLabel.TabIndex = 4;
            this.ControlHwndLabel.Text = "[Control HWND]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Control HWND:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Window HWND:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Control Index:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Window Title:";
            // 
            // ProgramList
            // 
            this.ProgramList.FormattingEnabled = true;
            this.ProgramList.HorizontalScrollbar = true;
            this.ProgramList.Location = new System.Drawing.Point(405, 42);
            this.ProgramList.Name = "ProgramList";
            this.ProgramList.Size = new System.Drawing.Size(535, 173);
            this.ProgramList.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteButton);
            this.groupBox2.Controls.Add(this.InsertOperationButton);
            this.groupBox2.Controls.Add(this.AddOperationButton);
            this.groupBox2.Controls.Add(this.ArgumentsTextBox);
            this.groupBox2.Controls.Add(this.CurrentControlRadioButton);
            this.groupBox2.Controls.Add(this.NoControlRadioButton);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.InstalledCommandsList);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(405, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 175);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // InsertOperationButton
            // 
            this.InsertOperationButton.Location = new System.Drawing.Point(454, 55);
            this.InsertOperationButton.Name = "InsertOperationButton";
            this.InsertOperationButton.Size = new System.Drawing.Size(75, 23);
            this.InsertOperationButton.TabIndex = 15;
            this.InsertOperationButton.Text = "Insert";
            this.InsertOperationButton.UseVisualStyleBackColor = true;
            this.InsertOperationButton.Click += new System.EventHandler(this.InsertOperationButton_Click);
            // 
            // AddOperationButton
            // 
            this.AddOperationButton.Location = new System.Drawing.Point(454, 26);
            this.AddOperationButton.Name = "AddOperationButton";
            this.AddOperationButton.Size = new System.Drawing.Size(75, 23);
            this.AddOperationButton.TabIndex = 14;
            this.AddOperationButton.Text = "Add";
            this.AddOperationButton.UseVisualStyleBackColor = true;
            this.AddOperationButton.Click += new System.EventHandler(this.AddOperationButton_Click);
            // 
            // ArgumentsTextBox
            // 
            this.ArgumentsTextBox.Location = new System.Drawing.Point(106, 127);
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            this.ArgumentsTextBox.Size = new System.Drawing.Size(255, 20);
            this.ArgumentsTextBox.TabIndex = 8;
            // 
            // CurrentControlRadioButton
            // 
            this.CurrentControlRadioButton.AutoSize = true;
            this.CurrentControlRadioButton.Location = new System.Drawing.Point(106, 92);
            this.CurrentControlRadioButton.Name = "CurrentControlRadioButton";
            this.CurrentControlRadioButton.Size = new System.Drawing.Size(115, 17);
            this.CurrentControlRadioButton.TabIndex = 7;
            this.CurrentControlRadioButton.Text = "Current control";
            this.CurrentControlRadioButton.UseVisualStyleBackColor = true;
            // 
            // NoControlRadioButton
            // 
            this.NoControlRadioButton.AutoSize = true;
            this.NoControlRadioButton.Checked = true;
            this.NoControlRadioButton.Location = new System.Drawing.Point(106, 67);
            this.NoControlRadioButton.Name = "NoControlRadioButton";
            this.NoControlRadioButton.Size = new System.Drawing.Size(49, 17);
            this.NoControlRadioButton.TabIndex = 6;
            this.NoControlRadioButton.TabStop = true;
            this.NoControlRadioButton.Text = "None";
            this.NoControlRadioButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Control:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Arguments:";
            // 
            // InstalledCommandsList
            // 
            this.InstalledCommandsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InstalledCommandsList.FormattingEnabled = true;
            this.InstalledCommandsList.Location = new System.Drawing.Point(106, 25);
            this.InstalledCommandsList.Name = "InstalledCommandsList";
            this.InstalledCommandsList.Size = new System.Drawing.Size(255, 21);
            this.InstalledCommandsList.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Operation:";
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(575, 13);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 15;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(656, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(737, 12);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 17;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(494, 13);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 18;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(454, 82);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 16;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 402);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ProgramList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.StartSpyButton);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartSpyButton;
        private System.Windows.Forms.Button SetTextButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ControlHwndLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FindControlButton;
        private System.Windows.Forms.TextBox ControlIndexTextBox;
        private System.Windows.Forms.TextBox WindowTitleTextBox;
        private System.Windows.Forms.Button GetTextButton;
        private System.Windows.Forms.Button ClickButton;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.TextBox windowHwndTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ControlIDTextBox;
        private System.Windows.Forms.ListBox ProgramList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox InstalledCommandsList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddOperationButton;
        private System.Windows.Forms.TextBox ArgumentsTextBox;
        private System.Windows.Forms.RadioButton CurrentControlRadioButton;
        private System.Windows.Forms.RadioButton NoControlRadioButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button InsertOperationButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}