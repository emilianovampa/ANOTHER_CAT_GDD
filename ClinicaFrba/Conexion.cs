using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace ClinicaFrba
{
    public static class Conexion
    {

        public static SqlConnection ObtenerConexion()
        {

            System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();

            //conexion.ConnectionString = "Server=localhost\\SQLSERVER2008;Database=GD1C2014;User Id=gd;Password=gd2014;";
            //20140717: Tomamos del archivo config la conexión a la BD
            conexion.ConnectionString = "Server=localhost\\SQLSERVER2012;Database=GD2C2016;User Id=gd;Password=gd2016;";

            try
            {
                conexion.Open();
                return conexion;

                // Insert code to process data.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló la conexión con la base de datos");
                return null;
            }

        }

        public static DataSet Ejecutar(string cmd)
        {

            System.Data.SqlClient.SqlConnection conexion = ObtenerConexion();

           
            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, conexion);

            DP.Fill(DS);
            conexion.Close();

            return DS;



        }


        public static DataTable EjecutarComboBox(string cmd)
        {

            System.Data.SqlClient.SqlConnection conexion = ObtenerConexion();
            SqlCommand comandoLlenado = new SqlCommand(cmd, conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(comandoLlenado);
            DataTable dt = new DataTable();
            //Cierro la conexion
           
            adapter.Fill(dt);
            conexion.Close();
            return dt;



        }


        public static void loadDataGrid(string query, DataGridView dgv)
        {
            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
                dataAdapter.Fill(dataTable);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dataTable;
                dgv.DataSource = bSource;
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                conexion.Close();
            }

        }

        //DB: DataBase
        public static SqlConnection DB;
        static string conn = ConfigurationManager.AppSettings["connection-string"];
        //public static DateTime fecha = ConfigTime.getFecha();

        static void ConexionesDB()
        {
            DB = new SqlConnection(conn);
        }

        //SP: StoredProcedure
        public static void ExecuteNonQuery(string SP, Dictionary<string, object> parametros = null)
        {
            if (parametros == null) parametros = new Dictionary<string, object>();
            if (DB != null && DB.State == ConnectionState.Open)
            {
                DB.Close();
            }
            DB.Open();
            SqlCommand command = new SqlCommand("NOT_NULL." + SP, DB);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var parametro in parametros)
            {
                command.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));
            }

            command.ExecuteNonQuery();
            DB.Close();




        }


        public static SqlDataReader ExecuteReader(string SP, Dictionary<string, object> parametros = null)
        {
            if (DB != null && DB.State == ConnectionState.Open)
            {
                DB.Close();
            }
            if (parametros == null) parametros = new Dictionary<string, object>();
            DB.Open();
            SqlCommand command = new SqlCommand("NOT_NULL." + SP, DB);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var parametro in parametros)
            {
                command.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));
            }
            SqlDataReader result = command.ExecuteReader();
            return result;
        }

    }

}