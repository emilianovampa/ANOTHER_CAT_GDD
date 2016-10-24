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
    public partial class MenuPpal : Form
    {
        public MenuPpal()
        {
            InitializeComponent();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void MenuPpal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
           //Depende el rol, se abre menu

            MenuAfiliado menuAfiliado = new MenuAfiliado();
            menuAfiliado.Show();

            /*  MenuAdminsitrativo menuAdministrativo = new MenuAdminsitrativo();
              menuAdministrativo.Show();

              MenuProfesional menuProf = new MenuProfesional();
              menuProf.Show();
              */

        }

        private void MenuPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

      
    }
}
