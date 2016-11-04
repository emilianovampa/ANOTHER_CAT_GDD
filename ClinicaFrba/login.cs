using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Data;


namespace ClinicaFrba
{
    public partial class login : Form
    {
        

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
            
        {
          
            //Verifico que se ingresen datos en los campos


            if (Usuario.TextLength > 0 && Contrasenia.TextLength > 0)
            {

                string CMD = string.Format("SELECT * FROM tl_Usuario where Username = {0}", Usuario.Text.Trim());

                DataSet ds = Conexion.Ejecutar(CMD);

               SeleccionRol selecionRolview = new SeleccionRol();



                // antes de ingresar a la pantalla verificar si existe el usuario

                selecionRolview.Show(this);
                this.Hide();



            }
            else
            {
                MessageBox.Show("Complete todos los campos.", "Advertencia", MessageBoxButtons.OK);
                Usuario.Focus();

            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

    }
}
