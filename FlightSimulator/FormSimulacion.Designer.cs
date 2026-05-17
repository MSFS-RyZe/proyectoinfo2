namespace FlightSimulator
{
    partial class btnguardar
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
            this.btnMover = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnDatos = new System.Windows.Forms.Button();
            this.btnComprobar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btndeshacer = new System.Windows.Forms.Button();
            this.btnsituacion = new System.Windows.Forms.Button();
            this.PanelSimulacion = new System.Windows.Forms.Panel();
            this.btnreiniciar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMover
            // 
            this.btnMover.BackColor = System.Drawing.Color.Silver;
            this.btnMover.Location = new System.Drawing.Point(16, 890);
            this.btnMover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(166, 127);
            this.btnMover.TabIndex = 0;
            this.btnMover.Text = "MOVER 1 CICLO";
            this.btnMover.UseVisualStyleBackColor = false;
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIniciar.Location = new System.Drawing.Point(364, 891);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(166, 127);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDetener.Location = new System.Drawing.Point(538, 890);
            this.btnDetener.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(166, 127);
            this.btnDetener.TabIndex = 2;
            this.btnDetener.Text = "DETENER";
            this.btnDetener.UseVisualStyleBackColor = false;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnDatos
            // 
            this.btnDatos.BackColor = System.Drawing.Color.Silver;
            this.btnDatos.Location = new System.Drawing.Point(1058, 892);
            this.btnDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDatos.Name = "btnDatos";
            this.btnDatos.Size = new System.Drawing.Size(166, 126);
            this.btnDatos.TabIndex = 3;
            this.btnDatos.Text = "VER DATOS DE LOS AVIONES";
            this.btnDatos.UseVisualStyleBackColor = false;
            this.btnDatos.Click += new System.EventHandler(this.btnDatos_Click);
            // 
            // btnComprobar
            // 
            this.btnComprobar.BackColor = System.Drawing.Color.Silver;
            this.btnComprobar.Location = new System.Drawing.Point(884, 892);
            this.btnComprobar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnComprobar.Name = "btnComprobar";
            this.btnComprobar.Size = new System.Drawing.Size(166, 126);
            this.btnComprobar.TabIndex = 4;
            this.btnComprobar.Text = "COMPROBAR SI HABRÁ CONFLICTO";
            this.btnComprobar.UseVisualStyleBackColor = false;
            this.btnComprobar.Click += new System.EventHandler(this.btnComprobar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(1545, 13);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(366, 425);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Velocidad";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // btndeshacer
            // 
            this.btndeshacer.BackColor = System.Drawing.Color.Silver;
            this.btndeshacer.Location = new System.Drawing.Point(190, 890);
            this.btndeshacer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndeshacer.Name = "btndeshacer";
            this.btndeshacer.Size = new System.Drawing.Size(166, 127);
            this.btndeshacer.TabIndex = 6;
            this.btndeshacer.Text = "DESHACER 1 CICLO";
            this.btndeshacer.UseVisualStyleBackColor = false;
            this.btndeshacer.Click += new System.EventHandler(this.btndeshacer_Click);
            // 
            // btnsituacion
            // 
            this.btnsituacion.BackColor = System.Drawing.Color.Silver;
            this.btnsituacion.Location = new System.Drawing.Point(1232, 893);
            this.btnsituacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsituacion.Name = "btnsituacion";
            this.btnsituacion.Size = new System.Drawing.Size(166, 125);
            this.btnsituacion.TabIndex = 7;
            this.btnsituacion.Text = "GUARDAR SITUACIÓN EN UN FICHERO";
            this.btnsituacion.UseVisualStyleBackColor = false;
            this.btnsituacion.Click += new System.EventHandler(this.button1_Click);
            // 
            // PanelSimulacion
            // 
            this.PanelSimulacion.Location = new System.Drawing.Point(16, 16);
            this.PanelSimulacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PanelSimulacion.Name = "PanelSimulacion";
            this.PanelSimulacion.Size = new System.Drawing.Size(1521, 866);
            this.PanelSimulacion.TabIndex = 8;
            this.PanelSimulacion.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelSimulacion_Paint);
            this.PanelSimulacion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelSimulacion_MouseClick);
            // 
            // btnreiniciar
            // 
            this.btnreiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnreiniciar.Location = new System.Drawing.Point(711, 891);
            this.btnreiniciar.Name = "btnreiniciar";
            this.btnreiniciar.Size = new System.Drawing.Size(166, 127);
            this.btnreiniciar.TabIndex = 9;
            this.btnreiniciar.Text = "REINICIAR";
            this.btnreiniciar.UseVisualStyleBackColor = false;
            this.btnreiniciar.Click += new System.EventHandler(this.btnreiniciar_Click);
            // 
            // btnguardar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1030);
            this.Controls.Add(this.btnComprobar);
            this.Controls.Add(this.btnreiniciar);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btndeshacer);
            this.Controls.Add(this.PanelSimulacion);
            this.Controls.Add(this.btnsituacion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDatos);
            this.Controls.Add(this.btnMover);
            this.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "btnguardar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSimulacion";
            this.Load += new System.EventHandler(this.FormSimulacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnDatos;
        private System.Windows.Forms.Button btnComprobar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btndeshacer;
        private System.Windows.Forms.Button btnsituacion;
        private System.Windows.Forms.Panel PanelSimulacion;
        private System.Windows.Forms.Button btnreiniciar;
    }
}