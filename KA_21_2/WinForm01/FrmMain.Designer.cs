namespace WinForm01
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.TxtSource = new System.Windows.Forms.TextBox();
            this.TxtDestination = new System.Windows.Forms.TextBox();
            this.TxtUhr = new System.Windows.Forms.TextBox();
            this.TmrUhr = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BtnCopy
            // 
            this.BtnCopy.BackColor = System.Drawing.Color.Red;
            this.BtnCopy.ForeColor = System.Drawing.Color.White;
            this.BtnCopy.Location = new System.Drawing.Point(12, 10);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(94, 29);
            this.BtnCopy.TabIndex = 0;
            this.BtnCopy.Text = "Copy";
            this.BtnCopy.UseVisualStyleBackColor = false;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // TxtSource
            // 
            this.TxtSource.Location = new System.Drawing.Point(112, 12);
            this.TxtSource.Name = "TxtSource";
            this.TxtSource.Size = new System.Drawing.Size(125, 27);
            this.TxtSource.TabIndex = 1;
            this.TxtSource.TextChanged += new System.EventHandler(this.TxtSource_TextChanged);
            this.TxtSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSource_KeyPress);
            // 
            // TxtDestination
            // 
            this.TxtDestination.Location = new System.Drawing.Point(243, 12);
            this.TxtDestination.Name = "TxtDestination";
            this.TxtDestination.Size = new System.Drawing.Size(125, 27);
            this.TxtDestination.TabIndex = 2;
            // 
            // TxtUhr
            // 
            this.TxtUhr.Location = new System.Drawing.Point(603, 10);
            this.TxtUhr.Name = "TxtUhr";
            this.TxtUhr.ReadOnly = true;
            this.TxtUhr.Size = new System.Drawing.Size(185, 27);
            this.TxtUhr.TabIndex = 3;
            // 
            // TmrUhr
            // 
            this.TmrUhr.Enabled = true;
            this.TmrUhr.Interval = 1000;
            this.TmrUhr.Tick += new System.EventHandler(this.TmrUhr_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtUhr);
            this.Controls.Add(this.TxtDestination);
            this.Controls.Add(this.TxtSource);
            this.Controls.Add(this.BtnCopy);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.TextBox TxtSource;
        private System.Windows.Forms.TextBox TxtDestination;
        private System.Windows.Forms.TextBox TxtUhr;
        private System.Windows.Forms.Timer TmrUhr;
    }
}
