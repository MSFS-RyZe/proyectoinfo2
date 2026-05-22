namespace FlightSimulator
{
    partial class btnguardar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnMover = new System.Windows.Forms.Button();
            this.btndeshacer = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnreiniciar = new System.Windows.Forms.Button();
            this.btnEditarParametros = new System.Windows.Forms.Button();
            this.PanelSimulacion = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMover
            // 
            this.btnMover.Location = new System.Drawing.Point(12, 700);
            this.btnMover.Size = new System.Drawing.Size(120, 80);
            this.btnMover.Text = "MOVER 1 CICLO";
            this.btnMover.Click += new System.EventHandler(this.btnMover_Click);
            // 
            // btndeshacer
            // 
            this.btndeshacer.Location = new System.Drawing.Point(138, 700);
            this.btndeshacer.Size = new System.Drawing.Size(120, 80);
            this.btndeshacer.Text = "DESHACER 1 CICLO";
            this.btndeshacer.Click += new System.EventHandler(this.btndeshacer_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.LightGreen;
            this.btnIniciar.Location = new System.Drawing.Point(264, 700);
            this.btnIniciar.Size = new System.Drawing.Size(120, 80);
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.Color.LightCoral;
            this.btnDetener.Location = new System.Drawing.Point(390, 700);
            this.btnDetener.Size = new System.Drawing.Size(120, 80);
            this.btnDetener.Text = "DETENER";
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnreiniciar
            // 
            this.btnreiniciar.BackColor = System.Drawing.Color.LightYellow;
            this.btnreiniciar.Location = new System.Drawing.Point(516, 700);
            this.btnreiniciar.Size = new System.Drawing.Size(120, 80);
            this.btnreiniciar.Text = "REINICIAR";
            this.btnreiniciar.Click += new System.EventHandler(this.btnreiniciar_Click);
            // 
            // btnEditarParametros
            // 
            this.btnEditarParametros.Location = new System.Drawing.Point(642, 700);
            this.btnEditarParametros.Size = new System.Drawing.Size(120, 80);
            this.btnEditarParametros.Text = "EDITAR PARÁMETROS";
            this.btnEditarParametros.Click += new System.EventHandler(this.btnEditarParametros_Click);
            // 
            // PanelSimulacion
            // 
            this.PanelSimulacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelSimulacion.Location = new System.Drawing.Point(12, 65);
            this.PanelSimulacion.Size = new System.Drawing.Size(1000, 600);
            this.PanelSimulacion.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelSimulacion_Paint);
            this.PanelSimulacion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelSimulacion_MouseClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column1, this.Column2 });
            this.dataGridView1.Location = new System.Drawing.Point(1025, 65);
            this.dataGridView1.Size = new System.Drawing.Size(260, 600);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID Avión";
            this.Column1.Width = 100;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Velocidad";
            this.Column2.Width = 90;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnguardar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PanelSimulacion);
            this.Controls.Add(this.btnEditarParametros);
            this.Controls.Add(this.btnreiniciar);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btndeshacer);
            this.Controls.Add(this.btnMover);
            this.Name = "btnguardar";
            this.Text = "FormSimulacion";
            this.Load += new System.EventHandler(this.FormSimulacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnMover;
        private System.Windows.Forms.Button btndeshacer;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnreiniciar;
        private System.Windows.Forms.Button btnEditarParametros;
        private System.Windows.Forms.Panel PanelSimulacion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}