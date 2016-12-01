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


        public SeleccionRol(Int64 idUsuario)
        {
            InitializeComponent();

            //Obtengo la conexion desde la clase "Conexion"
            SqlConnection conexionABase = Conexion.ObtenerConexion();
            string CMD = string.Format("SELECT r.ID_Rol AS Id_Rol, r.Nombre AS Rol from [ANOTHER_CAT].tl_Usuario_Rol as ur join [GD2C2016].[ANOTHER_CAT].tl_rol as R on ur.ID_Rol = r.ID_Rol where ur.ID_Usuario='{0}'", idUsuario);
            SqlCommand comandoLlenado = new SqlCommand(CMD, conexionABase);
            SqlDataAdapter adapter = new SqlDataAdapter(comandoLlenado);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            comboRol.DataSource = dt;
            comboRol.DisplayMember = "Rol";
            comboRol.ValueMember = "Rol";
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

            //int idRolSeleccionado = Convert.ToInt32(comboRol.SelectedValue);
            //string rol = comboRol.Text;
            string rol = comboRol.SelectedValue.ToString();
           // MenuPpal menuPpal = new MenuPpal();
            
            switch (rol)
            {
                case "Administrativo": MenuAdministrativo menuAdm = new MenuAdministrativo();
                    menuAdm.Show(this);
                    break;
                case "Afiliado": MenuPpal menuAfi = new MenuPpal();
                    menuAfi.Show(this);
                    break;
                case "Profesional": MenuProfesional menuProf = new MenuProfesional();
                    menuProf.Show(this);
                    break;
                case "Administrador":
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

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
