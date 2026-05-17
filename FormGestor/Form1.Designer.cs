namespace FormGestor
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
            this.btniniciar = new System.Windows.Forms.Button();
            this.btnregistrarse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btniniciar
            // 
            this.btniniciar.Location = new System.Drawing.Point(134, 65);
            this.btniniciar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btniniciar.Name = "btniniciar";
            this.btniniciar.Size = new System.Drawing.Size(225, 63);
            this.btniniciar.TabIndex = 0;
            this.btniniciar.Text = "Iniciar Sesión";
            this.btniniciar.UseVisualStyleBackColor = true;
            this.btniniciar.Click += new System.EventHandler(this.btnusuarios_Click);
            // 
            // btnregistrarse
            // 
            this.btnregistrarse.Location = new System.Drawing.Point(134, 176);
            this.btnregistrarse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnregistrarse.Name = "btnregistrarse";
            this.btnregistrarse.Size = new System.Drawing.Size(225, 63);
            this.btnregistrarse.TabIndex = 1;
            this.btnregistrarse.Text = "Registrarse";
            this.btnregistrarse.UseVisualStyleBackColor = true;
            this.btnregistrarse.Click += new System.EventHandler(this.btnregistrarse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(479, 332);
            this.Controls.Add(this.btnregistrarse);
            this.Controls.Add(this.btniniciar);
            this.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btniniciar;
        private System.Windows.Forms.Button btnregistrarse;
    }
}