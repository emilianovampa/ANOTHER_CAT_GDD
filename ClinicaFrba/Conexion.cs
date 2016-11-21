using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class Conexion
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

            System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();

            conexion.ConnectionString = "Server=localhost\\ ;Database=GD2C2016;User Id=gd;Password=gd2016;";

            //    SqlConnection conexion = new SqlConnection("Data Source=ELTURKO-PC2\SQLSERVER2012;User ID=gd;Password=gd2016");
            conexion.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, conexion);

            DP.Fill(DS);
            conexion.Close();

            return DS;



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
    }
}