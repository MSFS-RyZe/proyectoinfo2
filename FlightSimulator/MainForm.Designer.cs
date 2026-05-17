namespace FlightSimulator
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introducirPlanesDeVueloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosDeSimulaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSimulaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(590, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // datosToolStripMenuItem
            // 
            this.datosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.introducirPlanesDeVueloToolStripMenuItem,
            this.parámetrosDeSimulaciToolStripMenuItem,
            this.iniciarSimulaciónToolStripMenuItem});
            this.datosToolStripMenuItem.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datosToolStripMenuItem.Name = "datosToolStripMenuItem";
            this.datosToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.datosToolStripMenuItem.Text = "Datos";
            this.datosToolStripMenuItem.Click += new System.EventHandler(this.datosToolStripMenuItem_Click);
            // 
            // introducirPlanesDeVueloToolStripMenuItem
            // 
            this.introducirPlanesDeVueloToolStripMenuItem.Name = "introducirPlanesDeVueloToolStripMenuItem";
            this.introducirPlanesDeVueloToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.introducirPlanesDeVueloToolStripMenuItem.Text = "Introducir planes de vuelo";
            this.introducirPlanesDeVueloToolStripMenuItem.Click += new System.EventHandler(this.introducirPlanesDeVueloToolStripMenuItem_Click);
            // 
            // parámetrosDeSimulaciToolStripMenuItem
            // 
            this.parámetrosDeSimulaciToolStripMenuItem.Name = "parámetrosDeSimulaciToolStripMenuItem";
            this.parámetrosDeSimulaciToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.parámetrosDeSimulaciToolStripMenuItem.Text = "Parámetros simulación";
            this.parámetrosDeSimulaciToolStripMenuItem.Click += new System.EventHandler(this.parámetrosDeSimulaciToolStripMenuItem_Click);
            // 
            // iniciarSimulaciónToolStripMenuItem
            // 
            this.iniciarSimulaciónToolStripMenuItem.Name = "iniciarSimulaciónToolStripMenuItem";
            this.iniciarSimulaciónToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.iniciarSimulaciónToolStripMenuItem.Text = "Iniciar simulación";
            this.iniciarSimulaciónToolStripMenuItem.Click += new System.EventHandler(this.iniciarSimulaciónToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 427);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador de Vuelos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introducirPlanesDeVueloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosDeSimulaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSimulaciónToolStripMenuItem;
    }
}

