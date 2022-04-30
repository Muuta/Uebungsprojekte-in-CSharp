namespace Taschenrechner
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
            this.LblZahl1 = new System.Windows.Forms.Label();
            this.LblZahl2 = new System.Windows.Forms.Label();
            this.LblZahl3 = new System.Windows.Forms.Label();
            this.TxtZahl1 = new System.Windows.Forms.TextBox();
            this.TxtErgebnis = new System.Windows.Forms.TextBox();
            this.TxtZahl2 = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnDiv = new System.Windows.Forms.Button();
            this.BtnMul = new System.Windows.Forms.Button();
            this.BtnSub = new System.Windows.Forms.Button();
            this.BtnMod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblZahl1
            // 
            this.LblZahl1.AutoSize = true;
            this.LblZahl1.Location = new System.Drawing.Point(21, 16);
            this.LblZahl1.Name = "LblZahl1";
            this.LblZahl1.Size = new System.Drawing.Size(50, 20);
            this.LblZahl1.TabIndex = 0;
            this.LblZahl1.Text = "Zahl 1";
            // 
            // LblZahl2
            // 
            this.LblZahl2.AutoSize = true;
            this.LblZahl2.Location = new System.Drawing.Point(21, 49);
            this.LblZahl2.Name = "LblZahl2";
            this.LblZahl2.Size = new System.Drawing.Size(50, 20);
            this.LblZahl2.TabIndex = 1;
            this.LblZahl2.Text = "Zahl 2";
            // 
            // LblZahl3
            // 
            this.LblZahl3.AutoSize = true;
            this.LblZahl3.Location = new System.Drawing.Point(21, 82);
            this.LblZahl3.Name = "LblZahl3";
            this.LblZahl3.Size = new System.Drawing.Size(66, 20);
            this.LblZahl3.TabIndex = 2;
            this.LblZahl3.Text = "Ergebnis";
            // 
            // TxtZahl1
            // 
            this.TxtZahl1.Location = new System.Drawing.Point(89, 13);
            this.TxtZahl1.Name = "TxtZahl1";
            this.TxtZahl1.Size = new System.Drawing.Size(125, 27);
            this.TxtZahl1.TabIndex = 3;
            // 
            // TxtErgebnis
            // 
            this.TxtErgebnis.Location = new System.Drawing.Point(89, 79);
            this.TxtErgebnis.Name = "TxtErgebnis";
            this.TxtErgebnis.ReadOnly = true;
            this.TxtErgebnis.Size = new System.Drawing.Size(125, 27);
            this.TxtErgebnis.TabIndex = 4;
            // 
            // TxtZahl2
            // 
            this.TxtZahl2.Location = new System.Drawing.Point(89, 46);
            this.TxtZahl2.Name = "TxtZahl2";
            this.TxtZahl2.Size = new System.Drawing.Size(125, 27);
            this.TxtZahl2.TabIndex = 5;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(220, 12);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(94, 29);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "+";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnDiv
            // 
            this.BtnDiv.Location = new System.Drawing.Point(320, 47);
            this.BtnDiv.Name = "BtnDiv";
            this.BtnDiv.Size = new System.Drawing.Size(94, 29);
            this.BtnDiv.TabIndex = 7;
            this.BtnDiv.Text = "/";
            this.BtnDiv.UseVisualStyleBackColor = true;
            this.BtnDiv.Click += new System.EventHandler(this.BtnDiv_Click);
            // 
            // BtnMul
            // 
            this.BtnMul.Location = new System.Drawing.Point(220, 47);
            this.BtnMul.Name = "BtnMul";
            this.BtnMul.Size = new System.Drawing.Size(94, 29);
            this.BtnMul.TabIndex = 8;
            this.BtnMul.Text = "x";
            this.BtnMul.UseVisualStyleBackColor = true;
            this.BtnMul.Click += new System.EventHandler(this.BtnMul_Click);
            // 
            // BtnSub
            // 
            this.BtnSub.Location = new System.Drawing.Point(320, 12);
            this.BtnSub.Name = "BtnSub";
            this.BtnSub.Size = new System.Drawing.Size(94, 29);
            this.BtnSub.TabIndex = 9;
            this.BtnSub.Text = "-";
            this.BtnSub.UseVisualStyleBackColor = true;
            this.BtnSub.Click += new System.EventHandler(this.BtnSub_Click);
            // 
            // BtnMod
            // 
            this.BtnMod.Location = new System.Drawing.Point(220, 82);
            this.BtnMod.Name = "BtnMod";
            this.BtnMod.Size = new System.Drawing.Size(94, 29);
            this.BtnMod.TabIndex = 10;
            this.BtnMod.Text = "Mod";
            this.BtnMod.UseVisualStyleBackColor = true;
            this.BtnMod.Click += new System.EventHandler(this.BtnMod_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 120);
            this.Controls.Add(this.BtnMod);
            this.Controls.Add(this.BtnSub);
            this.Controls.Add(this.BtnMul);
            this.Controls.Add(this.BtnDiv);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.TxtZahl2);
            this.Controls.Add(this.TxtErgebnis);
            this.Controls.Add(this.TxtZahl1);
            this.Controls.Add(this.LblZahl3);
            this.Controls.Add(this.LblZahl2);
            this.Controls.Add(this.LblZahl1);
            this.Name = "FrmMain";
            this.Text = "Taschenrechner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblZahl1;
        private System.Windows.Forms.Label LblZahl2;
        private System.Windows.Forms.Label LblZahl3;
        private System.Windows.Forms.TextBox TxtZahl1;
        private System.Windows.Forms.TextBox TxtErgebnis;
        private System.Windows.Forms.TextBox TxtZahl2;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnDiv;
        private System.Windows.Forms.Button BtnMul;
        private System.Windows.Forms.Button BtnSub;
        private System.Windows.Forms.Button BtnMod;
    }
}
