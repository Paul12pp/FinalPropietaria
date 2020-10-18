namespace FinalPropietaria
{
    partial class Form_Verificar
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
            this.tbcedula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnchek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbcedula
            // 
            this.tbcedula.Location = new System.Drawing.Point(38, 71);
            this.tbcedula.Name = "tbcedula";
            this.tbcedula.Size = new System.Drawing.Size(204, 20);
            this.tbcedula.TabIndex = 0;
            this.tbcedula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbcedula_KeyDown);
            this.tbcedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numbers);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orchid;
            this.label1.Location = new System.Drawing.Point(104, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cédula";
            // 
            // btnchek
            // 
            this.btnchek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchek.ForeColor = System.Drawing.Color.Orchid;
            this.btnchek.Location = new System.Drawing.Point(94, 97);
            this.btnchek.Name = "btnchek";
            this.btnchek.Size = new System.Drawing.Size(75, 23);
            this.btnchek.TabIndex = 2;
            this.btnchek.Text = "Verificar";
            this.btnchek.UseVisualStyleBackColor = true;
            this.btnchek.Click += new System.EventHandler(this.btnchek_Click);
            // 
            // Form_Verificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 155);
            this.Controls.Add(this.btnchek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbcedula);
            this.MaximizeBox = false;
            this.Name = "Form_Verificar";
            this.Text = "Verificarme";
            this.Load += new System.EventHandler(this.Form_Verificar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbcedula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnchek;
    }
}