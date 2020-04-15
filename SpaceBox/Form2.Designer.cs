namespace SpaceBox
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
            this.nombreNave = new System.Windows.Forms.Label();
            this.labelNoMovimientos = new System.Windows.Forms.Label();
            this.labelespacioRecorrido = new System.Windows.Forms.Label();
            this.labelPunteoCristales = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonArchivo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonReiniciar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreNave
            // 
            this.nombreNave.AutoSize = true;
            this.nombreNave.Location = new System.Drawing.Point(260, 15);
            this.nombreNave.Name = "nombreNave";
            this.nombreNave.Size = new System.Drawing.Size(53, 17);
            this.nombreNave.TabIndex = 0;
            this.nombreNave.Text = "-name-";
            // 
            // labelNoMovimientos
            // 
            this.labelNoMovimientos.AutoSize = true;
            this.labelNoMovimientos.Location = new System.Drawing.Point(260, 32);
            this.labelNoMovimientos.Name = "labelNoMovimientos";
            this.labelNoMovimientos.Size = new System.Drawing.Size(114, 17);
            this.labelNoMovimientos.TabIndex = 1;
            this.labelNoMovimientos.Text = "-NoMovimientos-";
            // 
            // labelespacioRecorrido
            // 
            this.labelespacioRecorrido.AutoSize = true;
            this.labelespacioRecorrido.Location = new System.Drawing.Point(260, 49);
            this.labelespacioRecorrido.Name = "labelespacioRecorrido";
            this.labelespacioRecorrido.Size = new System.Drawing.Size(129, 17);
            this.labelespacioRecorrido.TabIndex = 2;
            this.labelespacioRecorrido.Text = "-espacioRecorrido-";
            // 
            // labelPunteoCristales
            // 
            this.labelPunteoCristales.AutoSize = true;
            this.labelPunteoCristales.Location = new System.Drawing.Point(260, 66);
            this.labelPunteoCristales.Name = "labelPunteoCristales";
            this.labelPunteoCristales.Size = new System.Drawing.Size(62, 17);
            this.labelPunteoCristales.TabIndex = 3;
            this.labelPunteoCristales.Text = "-punteo-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "PUNTEO DE CRISTALES:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "ESPACIOS RECORRIDOS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "NÚMERO DE MOVIMIENTOS:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "NOMBRE NAVE:";
            // 
            // buttonArchivo
            // 
            this.buttonArchivo.Location = new System.Drawing.Point(680, 32);
            this.buttonArchivo.Name = "buttonArchivo";
            this.buttonArchivo.Size = new System.Drawing.Size(108, 51);
            this.buttonArchivo.TabIndex = 8;
            this.buttonArchivo.Text = "Cargar archivo...";
            this.buttonArchivo.UseVisualStyleBackColor = true;
            this.buttonArchivo.Click += new System.EventHandler(this.buttonArchivo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(68, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(763, 452);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            // 
            // buttonReiniciar
            // 
            this.buttonReiniciar.Location = new System.Drawing.Point(599, 32);
            this.buttonReiniciar.Name = "buttonReiniciar";
            this.buttonReiniciar.Size = new System.Drawing.Size(75, 51);
            this.buttonReiniciar.TabIndex = 10;
            this.buttonReiniciar.Text = "Reiniciar";
            this.buttonReiniciar.UseVisualStyleBackColor = true;
            this.buttonReiniciar.Click += new System.EventHandler(this.buttonReiniciar_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 646);
            this.Controls.Add(this.buttonReiniciar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonArchivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelPunteoCristales);
            this.Controls.Add(this.labelespacioRecorrido);
            this.Controls.Add(this.labelNoMovimientos);
            this.Controls.Add(this.nombreNave);
            this.Name = "Form2";
            this.Text = "Form2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nombreNave;
        private System.Windows.Forms.Label labelNoMovimientos;
        private System.Windows.Forms.Label labelespacioRecorrido;
        private System.Windows.Forms.Label labelPunteoCristales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonArchivo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonReiniciar;
    }
}