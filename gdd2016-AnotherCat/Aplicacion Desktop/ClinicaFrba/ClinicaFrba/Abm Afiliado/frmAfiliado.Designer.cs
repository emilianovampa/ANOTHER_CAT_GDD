namespace ClinicaFrba.Abm_Afiliado
{
    partial class frmAfiliado
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
            this.btnHabilitar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.ckbEstado = new System.Windows.Forms.CheckBox();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCambioPlan = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ckbCambioPlan = new System.Windows.Forms.CheckBox();
            this.lblCambioPlan = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.Location = new System.Drawing.Point(347, 256);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(150, 27);
            this.btnHabilitar.TabIndex = 48;
            this.btnHabilitar.Text = "Habilitar";
            this.btnHabilitar.UseVisualStyleBackColor = true;
            this.btnHabilitar.Visible = false;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(355, 71);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(144, 20);
            this.dtpFecha.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(255, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Fecha Nacimiento";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(355, 42);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(144, 20);
            this.txtDireccion.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Direccion";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(355, 12);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(144, 20);
            this.txtTelefono.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Telefono";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(105, 182);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(144, 20);
            this.txtMail.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Mail";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(105, 70);
            this.txtDni.Multiline = true;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(78, 20);
            this.txtDni.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Documento";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(105, 40);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(144, 20);
            this.txtApellido.TabIndex = 29;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(105, 10);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(144, 20);
            this.txtNombre.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nombre";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(8, 223);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(149, 27);
            this.btnGuardar.TabIndex = 49;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Estado Civil";
            // 
            // cmbEstadoCivil
            // 
            this.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCivil.FormattingEnabled = true;
            this.cmbEstadoCivil.Items.AddRange(new object[] {
            "No Especifica",
            "Casado/a",
            "Soltero/a",
            "Viudo/a",
            "Divorciado/a"});
            this.cmbEstadoCivil.Location = new System.Drawing.Point(105, 96);
            this.cmbEstadoCivil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbEstadoCivil.Name = "cmbEstadoCivil";
            this.cmbEstadoCivil.Size = new System.Drawing.Size(144, 21);
            this.cmbEstadoCivil.TabIndex = 51;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 152);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Plan Medico";
            // 
            // cmbPlan
            // 
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(105, 152);
            this.cmbPlan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(144, 21);
            this.cmbPlan.TabIndex = 53;
            this.cmbPlan.SelectedIndexChanged += new System.EventHandler(this.cmbPlan_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(255, 100);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 46;
            this.lblEstado.Text = "Estado";
            // 
            // ckbEstado
            // 
            this.ckbEstado.Enabled = false;
            this.ckbEstado.Location = new System.Drawing.Point(355, 100);
            this.ckbEstado.Name = "ckbEstado";
            this.ckbEstado.Size = new System.Drawing.Size(142, 17);
            this.ckbEstado.TabIndex = 47;
            this.ckbEstado.Text = "Activo";
            this.ckbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbEstado.UseVisualStyleBackColor = true;
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "No especificado",
            "Masculino",
            "Femenino"});
            this.cmbSexo.Location = new System.Drawing.Point(105, 124);
            this.cmbSexo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(144, 21);
            this.cmbSexo.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Sexo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(257, 128);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Motivo Cambio Plan";
            this.label11.Visible = false;
            // 
            // txtCambioPlan
            // 
            this.txtCambioPlan.Location = new System.Drawing.Point(355, 128);
            this.txtCambioPlan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCambioPlan.Name = "txtCambioPlan";
            this.txtCambioPlan.Size = new System.Drawing.Size(143, 20);
            this.txtCambioPlan.TabIndex = 57;
            this.txtCambioPlan.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(8, 254);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(149, 27);
            this.btnLimpiar.TabIndex = 58;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 27);
            this.button1.TabIndex = 59;
            this.button1.Text = "Agregar Familiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ckbCambioPlan
            // 
            this.ckbCambioPlan.AutoSize = true;
            this.ckbCambioPlan.Location = new System.Drawing.Point(465, 152);
            this.ckbCambioPlan.Name = "ckbCambioPlan";
            this.ckbCambioPlan.Size = new System.Drawing.Size(35, 17);
            this.ckbCambioPlan.TabIndex = 60;
            this.ckbCambioPlan.Text = "Si";
            this.ckbCambioPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbCambioPlan.UseVisualStyleBackColor = true;
            this.ckbCambioPlan.Visible = false;
            // 
            // lblCambioPlan
            // 
            this.lblCambioPlan.AutoSize = true;
            this.lblCambioPlan.Location = new System.Drawing.Point(257, 152);
            this.lblCambioPlan.Name = "lblCambioPlan";
            this.lblCambioPlan.Size = new System.Drawing.Size(175, 13);
            this.lblCambioPlan.TabIndex = 61;
            this.lblCambioPlan.Text = "Desea cambiar a su famila de plan?";
            this.lblCambioPlan.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "DNI",
            "CI",
            "LC",
            "LE"});
            this.comboBox1.Location = new System.Drawing.Point(188, 70);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(61, 21);
            this.comboBox1.TabIndex = 62;
            // 
            // frmAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 305);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblCambioPlan);
            this.Controls.Add(this.ckbCambioPlan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtCambioPlan);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbPlan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbEstadoCivil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.ckbEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAfiliado";
            this.Text = "Afiliado";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAltaAfiliado_FormClosed);
            this.Load += new System.EventHandler(this.frmAltaAfiliado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHabilitar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstadoCivil;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.CheckBox ckbEstado;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCambioPlan;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ckbCambioPlan;
        private System.Windows.Forms.Label lblCambioPlan;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}