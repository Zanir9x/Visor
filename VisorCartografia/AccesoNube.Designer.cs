namespace VisorCartografia
{
    partial class AccesoNube
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccesoNube));
            this.estatico = new System.Windows.Forms.Panel();
            this.progresoCarga = new System.Windows.Forms.ProgressBar();
            this.logotip = new System.Windows.Forms.PictureBox();
            this.listaArchivos = new System.Windows.Forms.ListBox();
            this.estatico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logotip)).BeginInit();
            this.SuspendLayout();
            // 
            // estatico
            // 
            this.estatico.AutoScroll = true;
            this.estatico.BackColor = System.Drawing.Color.Transparent;
            this.estatico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.estatico.Controls.Add(this.progresoCarga);
            this.estatico.Controls.Add(this.logotip);
            this.estatico.Controls.Add(this.listaArchivos);
            this.estatico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.estatico.Location = new System.Drawing.Point(0, 0);
            this.estatico.Name = "estatico";
            this.estatico.Size = new System.Drawing.Size(884, 561);
            this.estatico.TabIndex = 0;
            // 
            // progresoCarga
            // 
            this.progresoCarga.Location = new System.Drawing.Point(116, 145);
            this.progresoCarga.Name = "progresoCarga";
            this.progresoCarga.Size = new System.Drawing.Size(650, 23);
            this.progresoCarga.TabIndex = 12;
            this.progresoCarga.Visible = false;
            // 
            // logotip
            // 
            this.logotip.BackColor = System.Drawing.Color.Transparent;
            this.logotip.Enabled = false;
            this.logotip.Image = global::VisorCartografia.Properties.Resources.SEDUM2;
            this.logotip.Location = new System.Drawing.Point(116, 9);
            this.logotip.Name = "logotip";
            this.logotip.Size = new System.Drawing.Size(650, 159);
            this.logotip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logotip.TabIndex = 14;
            this.logotip.TabStop = false;
            // 
            // listaArchivos
            // 
            this.listaArchivos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listaArchivos.ColumnWidth = 300;
            this.listaArchivos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaArchivos.FormattingEnabled = true;
            this.listaArchivos.ItemHeight = 15;
            this.listaArchivos.Location = new System.Drawing.Point(139, 196);
            this.listaArchivos.MultiColumn = true;
            this.listaArchivos.Name = "listaArchivos";
            this.listaArchivos.Size = new System.Drawing.Size(607, 304);
            this.listaArchivos.TabIndex = 2;
            this.listaArchivos.DoubleClick += new System.EventHandler(this.listaArchivos_DoubleClick);
            // 
            // AccesoNube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImage = global::VisorCartografia.Properties.Resources.AASin_título71;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.estatico);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccesoNube";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARTOGRAFIA SEDUM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.estatico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logotip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel estatico;
        private System.Windows.Forms.ProgressBar progresoCarga;
        private System.Windows.Forms.PictureBox logotip;
        private System.Windows.Forms.ListBox listaArchivos;
    }
}

