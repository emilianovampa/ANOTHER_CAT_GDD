namespace ClinicaFrba.Abm_Afiliado
{
    partial class frmHomeAfiliado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHomeAfiliado));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHistorialCambiosPlan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBajaAfiliado = new System.Windows.Forms.Button();
            this.btnFiltrarAfiliados = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.dgvAfiliado = new System.Windows.Forms.DataGridView();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfiliado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnHistorialCambiosPlan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnBajaAfiliado);
            this.groupBox1.Controls.Add(this.btnFiltrarAfiliados);
            this.groupBox1.Controls.Add(this.btnAlta);
            this.groupBox1.Controls.Add(this.dgvAfiliado);
            this.groupBox1.Controls.Add(this.txtDNI);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 311);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Afiliado";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(286, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnHistorialCambiosPlan
            // 
            this.btnHistorialCambiosPlan.Location = new System.Drawing.Point(21, 78);
            this.btnHistorialCambiosPlan.Margin = new System.Windows.Forms.Padding(2);
            this.btnHistorialCambiosPlan.Name = "btnHistorialCambiosPlan";
            this.btnHistorialCambiosPlan.Size = new System.Drawing.Size(101, 23);
            this.btnHistorialCambiosPlan.TabIndex = 17;
            this.btnHistorialCambiosPlan.Text = "Ver Historial Cambios Plan";
            this.btnHistorialCambiosPlan.UseVisualStyleBackColor = true;
            this.btnHistorialCambiosPlan.Click += new System.EventHandler(this.btnHistorialCambiosPlan_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 275);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Hacer Doble Click para modificar";
            // 
            // btnBajaAfiliado
            // 
            this.btnBajaAfiliado.Location = new System.Drawing.Point(21, 50);
            this.btnBajaAfiliado.Name = "btnBajaAfiliado";
            this.btnBajaAfiliado.Size = new System.Drawing.Size(101, 23);
            this.btnBajaAfiliado.TabIndex = 20;
            this.btnBajaAfiliado.Text = "Dar De Baja Afiliado";
            this.btnBajaAfiliado.UseVisualStyleBackColor = true;
            this.btnBajaAfiliado.Click += new System.EventHandler(this.btnBajaAfiliado_Click);
            // 
            // btnFiltrarAfiliados
            // 
            this.btnFiltrarAfiliados.Location = new System.Drawing.Point(141, 19);
            this.btnFiltrarAfiliados.Name = "btnFiltrarAfiliados";
            this.btnFiltrarAfiliados.Size = new System.Drawing.Size(98, 23);
            this.btnFiltrarAfiliados.TabIndex = 12;
            this.btnFiltrarAfiliados.Text = "Filtrar Afiliados";
            this.btnFiltrarAfiliados.UseVisualStyleBackColor = true;
            this.btnFiltrarAfiliados.Click += new System.EventHandler(this.btnFiltrarAfiliados_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(21, 20);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(101, 23);
            this.btnAlta.TabIndex = 15;
            this.btnAlta.Text = "Alta Afiliado";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // dgvAfiliado
            // 
            this.dgvAfiliado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAfiliado.Location = new System.Drawing.Point(21, 106);
            this.dgvAfiliado.Name = "dgvAfiliado";
            this.dgvAfiliado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAfiliado.Size = new System.Drawing.Size(394, 166);
            this.dgvAfiliado.TabIndex = 11;
            this.dgvAfiliado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAfiliado_CellContentClick);
            this.dgvAfiliado.DoubleClick += new System.EventHandler(this.dgvAfiliado_DoubleClick);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(139, 66);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DNI";
            // 
            // frmHomeAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 336);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHomeAfiliado";
            this.Text = "Home Afiliado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHomeAfiliado_FormClosed);
            this.Load += new System.EventHandler(this.frmHomeAfiliado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAfiliado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltrarAfiliados;
        private System.Windows.Forms.DataGridView dgvAfiliado;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBajaAfiliado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHistorialCambiosPlan;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}