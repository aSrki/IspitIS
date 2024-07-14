
namespace NNmreze
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
            this.listBoxIspis = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxIspis
            // 
            this.listBoxIspis.FormattingEnabled = true;
            this.listBoxIspis.ItemHeight = 20;
            this.listBoxIspis.Location = new System.Drawing.Point(12, 12);
            this.listBoxIspis.Name = "listBoxIspis";
            this.listBoxIspis.Size = new System.Drawing.Size(337, 424);
            this.listBoxIspis.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxIspis);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxIspis;
    }
}

