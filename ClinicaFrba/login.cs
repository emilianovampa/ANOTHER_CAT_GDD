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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Verifico que se ingresen datos en los campos
            if (Usuario.TextLength > 0 && Contrasenia.TextLength > 0)
            {


                SeleccionRol selecionRolview = new SeleccionRol();


                // antes de ingresar a la pantalla verificar si existe el usuario

                selecionRolview.Show();
                this.Hide();



            }
            else
            {
                MessageBox.Show("Complete todos los campos.", "Advertencia", MessageBoxButtons.OK);
                Usuario.Focus();

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs usuario)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs contraseña)
        {

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
