
namespace DangKe.WinForm.Sample
{
    partial class Form2
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
            this.hhComboBox1 = new DangKe.WinForm.Components.HhComboBox();
            this.hhButton1 = new DangKe.WinForm.Components.HhButton();
            this.SuspendLayout();
            // 
            // hhComboBox1
            // 
            this.hhComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hhComboBox1.FormattingEnabled = true;
            this.hhComboBox1.Location = new System.Drawing.Point(98, 49);
            this.hhComboBox1.Name = "hhComboBox1";
            this.hhComboBox1.Size = new System.Drawing.Size(195, 32);
            this.hhComboBox1.TabIndex = 0;
            // 
            // hhButton1
            // 
            this.hhButton1.Location = new System.Drawing.Point(313, 42);
            this.hhButton1.Name = "hhButton1";
            this.hhButton1.Size = new System.Drawing.Size(130, 45);
            this.hhButton1.TabIndex = 1;
            this.hhButton1.Text = "测试";
            this.hhButton1.UseVisualStyleBackColor = true;
            this.hhButton1.Click += new System.EventHandler(this.hhButton1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hhButton1);
            this.Controls.Add(this.hhComboBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.HhComboBox hhComboBox1;
        private Components.HhButton hhButton1;
    }
}