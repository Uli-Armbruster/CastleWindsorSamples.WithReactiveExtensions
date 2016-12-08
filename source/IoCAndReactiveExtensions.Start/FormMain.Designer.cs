namespace IoCAndReactiveExtensions.Start
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.ControlOpenWindow1 = new System.Windows.Forms.Button();
            this.ControlOpenWindow2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Messages from all daemons";
            // 
            // ControlOpenWindow1
            // 
            this.ControlOpenWindow1.Location = new System.Drawing.Point(155, 28);
            this.ControlOpenWindow1.Name = "ControlOpenWindow1";
            this.ControlOpenWindow1.Size = new System.Drawing.Size(75, 23);
            this.ControlOpenWindow1.TabIndex = 3;
            this.ControlOpenWindow1.Text = "Daemon1";
            this.ControlOpenWindow1.UseVisualStyleBackColor = true;
            this.ControlOpenWindow1.Click += new System.EventHandler(this.ControlOpenWindow1_Click);
            // 
            // ControlOpenWindow2
            // 
            this.ControlOpenWindow2.Location = new System.Drawing.Point(305, 28);
            this.ControlOpenWindow2.Name = "ControlOpenWindow2";
            this.ControlOpenWindow2.Size = new System.Drawing.Size(75, 23);
            this.ControlOpenWindow2.TabIndex = 4;
            this.ControlOpenWindow2.Text = "Daemon2";
            this.ControlOpenWindow2.UseVisualStyleBackColor = true;
            this.ControlOpenWindow2.Click += new System.EventHandler(this.ControlOpenWindow2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 86);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(556, 69);
            this.listBox1.TabIndex = 7;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(12, 196);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(556, 186);
            this.listBox2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "System Messages";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 456);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ControlOpenWindow2);
            this.Controls.Add(this.ControlOpenWindow1);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ControlOpenWindow1;
        private System.Windows.Forms.Button ControlOpenWindow2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
    }
}

