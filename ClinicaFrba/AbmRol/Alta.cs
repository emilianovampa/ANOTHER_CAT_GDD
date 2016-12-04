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
    public partial class Alta : Form
    {
        Int64 idRol;
        public Alta()
        {
            InitializeComponent();
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void CrearRol_Click(object sender, EventArgs e)
        {
            if (textNombre.TextLength > 0)
            {
                if (MessageBox.Show("¿Está seguro de Crear el rol: " + textNombre.Text + "?", "Crear Rol",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conexionBase = Conexion.ObtenerConexion();
                    using (conexionBase)
                    {

                        SqlCommand cmd = new SqlCommand("[ANOTHER_CAT].CrearRol", conexionBase);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@rol", textNombre.Text);



                        //Logica para el manejo de un parametro del tipo OUTPUT 
                        SqlParameter rol = new SqlParameter();
                        rol.ParameterName = "@idrol";
                        rol.DbType = DbType.Int64;
                        rol.Direction = ParameterDirection.Output;
                        //Agrego los parametros
                        cmd.Parameters.Add(rol);

                        cmd.ExecuteReader();


                        idRol = Int64.Parse(cmd.Parameters["@idrol"].Value.ToString());

                        conexionBase.Close();

                        cargarFuncionalidadesParaAgregar();
                        cargarFuncionalidades();
                    }


                }
                else
                {
                    MessageBox.Show("Complete todos los campos.", "Advertencia", MessageBoxButtons.OK);
                    textNombre.Focus();
                }

            }
        }

        

        protected void cargarFuncionalidadesParaAgregar()
        {
            
            //creo query para obetener los id que no pertenecen al rol
            string CMD = string.Format("select RF.ID_Funcionalidad as idFun, RF.Descripcion as Funcionalidad  from ANOTHER_CAT.tl_Funcionalidad as RF " +
                           "where RF.ID_Funcionalidad NOT IN (SELECT  f.ID_Funcionalidad FROM [ANOTHER_CAT].[tl_Rol_Funcionalidad] as R " +
                           "join [ANOTHER_CAT].[tl_Funcionalidad] as F on f.[ID_Funcionalidad] = r. [ID_Funcionalidad] " +
                           "where R.[ID_Rol] = {0}) order by 2 asc", idRol);

            cFuncionalidades.DataSource = Conexion.EjecutarComboBox(CMD);
            cFuncionalidades.DisplayMember = "Funcionalidad";
            cFuncionalidades.ValueMember = "idFun";


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
                    cmd.Parameters.AddWithValue("@idrol", idRol);
                    cmd.Parameters.AddWithValue("@idfuncionalidad", cFuncionalidades.SelectedValue);
                    cmd.ExecuteNonQuery();

                    conexionBase.Close();
                }
                cargarFuncionalidadesParaAgregar();
                cargarFuncionalidades();
                
            }


        }

        public void cargarFuncionalidades()
        {


            

            //selecciono funcionaldiad segun rol
            string queryFuncionalidades = string.Format("SELECT f.[ID_Funcionalidad] ,f.Descripcion FROM [GD2C2016].[ANOTHER_CAT].[tl_Rol_Funcionalidad] as R "+
                "join [ANOTHER_CAT].[tl_Funcionalidad] as F on f.[ID_Funcionalidad] = r. [ID_Funcionalidad] where R.[ID_Rol] = {0}", idRol);


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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }
    
    
    }
}

