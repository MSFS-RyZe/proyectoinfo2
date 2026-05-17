namespace FormGestor
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usuariotxt = new System.Windows.Forms.TextBox();
            this.contraseñatxt = new System.Windows.Forms.TextBox();
            this.btnsesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario";
            // 
            // usuariotxt
            // 
            this.usuariotxt.Location = new System.Drawing.Point(209, 84);
            this.usuariotxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usuariotxt.Name = "usuariotxt";
            this.usuariotxt.Size = new System.Drawing.Size(150, 25);
            this.usuariotxt.TabIndex = 3;
            // 
            // contraseñatxt
            // 
            this.contraseñatxt.Location = new System.Drawing.Point(209, 177);
            this.contraseñatxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contraseñatxt.Name = "contraseñatxt";
            this.contraseñatxt.Size = new System.Drawing.Size(150, 25);
            this.contraseñatxt.TabIndex = 4;
            // 
            // btnsesion
            // 
            this.btnsesion.Location = new System.Drawing.Point(186, 256);
            this.btnsesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsesion.Name = "btnsesion";
            this.btnsesion.Size = new System.Drawing.Size(206, 77);
            this.btnsesion.TabIndex = 5;
            this.btnsesion.Text = "Iniciar Sesión";
            this.btnsesion.UseVisualStyleBackColor = true;
            this.btnsesion.Click += new System.EventHandler(this.btnsesion_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 427);
            this.Controls.Add(this.btnsesion);
            this.Controls.Add(this.contraseñatxt);
            this.Controls.Add(this.usuariotxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usuariotxt;
        private System.Windows.Forms.TextBox contraseñatxt;
        private System.Windows.Forms.Button btnsesion;
    }
}