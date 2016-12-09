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


namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Baja : Form
    {

        public Baja()
        {
            InitializeComponent();
        }

        SqlConnection conn = Conexion.ObtenerConexion();

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            using (conn)
            {
                this.darDeBaja();
                this.Close();
            }
        }

        private void darDeBaja()
        {

            
            DialogResult respuesta = MessageBox.Show("¿Desea dar de baja al afiliado?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (respuesta == DialogResult.Yes)
             {
                 conn.Open();

                 SqlCommand command = new SqlCommand("ANOTHER_CAT.DarDeBajaUnAfiliado", conn);
                 command.CommandType = CommandType.StoredProcedure;
                 command.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
                 command.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = DateTime.Today;

                 //Logica para el manejo de un parametro del tipo OUTPUT cantidadRoles
                 SqlParameter Resultado = new SqlParameter();
                 Resultado.ParameterName = "@Resultado";
                 Resultado.DbType = DbType.Int32;
                 Resultado.Direction = ParameterDirection.Output;

                 command.ExecuteNonQuery();
                 conn.Close();
                 Int32 borradoAfiliado = Int32.Parse(command.Parameters["@Resultado"].Value.ToString());

                 if (borradoAfiliado == 0)
                     MessageBox.Show("EL AFILIADO NO EXISTE");
                 else
                     MessageBox.Show("EL AFILIADO HA SIDO DADO DE BAJA SATISFACTORIAMENTE");


                 
             }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            //Abm_Afiliado.Afiliado afiliado = new Abm_Afiliado.Afiliado();
            this.Close();
        }
   
    }
}
