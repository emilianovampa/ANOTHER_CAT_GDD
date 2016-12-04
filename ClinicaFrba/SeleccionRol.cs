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
namespace ClinicaFrba
{
    public partial class SeleccionRol : Form
    {
        Objetos.Usuario UsuarioActual = new Objetos.Usuario(); 

        public SeleccionRol(Int64 idUsuario)
        {
            InitializeComponent();
            UsuarioActual.id_user = idUsuario;
            //Obtengo la conexion desde la clase "Conexion"
            SqlConnection conexionABase = Conexion.ObtenerConexion();
            string CMD = string.Format("SELECT r.ID_Rol AS Id_Rol, r.Nombre AS Rol from [ANOTHER_CAT].tl_Usuario_Rol as ur join [GD2C2016].[ANOTHER_CAT].tl_rol as R on ur.ID_Rol = r.ID_Rol where ur.ID_Usuario='{0}'", idUsuario);
            SqlCommand comandoLlenado = new SqlCommand(CMD, conexionABase);
            SqlDataAdapter adapter = new SqlDataAdapter(comandoLlenado);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            comboRol.DataSource = dt;
            comboRol.DisplayMember = "Rol";
            comboRol.ValueMember = "ID_Rol";
            //Cierro la conexion
            conexionABase.Close();

        }

        private void roles_Load(object sender, EventArgs e)
        {

        }

        private void ingresarRol_Click(object sender, EventArgs e)
        {
            

        }

        private void ingresarRol_Click_1(object sender, EventArgs e)
        {

            UsuarioActual.Id_rol = Convert.ToInt32(comboRol.SelectedValue);
            UsuarioActual.DescripcionRol= comboRol.Text;
           // string rol = comboRol.SelectedValue.ToString();


            MenuPpal menuPpal = new MenuPpal(UsuarioActual);
            menuPpal.Show(this);
                    

            this.Hide();
  
        }

        private void SeleccionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void SeleccionRol_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
          
        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
