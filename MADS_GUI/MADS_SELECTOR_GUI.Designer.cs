namespace MADS_GUI
{
    partial class MainWindow
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
            this.selectedModules = new System.Windows.Forms.ListBox();
            this.avaliableModules = new System.Windows.Forms.ListBox();
            this.Right_Button = new System.Windows.Forms.Button();
            this.Left_Button = new System.Windows.Forms.Button();
            this.rooms = new System.Windows.Forms.CheckedListBox();
            this.Load_Script_Button = new System.Windows.Forms.Button();
            this.Save_Script_Button = new System.Windows.Forms.Button();
            this.Up_Button = new System.Windows.Forms.Button();
            this.Down_Button = new System.Windows.Forms.Button();
            this.About_Button = new System.Windows.Forms.Button();
            this.New_Script_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectedModules
            // 
            this.selectedModules.FormattingEnabled = true;
            this.selectedModules.Location = new System.Drawing.Point(329, 53);
            this.selectedModules.Name = "selectedModules";
            this.selectedModules.Size = new System.Drawing.Size(144, 225);
            this.selectedModules.TabIndex = 0;
            this.selectedModules.SelectedIndexChanged += new System.EventHandler(this.runningModules_SelectedIndexChanged);
            // 
            // avaliableModules
            // 
            this.avaliableModules.FormattingEnabled = true;
            this.avaliableModules.Location = new System.Drawing.Point(146, 53);
            this.avaliableModules.Name = "avaliableModules";
            this.avaliableModules.Size = new System.Drawing.Size(144, 225);
            this.avaliableModules.TabIndex = 1;
            this.avaliableModules.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Right_Button
            // 
            this.Right_Button.Location = new System.Drawing.Point(296, 53);
            this.Right_Button.Name = "Right_Button";
            this.Right_Button.Size = new System.Drawing.Size(27, 23);
            this.Right_Button.TabIndex = 2;
            this.Right_Button.Text = "->";
            this.Right_Button.UseVisualStyleBackColor = true;
            this.Right_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Left_Button
            // 
            this.Left_Button.Location = new System.Drawing.Point(296, 82);
            this.Left_Button.Name = "Left_Button";
            this.Left_Button.Size = new System.Drawing.Size(27, 23);
            this.Left_Button.TabIndex = 3;
            this.Left_Button.Text = "<-";
            this.Left_Button.UseVisualStyleBackColor = true;
            this.Left_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // rooms
            // 
            this.rooms.FormattingEnabled = true;
            this.rooms.Location = new System.Drawing.Point(4, 53);
            this.rooms.Name = "rooms";
            this.rooms.Size = new System.Drawing.Size(136, 229);
            this.rooms.TabIndex = 5;
            this.rooms.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // Load_Script_Button
            // 
            this.Load_Script_Button.Location = new System.Drawing.Point(4, 2);
            this.Load_Script_Button.Name = "Load_Script_Button";
            this.Load_Script_Button.Size = new System.Drawing.Size(102, 23);
            this.Load_Script_Button.TabIndex = 6;
            this.Load_Script_Button.Text = "Load Script";
            this.Load_Script_Button.UseVisualStyleBackColor = true;
            this.Load_Script_Button.Click += new System.EventHandler(this.button3_Click);
            // 
            // Save_Script_Button
            // 
            this.Save_Script_Button.Location = new System.Drawing.Point(422, 12);
            this.Save_Script_Button.Name = "Save_Script_Button";
            this.Save_Script_Button.Size = new System.Drawing.Size(102, 23);
            this.Save_Script_Button.TabIndex = 7;
            this.Save_Script_Button.Text = "Save Script";
            this.Save_Script_Button.UseVisualStyleBackColor = true;
            this.Save_Script_Button.Click += new System.EventHandler(this.button4_Click);
            // 
            // Up_Button
            // 
            this.Up_Button.Location = new System.Drawing.Point(479, 53);
            this.Up_Button.Name = "Up_Button";
            this.Up_Button.Size = new System.Drawing.Size(45, 23);
            this.Up_Button.TabIndex = 8;
            this.Up_Button.Text = "Up";
            this.Up_Button.UseVisualStyleBackColor = true;
            this.Up_Button.Click += new System.EventHandler(this.button5_Click);
            // 
            // Down_Button
            // 
            this.Down_Button.Location = new System.Drawing.Point(479, 82);
            this.Down_Button.Name = "Down_Button";
            this.Down_Button.Size = new System.Drawing.Size(45, 23);
            this.Down_Button.TabIndex = 9;
            this.Down_Button.Text = "Down";
            this.Down_Button.UseVisualStyleBackColor = true;
            this.Down_Button.Click += new System.EventHandler(this.button6_Click);
            // 
            // About_Button
            // 
            this.About_Button.Location = new System.Drawing.Point(479, 259);
            this.About_Button.Name = "About_Button";
            this.About_Button.Size = new System.Drawing.Size(45, 23);
            this.About_Button.TabIndex = 10;
            this.About_Button.Text = "About";
            this.About_Button.UseVisualStyleBackColor = true;
            this.About_Button.Click += new System.EventHandler(this.About_Button_Click);
            // 
            // New_Script_Button
            // 
            this.New_Script_Button.Location = new System.Drawing.Point(4, 28);
            this.New_Script_Button.Name = "New_Script_Button";
            this.New_Script_Button.Size = new System.Drawing.Size(102, 23);
            this.New_Script_Button.TabIndex = 11;
            this.New_Script_Button.Text = "New Script";
            this.New_Script_Button.UseVisualStyleBackColor = true;
            this.New_Script_Button.Click += new System.EventHandler(this.New_Script_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 284);
            this.Controls.Add(this.New_Script_Button);
            this.Controls.Add(this.About_Button);
            this.Controls.Add(this.Down_Button);
            this.Controls.Add(this.Up_Button);
            this.Controls.Add(this.Save_Script_Button);
            this.Controls.Add(this.Load_Script_Button);
            this.Controls.Add(this.rooms);
            this.Controls.Add(this.Left_Button);
            this.Controls.Add(this.Right_Button);
            this.Controls.Add(this.avaliableModules);
            this.Controls.Add(this.selectedModules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Module Selector";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox selectedModules;
        private System.Windows.Forms.ListBox avaliableModules;
        private System.Windows.Forms.Button Right_Button;
        private System.Windows.Forms.Button Left_Button;
        private System.Windows.Forms.CheckedListBox rooms;
        private System.Windows.Forms.Button Load_Script_Button;
        private System.Windows.Forms.Button Save_Script_Button;
        private System.Windows.Forms.Button Up_Button;
        private System.Windows.Forms.Button Down_Button;
        private System.Windows.Forms.Button About_Button;
        private System.Windows.Forms.Button New_Script_Button;
    }
}

