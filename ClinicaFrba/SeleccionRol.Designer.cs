namespace ClinicaFrba
{
    partial class SeleccionRol
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
            this.ingresarRol = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ingresarRol
            // 
            this.ingresarRol.Location = new System.Drawing.Point(67, 127);
            this.ingresarRol.Name = "ingresarRol";
            this.ingresarRol.Size = new System.Drawing.Size(121, 23);
            this.ingresarRol.TabIndex = 0;
            this.ingresarRol.Text = "Ingresar";
            this.ingresarRol.UseVisualStyleBackColor = true;
            this.ingresarRol.Click += new System.EventHandler(this.ingresarRol_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Administrador",
            "Afiliado",
            "Profesional"});
            this.comboBox1.Location = new System.Drawing.Point(67, 79);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar Rol";
            // 
            // SeleccionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ingresarRol);
            this.Name = "SeleccionRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Tipo de Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeleccionRol_FormClosing);
            this.Load += new System.EventHandler(this.roles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ingresarRol;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;

    }
}