namespace FormGestor
{
    partial class Form3
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
            this.btnregistrarse = new System.Windows.Forms.Button();
            this.contraseñatxt = new System.Windows.Forms.TextBox();
            this.usuariotxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnregistrarse
            // 
            this.btnregistrarse.Location = new System.Drawing.Point(181, 251);
            this.btnregistrarse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnregistrarse.Name = "btnregistrarse";
            this.btnregistrarse.Size = new System.Drawing.Size(198, 81);
            this.btnregistrarse.TabIndex = 10;
            this.btnregistrarse.Text = " Registrarse";
            this.btnregistrarse.UseVisualStyleBackColor = true;
            this.btnregistrarse.Click += new System.EventHandler(this.btnregistrarse_Click);
            // 
            // contraseñatxt
            // 
            this.contraseñatxt.Location = new System.Drawing.Point(202, 166);
            this.contraseñatxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contraseñatxt.Name = "contraseñatxt";
            this.contraseñatxt.Size = new System.Drawing.Size(150, 25);
            this.contraseñatxt.TabIndex = 9;
            // 
            // usuariotxt
            // 
            this.usuariotxt.Location = new System.Drawing.Point(202, 85);
            this.usuariotxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usuariotxt.Name = "usuariotxt";
            this.usuariotxt.Size = new System.Drawing.Size(150, 25);
            this.usuariotxt.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 427);
            this.Controls.Add(this.btnregistrarse);
            this.Controls.Add(this.contraseñatxt);
            this.Controls.Add(this.usuariotxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnregistrarse;
        private System.Windows.Forms.TextBox contraseñatxt;
        private System.Windows.Forms.TextBox usuariotxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}