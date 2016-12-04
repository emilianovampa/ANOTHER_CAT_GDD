using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
            cargarRoles();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea inhabilitar el rol: "+cRoles.Text+"?", "Inhabilitación de rol",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                darDeBaja();
            }
        }

        public void cargarRoles()
        {
            string CMD = string.Format(@"SELECT ID_Rol AS Id_Rol, Nombre AS Rol from [GD2C2016].[ANOTHER_CAT].tl_rol where [Habilitado] = 0 order by 2 asc");
            Conexion.Ejecutar(CMD);
            SqlConnection conexionABase = Conexion.ObtenerConexion();
            SqlCommand comandoLlenado = new SqlCommand(CMD, conexionABase);
            SqlDataAdapter adapter = new SqlDataAdapter(comandoLlenado);
            DataTable dt = new DataTable();
            //Cierro la conexion

            adapter.Fill(dt);


            // cRoles.DataSource = Conexion.EjecutarComboBox(CMD);

            cRoles.DataSource = dt;
            cRoles.DisplayMember = "Rol";
            cRoles.ValueMember = "Id_Rol";

            conexionABase.Close();
        }

        private void darDeBaja()
        {
            SqlConnection conexionBase = Conexion.ObtenerConexion();
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand("ANOTHER_CAT.InhabilitarRol", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@rol", cRoles.SelectedValue);

                comando.ExecuteNonQuery();

                conexionBase.Close();
            }
            cargarRoles();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }
    }
}
