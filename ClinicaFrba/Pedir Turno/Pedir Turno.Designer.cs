namespace ClinicaFrba.Pedir_Turno
{
    partial class PedirTurno
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
            this.gridProfesionales = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botonAgenda = new System.Windows.Forms.DataGridViewButtonColumn();
            this.botonVolver = new System.Windows.Forms.Button();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.cBoxEspecilidad = new System.Windows.Forms.ComboBox();
            this.lblNumeroAfiliado = new System.Windows.Forms.Label();
            this.txBoxNumeroAfiliado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfesionales)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProfesionales
            // 
            this.gridProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Especialidad,
            this.botonAgenda});
            this.gridProfesionales.Location = new System.Drawing.Point(18, 157);
            this.gridProfesionales.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridProfesionales.Name = "gridProfesionales";
            this.gridProfesionales.Size = new System.Drawing.Size(666, 205);
            this.gridProfesionales.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            // 
            // Especialidad
            // 
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.Name = "Especialidad";
            // 
            // botonAgenda
            // 
            this.botonAgenda.HeaderText = "Agenda";
            this.botonAgenda.Name = "botonAgenda";
            // 
            // botonVolver
            // 
            this.botonVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonVolver.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 10F);
            this.botonVolver.ForeColor = System.Drawing.Color.Black;
            this.botonVolver.Location = new System.Drawing.Point(521, 81);
            this.botonVolver.Margin = new System.Windows.Forms.Padding(2);
            this.botonVolver.Name = "botonVolver";
            this.botonVolver.Size = new System.Drawing.Size(146, 33);
            this.botonVolver.TabIndex = 50;
            this.botonVolver.Text = "Volver";
            this.botonVolver.UseVisualStyleBackColor = true;
            this.botonVolver.Click += new System.EventHandler(this.botonVolver_Click);
            // 
            // botonAceptar
            // 
            this.botonAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonAceptar.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 10F);
            this.botonAceptar.ForeColor = System.Drawing.Color.Black;
            this.botonAceptar.Location = new System.Drawing.Point(521, 20);
            this.botonAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(146, 33);
            this.botonAceptar.TabIndex = 49;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(12, 89);
            this.lblEspecialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(107, 20);
            this.lblEspecialidad.TabIndex = 1;
            this.lblEspecialidad.Text = "Especialidad: ";
            // 
            // cBoxEspecilidad
            // 
            this.cBoxEspecilidad.FormattingEnabled = true;
            this.cBoxEspecilidad.Location = new System.Drawing.Point(171, 81);
            this.cBoxEspecilidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cBoxEspecilidad.Name = "cBoxEspecilidad";
            this.cBoxEspecilidad.Size = new System.Drawing.Size(180, 28);
            this.cBoxEspecilidad.TabIndex = 2;
            // 
            // lblNumeroAfiliado
            // 
            this.lblNumeroAfiliado.AutoSize = true;
            this.lblNumeroAfiliado.Location = new System.Drawing.Point(14, 25);
            this.lblNumeroAfiliado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroAfiliado.Name = "lblNumeroAfiliado";
            this.lblNumeroAfiliado.Size = new System.Drawing.Size(147, 20);
            this.lblNumeroAfiliado.TabIndex = 5;
            this.lblNumeroAfiliado.Text = "Número de Afiliado:";
            // 
            // txBoxNumeroAfiliado
            // 
            this.txBoxNumeroAfiliado.Location = new System.Drawing.Point(171, 20);
            this.txBoxNumeroAfiliado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txBoxNumeroAfiliado.Name = "txBoxNumeroAfiliado";
            this.txBoxNumeroAfiliado.Size = new System.Drawing.Size(148, 26);
            this.txBoxNumeroAfiliado.TabIndex = 6;
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 423);
            this.Controls.Add(this.txBoxNumeroAfiliado);
            this.Controls.Add(this.lblNumeroAfiliado);
            this.Controls.Add(this.cBoxEspecilidad);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.gridProfesionales);
            this.Controls.Add(this.botonVolver);
            this.Controls.Add(this.botonAceptar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PedirTurno";
            this.Text = "Pedir Turno";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProfesionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridProfesionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
        private System.Windows.Forms.DataGridViewButtonColumn botonAgenda;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cBoxEspecilidad;
        private System.Windows.Forms.Label lblNumeroAfiliado;
        private System.Windows.Forms.TextBox txBoxNumeroAfiliado;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonVolver;
    }
}