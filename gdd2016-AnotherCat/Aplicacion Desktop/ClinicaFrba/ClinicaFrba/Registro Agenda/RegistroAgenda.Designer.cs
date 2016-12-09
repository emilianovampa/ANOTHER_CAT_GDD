/*
 * Created by SharpDevelop.
 * User: Lelouch
 * Date: 05/10/2016
 * Time: 23:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClinicaFrba.Registro_Agenda
{
	partial class RegistroAgenda
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox horaInicio1Lunes;
        private System.Windows.Forms.TextBox horaFin1Lunes;
		private System.Windows.Forms.TextBox horaInicio1Martes;
        private System.Windows.Forms.TextBox horaFin1Martes;
		private System.Windows.Forms.TextBox horaInicio1Miercoles;
        private System.Windows.Forms.TextBox horaFin1Miercoles;
		private System.Windows.Forms.TextBox horaInicio1Jueves;
        private System.Windows.Forms.TextBox horaFin1Jueves;
		private System.Windows.Forms.TextBox horaInicio1Viernes;
        private System.Windows.Forms.TextBox horaFin1Viernes;
		private System.Windows.Forms.TextBox horaInicio1Sabado;
        private System.Windows.Forms.TextBox horaFin1Sabado;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private System.Windows.Forms.MonthCalendar monthCalendar2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox listaEspecialidades;
		private System.Windows.Forms.Button buttonOK;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.horaInicio1Lunes = new System.Windows.Forms.TextBox();
            this.horaFin1Lunes = new System.Windows.Forms.TextBox();
            this.horaInicio1Martes = new System.Windows.Forms.TextBox();
            this.horaFin1Martes = new System.Windows.Forms.TextBox();
            this.horaInicio1Miercoles = new System.Windows.Forms.TextBox();
            this.horaFin1Miercoles = new System.Windows.Forms.TextBox();
            this.horaInicio1Jueves = new System.Windows.Forms.TextBox();
            this.horaFin1Jueves = new System.Windows.Forms.TextBox();
            this.horaInicio1Viernes = new System.Windows.Forms.TextBox();
            this.horaFin1Viernes = new System.Windows.Forms.TextBox();
            this.horaInicio1Sabado = new System.Windows.Forms.TextBox();
            this.horaFin1Sabado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listaEspecialidades = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.btnHorarios = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // horaInicio1Lunes
            // 
            this.horaInicio1Lunes.Location = new System.Drawing.Point(93, 114);
            this.horaInicio1Lunes.Name = "horaInicio1Lunes";
            this.horaInicio1Lunes.Size = new System.Drawing.Size(72, 20);
            this.horaInicio1Lunes.TabIndex = 0;
            this.horaInicio1Lunes.Visible = false;
            // 
            // horaFin1Lunes
            // 
            this.horaFin1Lunes.Location = new System.Drawing.Point(171, 114);
            this.horaFin1Lunes.Name = "horaFin1Lunes";
            this.horaFin1Lunes.Size = new System.Drawing.Size(72, 20);
            this.horaFin1Lunes.TabIndex = 1;
            this.horaFin1Lunes.Visible = false;
            this.horaFin1Lunes.TextChanged += new System.EventHandler(this.horaFin1Lunes_TextChanged);
            // 
            // horaInicio1Martes
            // 
            this.horaInicio1Martes.Location = new System.Drawing.Point(93, 143);
            this.horaInicio1Martes.Name = "horaInicio1Martes";
            this.horaInicio1Martes.Size = new System.Drawing.Size(72, 20);
            this.horaInicio1Martes.TabIndex = 4;
            this.horaInicio1Martes.Visible = false;
            // 
            // horaFin1Martes
            // 
            this.horaFin1Martes.Location = new System.Drawing.Point(171, 143);
            this.horaFin1Martes.Name = "horaFin1Martes";
            this.horaFin1Martes.Size = new System.Drawing.Size(72, 20);
            this.horaFin1Martes.TabIndex = 5;
            this.horaFin1Martes.Visible = false;
            // 
            // horaInicio1Miercoles
            // 
            this.horaInicio1Miercoles.Location = new System.Drawing.Point(93, 169);
            this.horaInicio1Miercoles.Name = "horaInicio1Miercoles";
            this.horaInicio1Miercoles.Size = new System.Drawing.Size(72, 20);
            this.horaInicio1Miercoles.TabIndex = 8;
            this.horaInicio1Miercoles.Visible = false;
            // 
            // horaFin1Miercoles
            // 
            this.horaFin1Miercoles.Location = new System.Drawing.Point(171, 169);
            this.horaFin1Miercoles.Name = "horaFin1Miercoles";
            this.horaFin1Miercoles.Size = new System.Drawing.Size(72, 20);
            this.horaFin1Miercoles.TabIndex = 9;
            this.horaFin1Miercoles.Visible = false;
            // 
            // horaInicio1Jueves
            // 
            this.horaInicio1Jueves.Location = new System.Drawing.Point(93, 195);
            this.horaInicio1Jueves.Name = "horaInicio1Jueves";
            this.horaInicio1Jueves.Size = new System.Drawing.Size(72, 20);
            this.horaInicio1Jueves.TabIndex = 12;
            this.horaInicio1Jueves.Visible = false;
            // 
            // horaFin1Jueves
            // 
            this.horaFin1Jueves.Location = new System.Drawing.Point(171, 195);
            this.horaFin1Jueves.Name = "horaFin1Jueves";
            this.horaFin1Jueves.Size = new System.Drawing.Size(72, 20);
            this.horaFin1Jueves.TabIndex = 13;
            this.horaFin1Jueves.Visible = false;
            // 
            // horaInicio1Viernes
            // 
            this.horaInicio1Viernes.Location = new System.Drawing.Point(93, 224);
            this.horaInicio1Viernes.Name = "horaInicio1Viernes";
            this.horaInicio1Viernes.Size = new System.Drawing.Size(72, 20);
            this.horaInicio1Viernes.TabIndex = 16;
            this.horaInicio1Viernes.Visible = false;
            // 
            // horaFin1Viernes
            // 
            this.horaFin1Viernes.Location = new System.Drawing.Point(171, 221);
            this.horaFin1Viernes.Name = "horaFin1Viernes";
            this.horaFin1Viernes.Size = new System.Drawing.Size(72, 20);
            this.horaFin1Viernes.TabIndex = 17;
            this.horaFin1Viernes.Visible = false;
            // 
            // horaInicio1Sabado
            // 
            this.horaInicio1Sabado.Location = new System.Drawing.Point(93, 251);
            this.horaInicio1Sabado.Name = "horaInicio1Sabado";
            this.horaInicio1Sabado.Size = new System.Drawing.Size(72, 20);
            this.horaInicio1Sabado.TabIndex = 20;
            this.horaInicio1Sabado.Visible = false;
            // 
            // horaFin1Sabado
            // 
            this.horaFin1Sabado.Location = new System.Drawing.Point(171, 250);
            this.horaFin1Sabado.Name = "horaFin1Sabado";
            this.horaFin1Sabado.Size = new System.Drawing.Size(72, 20);
            this.horaFin1Sabado.TabIndex = 21;
            this.horaFin1Sabado.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(93, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "Inicio";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(171, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Fin";
            this.label8.Visible = false;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(265, 114);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 34;
            this.monthCalendar1.Visible = false;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(500, 114);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 35;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(322, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Fecha Inicio";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(515, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Fecha Fin";
            this.label12.Visible = false;
            // 
            // listaEspecialidades
            // 
            this.listaEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaEspecialidades.FormattingEnabled = true;
            this.listaEspecialidades.Location = new System.Drawing.Point(93, 15);
            this.listaEspecialidades.Name = "listaEspecialidades";
            this.listaEspecialidades.Size = new System.Drawing.Size(148, 21);
            this.listaEspecialidades.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 17);
            this.label9.TabIndex = 39;
            this.label9.Text = "Especialidad";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(150, 302);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(125, 33);
            this.buttonOK.TabIndex = 42;
            this.buttonOK.Text = "Registrar Agenda";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Visible = false;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 116);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 17);
            this.checkBox1.TabIndex = 43;
            this.checkBox1.Text = "Lunes";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(20, 146);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(58, 17);
            this.checkBox2.TabIndex = 44;
            this.checkBox2.Text = "Martes";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(20, 172);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(71, 17);
            this.checkBox3.TabIndex = 45;
            this.checkBox3.Text = "Miercoles";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(20, 198);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(60, 17);
            this.checkBox4.TabIndex = 46;
            this.checkBox4.Text = "Jueves";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(20, 224);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(61, 17);
            this.checkBox5.TabIndex = 47;
            this.checkBox5.Text = "Viernes";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(20, 253);
            this.checkBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(63, 17);
            this.checkBox6.TabIndex = 48;
            this.checkBox6.Text = "Sabado";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // btnHorarios
            // 
            this.btnHorarios.Location = new System.Drawing.Point(6, 302);
            this.btnHorarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHorarios.Name = "btnHorarios";
            this.btnHorarios.Size = new System.Drawing.Size(129, 33);
            this.btnHorarios.TabIndex = 49;
            this.btnHorarios.Text = "Confirmar Horarios";
            this.btnHorarios.UseVisualStyleBackColor = true;
            this.btnHorarios.Visible = false;
            this.btnHorarios.Click += new System.EventHandler(this.btnHorarios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 15);
            this.label1.TabIndex = 51;
            this.label1.Text = "Ingresar los horarios con el formato de HH:mm";
            this.label1.Visible = false;
            // 
            // RegistroAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 347);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHorarios);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listaEspecialidades);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.horaFin1Sabado);
            this.Controls.Add(this.horaInicio1Sabado);
            this.Controls.Add(this.horaFin1Viernes);
            this.Controls.Add(this.horaInicio1Viernes);
            this.Controls.Add(this.horaFin1Jueves);
            this.Controls.Add(this.horaInicio1Jueves);
            this.Controls.Add(this.horaFin1Miercoles);
            this.Controls.Add(this.horaInicio1Miercoles);
            this.Controls.Add(this.horaFin1Martes);
            this.Controls.Add(this.horaInicio1Martes);
            this.Controls.Add(this.horaFin1Lunes);
            this.Controls.Add(this.horaInicio1Lunes);
            this.Name = "RegistroAgenda";
            this.Text = "RegistroAgenda";
            this.Load += new System.EventHandler(this.RegistroAgenda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Button btnHorarios;
        private System.Windows.Forms.Label label1;
	}
}
