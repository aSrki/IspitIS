
namespace FuzzyLogic
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
            this.lblRazdaljina = new System.Windows.Forms.Label();
            this.txtRazdaljina = new System.Windows.Forms.TextBox();
            this.txtUgao = new System.Windows.Forms.TextBox();
            this.lblUgao = new System.Windows.Forms.Label();
            this.btnRazunaj = new System.Windows.Forms.Button();
            this.lblRezultat = new System.Windows.Forms.Label();
            this.lblGreska = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRazdaljina
            // 
            this.lblRazdaljina.AutoSize = true;
            this.lblRazdaljina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazdaljina.Location = new System.Drawing.Point(166, 125);
            this.lblRazdaljina.Name = "lblRazdaljina";
            this.lblRazdaljina.Size = new System.Drawing.Size(251, 32);
            this.lblRazdaljina.TabIndex = 0;
            this.lblRazdaljina.Text = "Unesite razdaljinu:";
            // 
            // txtRazdaljina
            // 
            this.txtRazdaljina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazdaljina.Location = new System.Drawing.Point(446, 125);
            this.txtRazdaljina.Name = "txtRazdaljina";
            this.txtRazdaljina.Size = new System.Drawing.Size(123, 39);
            this.txtRazdaljina.TabIndex = 2;
            // 
            // txtUgao
            // 
            this.txtUgao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUgao.Location = new System.Drawing.Point(446, 183);
            this.txtUgao.Name = "txtUgao";
            this.txtUgao.Size = new System.Drawing.Size(123, 39);
            this.txtUgao.TabIndex = 4;
            // 
            // lblUgao
            // 
            this.lblUgao.AutoSize = true;
            this.lblUgao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUgao.Location = new System.Drawing.Point(226, 183);
            this.lblUgao.Name = "lblUgao";
            this.lblUgao.Size = new System.Drawing.Size(191, 32);
            this.lblUgao.TabIndex = 3;
            this.lblUgao.Text = "Unesite ugao:";
            // 
            // btnRazunaj
            // 
            this.btnRazunaj.Location = new System.Drawing.Point(446, 273);
            this.btnRazunaj.Name = "btnRazunaj";
            this.btnRazunaj.Size = new System.Drawing.Size(123, 55);
            this.btnRazunaj.TabIndex = 5;
            this.btnRazunaj.Text = "Racunaj";
            this.btnRazunaj.UseVisualStyleBackColor = true;
            this.btnRazunaj.Click += new System.EventHandler(this.btnRazunaj_Click);
            // 
            // lblRezultat
            // 
            this.lblRezultat.AutoSize = true;
            this.lblRezultat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRezultat.Location = new System.Drawing.Point(196, 422);
            this.lblRezultat.Name = "lblRezultat";
            this.lblRezultat.Size = new System.Drawing.Size(135, 32);
            this.lblRezultat.TabIndex = 6;
            this.lblRezultat.Text = "Rezultat BRESTA: ";
            // 
            // lblGreska
            // 
            this.lblGreska.AutoSize = true;
            this.lblGreska.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreska.Location = new System.Drawing.Point(196, 483);
            this.lblGreska.Name = "lblGreska";
            this.lblGreska.Size = new System.Drawing.Size(114, 32);
            this.lblGreska.TabIndex = 7;
            this.lblGreska.Text = "Greska:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.lblGreska);
            this.Controls.Add(this.lblRezultat);
            this.Controls.Add(this.btnRazunaj);
            this.Controls.Add(this.txtUgao);
            this.Controls.Add(this.lblUgao);
            this.Controls.Add(this.txtRazdaljina);
            this.Controls.Add(this.lblRazdaljina);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRazdaljina;
        private System.Windows.Forms.TextBox txtRazdaljina;
        private System.Windows.Forms.TextBox txtUgao;
        private System.Windows.Forms.Label lblUgao;
        private System.Windows.Forms.Button btnRazunaj;
        private System.Windows.Forms.Label lblRezultat;
        private System.Windows.Forms.Label lblGreska;
    }
}

