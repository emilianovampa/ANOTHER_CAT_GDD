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
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
            cargarRoles();
          
        }


   
        String nombre_rol = "";

        public void obtenerHabilitacion()
        {

            int idRolSeleccionado = Convert.ToInt32(cRoles.SelectedValue);
            string query = string.Format("select distinct(Habilitado) from [ANOTHER_CAT].[tl_Rol] where [ID_Rol]={0}", idRolSeleccionado);
            

            SqlConnection conexionBase = Conexion.ObtenerConexion();
       
                SqlCommand comando = new SqlCommand(query, conexionBase);

                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
               Boolean habilitacion = reader.GetBoolean(0);
                conexionBase.Close();

                if (habilitacion)
            {
                labelStatus.Text = "Habilitado";
                buttonHabilitar.Enabled = false;
            }
            else
            {
                labelStatus.Text = "Inhabilitado";
                buttonHabilitar.Enabled = true;
            }
        }

        public void cargarNombre()
        {

            string query = string.Format("select distinct(Nombre) from [ANOTHER_CAT].[tl_Rol] where [ID_Rol]={0}", Convert.ToInt32(cRoles.SelectedValue));


            SqlConnection conexionBase = Conexion.ObtenerConexion();

            SqlCommand comando = new SqlCommand(query, conexionBase);

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
         

            textNombre.Text = reader.GetString(0);
            nombre_rol = reader.GetString(0);

            conexionBase.Close();

        }

        public List<String> obtenerFuncionalidadesParaAgregar()
        {
            List<String> funcionalidades = new List<String>();
            string CMD = string.Format( "select distinct(func_nombre) from LOS_TRIGGERS.Funcionalidad_Rol, LOS_TRIGGERS.Funcionalidad " +
                            "where funcionalidad NOT IN (select distinct(funcionalidad) " +
                            "from LOS_TRIGGERS.Funcionalidad_Rol where administrador is not null) " +
                            "AND func_id = funcionalidad");

            SqlConnection conexionBase = Conexion.ObtenerConexion();
            using (conexionBase)
            {
                conexionBase.Open();
                SqlCommand comando = new SqlCommand(CMD, conexionBase);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    funcionalidades.Add(reader.GetString(0));
                }
                conexionBase.Close();
            }
            return funcionalidades;
        }

        protected void cargarFuncionalidadesParaAgregar()
        {
             int idRolSeleccionado= Convert.ToInt32(cRoles.SelectedValue);
            //creo query para obetener los id que no pertenecen al rol
             string CMD = string.Format("select RF.ID_Funcionalidad as idFun, RF.Descripcion as Funcionalidad  from ANOTHER_CAT.tl_Funcionalidad as RF " +
                            "where RF.ID_Funcionalidad NOT IN (SELECT  f.ID_Funcionalidad FROM [ANOTHER_CAT].[tl_Rol_Funcionalidad] as R " +
                            "join [ANOTHER_CAT].[tl_Funcionalidad] as F on f.[ID_Funcionalidad] = r. [ID_Funcionalidad] "+
                            "where R.[ID_Rol] = {0}) order by 2 asc", idRolSeleccionado);

             cFuncionalidades.DataSource = Conexion.EjecutarComboBox(CMD);
            cFuncionalidades.DisplayMember = "Funcionalidad";
            cFuncionalidades.ValueMember = "idFun";

           
        }

        public void cargarFuncionalidades()
        {


          int idRolSeleccionado= Convert.ToInt32(cRoles.SelectedValue);
            
            //selecciono funcionaldiad segun rol
          string queryFuncionalidades = string.Format("SELECT f.[ID_Funcionalidad] ,f.Descripcion FROM [GD2C2016].[ANOTHER_CAT].[tl_Rol_Funcionalidad] as R join [ANOTHER_CAT].[tl_Funcionalidad] as F on f.[ID_Funcionalidad] = r. [ID_Funcionalidad] where R.[ID_Rol] = {0}", idRolSeleccionado);


            SqlConnection conexionBase = Conexion.ObtenerConexion();
            using (conexionBase)
            {
               
                SqlCommand comando = new SqlCommand(queryFuncionalidades, conexionBase);

                DataTable funcionalidades = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(funcionalidades);

                conexionBase.Close();


                gridFuncionalidades.DataSource = funcionalidades;

                
            }
        }

        public void cargarRoles()
        {

            string CMD = string.Format(@"SELECT ID_Rol AS Id_Rol, Nombre AS Rol from [GD2C2016].[ANOTHER_CAT].tl_rol order by 2 asc");
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

        private void cRoles_SelectionChangeCommitted(object sender, EventArgs e)
        {

           
            cargarNombre();
            cargarFuncionalidadesParaAgregar();
            cargarFuncionalidades();
            obtenerHabilitacion();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void habilitarRol()
        {
            SqlConnection conexionBase = Conexion.ObtenerConexion();
            using (conexionBase)
            {
                SqlCommand comando = new SqlCommand("ANOTHER_CAT.habilitarRol", conexionBase);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idrol", cRoles.SelectedValue);

                comando.ExecuteNonQuery();

                conexionBase.Close();
            }
            obtenerHabilitacion();
        }

        private void buttonHabilitar_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("¿Está seguro de que desea habilitar el rol: " + cRoles.Text + "?", "Habilitación de rol",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                habilitarRol();
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de agregar la funcionalidad: " + cFuncionalidades.Text + "?", "Agregar Funcionalidad",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conexionBase = Conexion.ObtenerConexion();
                using (conexionBase)
                {
                 
                    SqlCommand cmd = new SqlCommand("[ANOTHER_CAT].AgregarFuncionalidadAUnRol", conexionBase);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idrol", Convert.ToInt32(cRoles.SelectedValue));
                    cmd.Parameters.AddWithValue("@idfuncionalidad", cFuncionalidades.SelectedValue);
                    cmd.ExecuteNonQuery();

                    conexionBase.Close();
                }
                cargarFuncionalidadesParaAgregar();
                cargarFuncionalidades();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de quitar la funcionalidad: "
                + gridFuncionalidades.SelectedRows[0].Cells[0].Value.ToString() + "?", "Eliminar Funcionalidad",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conexionBase = Conexion.ObtenerConexion();
                using (conexionBase)
                {
                  
                    SqlCommand cmd = new SqlCommand("[ANOTHER_CAT].QuitarFuncionalidadAUnRol", conexionBase);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idrol", Convert.ToInt32(cRoles.SelectedValue));
                    cmd.Parameters.AddWithValue("@idfuncionalidad", gridFuncionalidades.SelectedRows[0].Cells[0].Value);
                    cmd.ExecuteNonQuery();

                    conexionBase.Close();
                }
                cargarFuncionalidadesParaAgregar();
                cargarFuncionalidades();
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del Rol.", "No se ha indicado un nombre",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de cambiar el nombre de: " + nombre_rol + " a: " + textNombre.Text + "?",
                    "Cambiar Nombre", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conexionBase = Conexion.ObtenerConexion();
                    using (conexionBase)
                    {
                        string se = cRoles.SelectedValue.ToString();
                        SqlCommand cmd = new SqlCommand("ANOTHER_CAT.ModificarRol", conexionBase);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rol", Convert.ToInt32(cRoles.SelectedValue));
                        cmd.Parameters.AddWithValue("@nuevo_nombre", textNombre.Text);
                        cmd.ExecuteNonQuery();

                        conexionBase.Close();
                    }
                    cargarNombre();
                    cargarRoles();
                }
            }
        }

        private void cRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    int idRolSeleccionado = Convert.ToInt32(cRoles.SelectedValue);
        }



    }
}
