namespace ClinicaFrba.Abm_Afiliado
{
    partial class AltaAfiliado
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
            this.LimpiarAF = new System.Windows.Forms.Button();
            this.GuardarAF = new System.Windows.Forms.Button();
            this.NombreAF = new System.Windows.Forms.TextBox();
            this.ApellidoAF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NacAF = new System.Windows.Forms.DateTimePicker();
            this.cPlanM = new System.Windows.Forms.ComboBox();
            this.FamAF = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.EstadoAF = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Sex1 = new System.Windows.Forms.RadioButton();
            this.Sex2 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MailAF = new System.Windows.Forms.TextBox();
            this.TelAF = new System.Windows.Forms.TextBox();
            this.DomAF = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DocAF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TipoAF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LimpiarAF
            // 
            this.LimpiarAF.Location = new System.Drawing.Point(21, 426);
            this.LimpiarAF.Name = "LimpiarAF";
            this.LimpiarAF.Size = new System.Drawing.Size(75, 23);
            this.LimpiarAF.TabIndex = 0;
            this.LimpiarAF.Text = "Limpiar";
            this.LimpiarAF.UseVisualStyleBackColor = true;
            this.LimpiarAF.Click += new System.EventHandler(this.LimpiarAF_Click);
            // 
            // GuardarAF
            // 
            this.GuardarAF.Location = new System.Drawing.Point(387, 426);
            this.GuardarAF.Name = "GuardarAF";
            this.GuardarAF.Size = new System.Drawing.Size(75, 23);
            this.GuardarAF.TabIndex = 1;
            this.GuardarAF.Text = "Guardar";
            this.GuardarAF.UseVisualStyleBackColor = true;
            this.GuardarAF.Click += new System.EventHandler(this.GuardarAF_Click);
            // 
            // NombreAF
            // 
            this.NombreAF.Location = new System.Drawing.Point(56, 45);
            this.NombreAF.Name = "NombreAF";
            this.NombreAF.Size = new System.Drawing.Size(127, 20);
            this.NombreAF.TabIndex = 2;
            // 
            // ApellidoAF
            // 
            this.ApellidoAF.Location = new System.Drawing.Point(300, 45);
            this.ApellidoAF.Name = "ApellidoAF";
            this.ApellidoAF.Size = new System.Drawing.Size(122, 20);
            this.ApellidoAF.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Apellido";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NacAF);
            this.groupBox1.Controls.Add(this.cPlanM);
            this.groupBox1.Controls.Add(this.FamAF);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.EstadoAF);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.Sex1);
            this.groupBox1.Controls.Add(this.Sex2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.MailAF);
            this.groupBox1.Controls.Add(this.TelAF);
            this.groupBox1.Controls.Add(this.DomAF);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DocAF);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TipoAF);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NombreAF);
            this.groupBox1.Controls.Add(this.ApellidoAF);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 408);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Personales";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // NacAF
            // 
            this.NacAF.Location = new System.Drawing.Point(162, 288);
            this.NacAF.Name = "NacAF";
            this.NacAF.Size = new System.Drawing.Size(213, 20);
            this.NacAF.TabIndex = 31;
            this.NacAF.ValueChanged += new System.EventHandler(this.NacAF_ValueChanged);
            // 
            // cPlanM
            // 
            this.cPlanM.FormattingEnabled = true;
            this.cPlanM.Location = new System.Drawing.Point(320, 205);
            this.cPlanM.Name = "cPlanM";
            this.cPlanM.Size = new System.Drawing.Size(102, 21);
            this.cPlanM.TabIndex = 30;
            this.cPlanM.SelectedIndexChanged += new System.EventHandler(this.cPlanM_SelectedIndexChanged);
            // 
            // FamAF
            // 
            this.FamAF.Location = new System.Drawing.Point(313, 174);
            this.FamAF.Name = "FamAF";
            this.FamAF.Size = new System.Drawing.Size(109, 20);
            this.FamAF.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(219, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "FamiliaresACargo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(219, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "PlanMedico";
            // 
            // EstadoAF
            // 
            this.EstadoAF.FormattingEnabled = true;
            this.EstadoAF.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Viudo/a",
            "Concubinato",
            "Divorciado/a"});
            this.EstadoAF.Location = new System.Drawing.Point(71, 208);
            this.EstadoAF.Name = "EstadoAF";
            this.EstadoAF.Size = new System.Drawing.Size(112, 21);
            this.EstadoAF.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Sexo";
            // 
            // Sex1
            // 
            this.Sex1.AutoSize = true;
            this.Sex1.Checked = true;
            this.Sex1.Location = new System.Drawing.Point(56, 250);
            this.Sex1.Name = "Sex1";
            this.Sex1.Size = new System.Drawing.Size(62, 17);
            this.Sex1.TabIndex = 21;
            this.Sex1.TabStop = true;
            this.Sex1.Text = "Hombre";
            this.Sex1.UseVisualStyleBackColor = true;
            this.Sex1.CheckedChanged += new System.EventHandler(this.Sex1_CheckedChanged);
            // 
            // Sex2
            // 
            this.Sex2.AutoSize = true;
            this.Sex2.Location = new System.Drawing.Point(124, 250);
            this.Sex2.Name = "Sex2";
            this.Sex2.Size = new System.Drawing.Size(51, 17);
            this.Sex2.TabIndex = 20;
            this.Sex2.TabStop = true;
            this.Sex2.Text = "Mujer";
            this.Sex2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "EstadoCivil";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Fecha De Nacimiento";
            // 
            // MailAF
            // 
            this.MailAF.Location = new System.Drawing.Point(44, 174);
            this.MailAF.Name = "MailAF";
            this.MailAF.Size = new System.Drawing.Size(139, 20);
            this.MailAF.TabIndex = 15;
            // 
            // TelAF
            // 
            this.TelAF.Location = new System.Drawing.Point(300, 130);
            this.TelAF.Name = "TelAF";
            this.TelAF.Size = new System.Drawing.Size(122, 20);
            this.TelAF.TabIndex = 14;
            this.TelAF.TextChanged += new System.EventHandler(this.TelAF_TextChanged);
            // 
            // DomAF
            // 
            this.DomAF.Location = new System.Drawing.Point(61, 134);
            this.DomAF.Name = "DomAF";
            this.DomAF.Size = new System.Drawing.Size(122, 20);
            this.DomAF.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Telefono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Domicilio";
            // 
            // DocAF
            // 
            this.DocAF.Location = new System.Drawing.Point(300, 84);
            this.DocAF.Name = "DocAF";
            this.DocAF.Size = new System.Drawing.Size(122, 20);
            this.DocAF.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "NroDocumento";
            // 
            // TipoAF
            // 
            this.TipoAF.Location = new System.Drawing.Point(95, 88);
            this.TipoAF.Name = "TipoAF";
            this.TipoAF.Size = new System.Drawing.Size(88, 20);
            this.TipoAF.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "TipoDocumento";
            // 
            // AltaAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 468);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GuardarAF);
            this.Controls.Add(this.LimpiarAF);
            this.Name = "AltaAfiliado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Afiliado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AltaAfiliado_FormClosing);
            this.Load += new System.EventHandler(this.AltaAfiliado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LimpiarAF;
        private System.Windows.Forms.Button GuardarAF;
        private System.Windows.Forms.TextBox NombreAF;
        private System.Windows.Forms.TextBox ApellidoAF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DocAF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TipoAF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox EstadoAF;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton Sex1;
        private System.Windows.Forms.RadioButton Sex2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox MailAF;
        private System.Windows.Forms.TextBox TelAF;
        private System.Windows.Forms.TextBox DomAF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FamAF;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cPlanM;
        private System.Windows.Forms.DateTimePicker NacAF;
    }
}