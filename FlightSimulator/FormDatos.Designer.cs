namespace FlightSimulator
{
    partial class FormDatos
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtid_1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txty1_1 = new System.Windows.Forms.TextBox();
            this.txtx1_1 = new System.Windows.Forms.TextBox();
            this.txty0_1 = new System.Windows.Forms.TextBox();
            this.txtx0_1 = new System.Windows.Forms.TextBox();
            this.txtvelocidad_1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtvelocidad_2 = new System.Windows.Forms.TextBox();
            this.txtx0_2 = new System.Windows.Forms.TextBox();
            this.txty0_2 = new System.Windows.Forms.TextBox();
            this.txtx1_2 = new System.Windows.Forms.TextBox();
            this.txty1_2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtid_2 = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnarchivo = new System.Windows.Forms.Button();
            this.btnImportarArchivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Avión1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtid_1
            // 
            this.txtid_1.Location = new System.Drawing.Point(210, 44);
            this.txtid_1.Name = "txtid_1";
            this.txtid_1.Size = new System.Drawing.Size(132, 29);
            this.txtid_1.TabIndex = 1;
            this.txtid_1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Identificador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Velocidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Coordenadas Iniciales (Y)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Coordenadas Finales (X)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Coordenadas Finales (Y)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Coordenadas Iniciales (X)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Gadugi", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 28);
            this.label8.TabIndex = 8;
            this.label8.Text = "Avión2";
            // 
            // txty1_1
            // 
            this.txty1_1.Location = new System.Drawing.Point(210, 207);
            this.txty1_1.Name = "txty1_1";
            this.txty1_1.Size = new System.Drawing.Size(132, 29);
            this.txty1_1.TabIndex = 9;
            // 
            // txtx1_1
            // 
            this.txtx1_1.Location = new System.Drawing.Point(210, 176);
            this.txtx1_1.Name = "txtx1_1";
            this.txtx1_1.Size = new System.Drawing.Size(132, 29);
            this.txtx1_1.TabIndex = 10;
            // 
            // txty0_1
            // 
            this.txty0_1.Location = new System.Drawing.Point(210, 143);
            this.txty0_1.Name = "txty0_1";
            this.txty0_1.Size = new System.Drawing.Size(132, 29);
            this.txty0_1.TabIndex = 11;
            // 
            // txtx0_1
            // 
            this.txtx0_1.Location = new System.Drawing.Point(210, 105);
            this.txtx0_1.Name = "txtx0_1";
            this.txtx0_1.Size = new System.Drawing.Size(132, 29);
            this.txtx0_1.TabIndex = 12;
            // 
            // txtvelocidad_1
            // 
            this.txtvelocidad_1.Location = new System.Drawing.Point(210, 76);
            this.txtvelocidad_1.Name = "txtvelocidad_1";
            this.txtvelocidad_1.Size = new System.Drawing.Size(132, 29);
            this.txtvelocidad_1.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(560, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 20);
            this.label9.TabIndex = 14;
            // 
            // txtvelocidad_2
            // 
            this.txtvelocidad_2.Location = new System.Drawing.Point(210, 345);
            this.txtvelocidad_2.Name = "txtvelocidad_2";
            this.txtvelocidad_2.Size = new System.Drawing.Size(132, 29);
            this.txtvelocidad_2.TabIndex = 26;
            // 
            // txtx0_2
            // 
            this.txtx0_2.Location = new System.Drawing.Point(210, 378);
            this.txtx0_2.Name = "txtx0_2";
            this.txtx0_2.Size = new System.Drawing.Size(132, 29);
            this.txtx0_2.TabIndex = 25;
            // 
            // txty0_2
            // 
            this.txty0_2.Location = new System.Drawing.Point(210, 411);
            this.txty0_2.Name = "txty0_2";
            this.txty0_2.Size = new System.Drawing.Size(132, 29);
            this.txty0_2.TabIndex = 24;
            // 
            // txtx1_2
            // 
            this.txtx1_2.Location = new System.Drawing.Point(210, 444);
            this.txtx1_2.Name = "txtx1_2";
            this.txtx1_2.Size = new System.Drawing.Size(132, 29);
            this.txtx1_2.TabIndex = 23;
            // 
            // txty1_2
            // 
            this.txty1_2.Location = new System.Drawing.Point(210, 477);
            this.txty1_2.Name = "txty1_2";
            this.txty1_2.Size = new System.Drawing.Size(132, 29);
            this.txty1_2.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 381);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Coordenadas Iniciales (X)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 480);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(199, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Coordenadas Finales (Y)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 447);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(200, 20);
            this.label12.TabIndex = 19;
            this.label12.Text = "Coordenadas Finales (X)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 414);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(208, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "Coordenadas Iniciales (Y)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 348);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = "Velocidad";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(33, 315);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 20);
            this.label15.TabIndex = 16;
            this.label15.Text = "Identificador";
            // 
            // txtid_2
            // 
            this.txtid_2.Location = new System.Drawing.Point(210, 312);
            this.txtid_2.Name = "txtid_2";
            this.txtid_2.Size = new System.Drawing.Size(132, 29);
            this.txtid_2.TabIndex = 15;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(431, 230);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(171, 92);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar Datos";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnarchivo
            // 
            this.btnarchivo.Location = new System.Drawing.Point(645, 230);
            this.btnarchivo.Name = "btnarchivo";
            this.btnarchivo.Size = new System.Drawing.Size(233, 92);
            this.btnarchivo.TabIndex = 28;
            this.btnarchivo.Text = "Cargar datos de prueba";
            this.btnarchivo.UseVisualStyleBackColor = true;
            this.btnarchivo.Click += new System.EventHandler(this.btnarchivo_Click);
            // 
            // btnImportarArchivo
            // 
            this.btnImportarArchivo.Location = new System.Drawing.Point(645, 340);
            this.btnImportarArchivo.Name = "btnImportarArchivo";
            this.btnImportarArchivo.Size = new System.Drawing.Size(233, 92);
            this.btnImportarArchivo.TabIndex = 29;
            this.btnImportarArchivo.Text = "Importar archivo .txt";
            this.btnImportarArchivo.UseVisualStyleBackColor = true;
            this.btnImportarArchivo.Click += new System.EventHandler(this.btnImportarArchivo_Click);
            // 
            // FormDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 560);
            this.Controls.Add(this.btnImportarArchivo);
            this.Controls.Add(this.btnarchivo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtvelocidad_2);
            this.Controls.Add(this.txtx0_2);
            this.Controls.Add(this.txty0_2);
            this.Controls.Add(this.txtx1_2);
            this.Controls.Add(this.txty1_2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtid_2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtvelocidad_1);
            this.Controls.Add(this.txtx0_1);
            this.Controls.Add(this.txty0_1);
            this.Controls.Add(this.txtx1_1);
            this.Controls.Add(this.txty1_1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtid_1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDatos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtid_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txty1_1;
        private System.Windows.Forms.TextBox txtx1_1;
        private System.Windows.Forms.TextBox txty0_1;
        private System.Windows.Forms.TextBox txtx0_1;
        private System.Windows.Forms.TextBox txtvelocidad_1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtvelocidad_2;
        private System.Windows.Forms.TextBox txtx0_2;
        private System.Windows.Forms.TextBox txty0_2;
        private System.Windows.Forms.TextBox txtx1_2;
        private System.Windows.Forms.TextBox txty1_2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtid_2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnarchivo;
        private System.Windows.Forms.Button btnImportarArchivo;
    }
}