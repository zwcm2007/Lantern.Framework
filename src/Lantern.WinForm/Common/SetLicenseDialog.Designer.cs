namespace HouHeng.WinForm.Common
{
    partial class SetLicenseDialog
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLicPart4 = new System.Windows.Forms.TextBox();
            this.txtLicPart3 = new System.Windows.Forms.TextBox();
            this.txtLicPart2 = new System.Windows.Forms.TextBox();
            this.txtLicPart1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(258, 173);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 39);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "以后再用";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReg
            // 
            this.btnReg.Enabled = false;
            this.btnReg.ForeColor = System.Drawing.Color.Black;
            this.btnReg.Location = new System.Drawing.Point(137, 173);
            this.btnReg.Margin = new System.Windows.Forms.Padding(4);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(100, 39);
            this.btnReg.TabIndex = 9;
            this.btnReg.Text = "注册";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLicPart4);
            this.groupBox1.Controls.Add(this.txtLicPart3);
            this.groupBox1.Controls.Add(this.txtLicPart2);
            this.groupBox1.Controls.Add(this.txtLicPart1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(449, 142);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "-";
            // 
            // txtLicPart4
            // 
            this.txtLicPart4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLicPart4.Location = new System.Drawing.Point(361, 88);
            this.txtLicPart4.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicPart4.MaxLength = 4;
            this.txtLicPart4.Name = "txtLicPart4";
            this.txtLicPart4.Size = new System.Drawing.Size(65, 30);
            this.txtLicPart4.TabIndex = 7;
            this.txtLicPart4.TextChanged += new System.EventHandler(this.txtLicPart_TextChanged);
            this.txtLicPart4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicPart_KeyPress);
            // 
            // txtLicPart3
            // 
            this.txtLicPart3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLicPart3.Location = new System.Drawing.Point(273, 88);
            this.txtLicPart3.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicPart3.MaxLength = 4;
            this.txtLicPart3.Name = "txtLicPart3";
            this.txtLicPart3.Size = new System.Drawing.Size(65, 30);
            this.txtLicPart3.TabIndex = 6;
            this.txtLicPart3.TextChanged += new System.EventHandler(this.txtLicPart_TextChanged);
            this.txtLicPart3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicPart_KeyPress);
            // 
            // txtLicPart2
            // 
            this.txtLicPart2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLicPart2.Location = new System.Drawing.Point(186, 88);
            this.txtLicPart2.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicPart2.MaxLength = 4;
            this.txtLicPart2.Name = "txtLicPart2";
            this.txtLicPart2.Size = new System.Drawing.Size(65, 30);
            this.txtLicPart2.TabIndex = 5;
            this.txtLicPart2.TextChanged += new System.EventHandler(this.txtLicPart_TextChanged);
            this.txtLicPart2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicPart_KeyPress);
            // 
            // txtLicPart1
            // 
            this.txtLicPart1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLicPart1.Location = new System.Drawing.Point(101, 88);
            this.txtLicPart1.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicPart1.MaxLength = 4;
            this.txtLicPart1.Name = "txtLicPart1";
            this.txtLicPart1.Size = new System.Drawing.Size(65, 30);
            this.txtLicPart1.TabIndex = 4;
            this.txtLicPart1.TextChanged += new System.EventHandler(this.txtLicPart_TextChanged);
            this.txtLicPart1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicPart_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "序列号：";
            // 
            // txtMCode
            // 
            this.txtMCode.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMCode.Location = new System.Drawing.Point(101, 36);
            this.txtMCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtMCode.Name = "txtMCode";
            this.txtMCode.ReadOnly = true;
            this.txtMCode.Size = new System.Drawing.Size(325, 30);
            this.txtMCode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "机器码：";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LicenseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 236);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.groupBox1);
            this.Name = "LicenseDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件注册";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLicPart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLicPart4;
        private System.Windows.Forms.TextBox txtLicPart3;
        private System.Windows.Forms.TextBox txtLicPart2;
        private System.Windows.Forms.Timer timer1;
    }
}