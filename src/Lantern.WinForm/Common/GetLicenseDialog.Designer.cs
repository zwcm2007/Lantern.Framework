namespace HouHeng.WinForm.Common
{
    partial class GetLicenseDialog
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
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLicPart4 = new System.Windows.Forms.TextBox();
            this.txtLicPart3 = new System.Windows.Forms.TextBox();
            this.txtLicPart2 = new System.Windows.Forms.TextBox();
            this.txtLicPart1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(261, 189);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(102, 39);
            this.btnCopy.TabIndex = 13;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.ForeColor = System.Drawing.Color.Black;
            this.btnGenerate.Location = new System.Drawing.Point(140, 189);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 39);
            this.btnGenerate.TabIndex = 12;
            this.btnGenerate.Text = "生成";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(456, 140);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "-";
            // 
            // txtLicPart4
            // 
            this.txtLicPart4.BackColor = System.Drawing.Color.White;
            this.txtLicPart4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLicPart4.Location = new System.Drawing.Point(367, 88);
            this.txtLicPart4.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicPart4.MaxLength = 4;
            this.txtLicPart4.Name = "txtLicPart4";
            this.txtLicPart4.ReadOnly = true;
            this.txtLicPart4.Size = new System.Drawing.Size(65, 30);
            this.txtLicPart4.TabIndex = 7;
            // 
            // txtLicPart3
            // 
            this.txtLicPart3.BackColor = System.Drawing.Color.White;
            this.txtLicPart3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLicPart3.Location = new System.Drawing.Point(278, 88);
            this.txtLicPart3.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicPart3.MaxLength = 4;
            this.txtLicPart3.Name = "txtLicPart3";
            this.txtLicPart3.ReadOnly = true;
            this.txtLicPart3.Size = new System.Drawing.Size(65, 30);
            this.txtLicPart3.TabIndex = 6;
            // 
            // txtLicPart2
            // 
            this.txtLicPart2.BackColor = System.Drawing.Color.White;
            this.txtLicPart2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLicPart2.Location = new System.Drawing.Point(189, 88);
            this.txtLicPart2.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicPart2.MaxLength = 4;
            this.txtLicPart2.Name = "txtLicPart2";
            this.txtLicPart2.ReadOnly = true;
            this.txtLicPart2.Size = new System.Drawing.Size(65, 30);
            this.txtLicPart2.TabIndex = 5;
            // 
            // txtLicPart1
            // 
            this.txtLicPart1.BackColor = System.Drawing.Color.White;
            this.txtLicPart1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLicPart1.Location = new System.Drawing.Point(101, 88);
            this.txtLicPart1.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicPart1.MaxLength = 4;
            this.txtLicPart1.Name = "txtLicPart1";
            this.txtLicPart1.ReadOnly = true;
            this.txtLicPart1.Size = new System.Drawing.Size(65, 30);
            this.txtLicPart1.TabIndex = 4;
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
            this.txtMCode.MaxLength = 24;
            this.txtMCode.Name = "txtMCode";
            this.txtMCode.Size = new System.Drawing.Size(331, 30);
            this.txtMCode.TabIndex = 2;
            this.txtMCode.TextChanged += new System.EventHandler(this.txtMCode_TextChanged);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "-";
            // 
            // GetLicenseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 261);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox1);
            this.Name = "GetLicenseDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件注册机";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLicPart4;
        private System.Windows.Forms.TextBox txtLicPart3;
        private System.Windows.Forms.TextBox txtLicPart2;
        private System.Windows.Forms.TextBox txtLicPart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}