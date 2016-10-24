using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class SeleccionRol : Form
    {
        public SeleccionRol()
        {
            InitializeComponent();
        }

        private void roles_Load(object sender, EventArgs e)
        {

        }

        private void ingresarRol_Click(object sender, EventArgs e)
        {

        }

        private void ingresarRol_Click_1(object sender, EventArgs e)
        {
            MenuPpal menuPpal = new MenuPpal();
            this.Hide();
            menuPpal.Show();
        }

        private void SeleccionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
