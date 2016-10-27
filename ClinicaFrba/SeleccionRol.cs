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
            string rol = comboBox1.Text;
           // MenuPpal menuPpal = new MenuPpal();
            
            switch (rol)
            {
                case "Administrador": MenuAdministrativo menuAdm = new MenuAdministrativo();
                    menuAdm.Show(this);
                    break;
                case "Afiliado": MenuAfiliado menuAfi = new MenuAfiliado();
                    menuAfi.Show(this);
                    break;
                case "Profesional": MenuProfesional menuProf = new MenuProfesional();
                    menuProf.Show(this);
                    break;
            }
            this.Hide();
           // menuPpal.Show();
        }

        private void SeleccionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void SeleccionRol_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
          
        }
    }
}
