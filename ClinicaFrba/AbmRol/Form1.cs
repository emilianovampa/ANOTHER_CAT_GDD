﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Añadir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El Alta de un Rol no ha sido implementado, ya que para ello primero debe crearse su tabla correspondiente en la Base de Datos.",
                "Funcionalidad no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            AbmRol.Eliminar eliminar = new AbmRol.Eliminar();
            eliminar.Show();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            AbmRol.Editar editar = new AbmRol.Editar();
            editar.Show();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }
    }
}
