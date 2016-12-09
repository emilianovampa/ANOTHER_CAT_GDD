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


    public partial class
        Modificacion : Form
    {

        public Modificacion()
        {
            InitializeComponent();
        }

        public class Plan
        {
            public decimal id { get; set; }
            public string descripcion { get; set; }

            public Plan(decimal _id, string _descripcion)
            {
                this.id = _id;
                this.descripcion = _descripcion;
            }
        }

        SqlConnection conn = Conexion.ObtenerConexion();

        private void modificacion_Afiliado_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion() )
            {
                this.llenarComboPLan(comboBox_afil_plan);
                this.llenarComboEstadoCivil(comboBox_afil_estadoCivil);
            }
        }

        private void llenarComboPLan(ComboBox combo)
        {
            string CMD = string.Format("SELECT ID_Plan_Medico AS idPlan, Descripcion AS planMedico from ANOTHER_CAT.tl_Plan_Medico order by Descripcion asc");
            comboBox_afil_plan.DataSource = Conexion.EjecutarComboBox(CMD);
            comboBox_afil_plan.DisplayMember = "planMedico";
            comboBox_afil_plan.ValueMember = "idPlan";
        }

        private void llenarComboEstadoCivil(ComboBox estado)
        {
            estado.Items.Add("Soltero/a");
            estado.Items.Add("Casado/a");
            estado.Items.Add("Viudo/a");
            estado.Items.Add("Concubinato");
            estado.Items.Add("Divorciado/a");
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_afil_numero.Text))
            {
                MessageBox.Show("Debe ingresar el número de Afiliado");

                return;
            }

            if (!string.IsNullOrEmpty(textBox_afil_Direccion.Text))
            {
                this.modificarDireccion();
            }

            if (!string.IsNullOrEmpty(comboBox_afil_estadoCivil.Text))
            {
                this.modificarEstadoCivil();
            }

            if (!string.IsNullOrEmpty(textBox_afil_telefono.Text))
            {
                this.modificarTelefono();
            }

            if (!string.IsNullOrEmpty(textBox_afil_mail.Text))
            {
                this.modificarMail();
            }

            if (!string.IsNullOrEmpty(comboBox_afil_plan.Text))
            {
                if (string.IsNullOrEmpty(richTextBox_afil_motivo.Text))
                {
                    MessageBox.Show("Debe ingresar un motivo que justifique el cambio de plan");
                    return;
                }
                this.modificarPlan();
            }
            this.Close();
        }

        private void modificarDireccion()
        {
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoDireccion", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
            //cmd.Parameters.AddWithValue("@nueva_direccion", SqlDbType.VarChar).Value = textBox_afil_Direccion.Text;
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        private void modificarEstadoCivil()
        {
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoEstadoCivil", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
            //cmd.Parameters.AddWithValue("@nuevoEstadoCivil", SqlDbType.VarChar).Value = comboBox_afil_estadoCivil.Text;
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        private void modificarTelefono()
        {
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoTelefono", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
            //cmd.Parameters.AddWithValue("@nuevo_telefono", SqlDbType.Decimal).Value = textBox_afil_telefono.Text;
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        private void modificarMail()
        {
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoMail", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
            //cmd.Parameters.AddWithValue("@nuevo_mail", SqlDbType.VarChar).Value = textBox_afil_mail.Text;
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        private void modificarPlan()
        {
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("LOS_TRIGGERS.ModificarAfiliadoPlanMedico", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
            //cmd.Parameters.AddWithValue("@nuevo_plan", SqlDbType.Decimal).Value = comboBox_afil_plan.SelectedValue;
            //cmd.Parameters.AddWithValue("@motivo", SqlDbType.VarChar).Value = richTextBox_afil_motivo.Text;
            //cmd.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
            //cmd.ExecuteNonQuery();
            //conn.Close();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void BuscarAF_Click(object sender, EventArgs e)
        {
            if (textBox_afil_numero.Text == "")
                MessageBox.Show("Debe ingresar un numero de Afiliado para poder buscar", "Error de búsqueda");
            else
            {

            Int64 idAfiliado = Int64.Parse(textBox_afil_numero.Text.Trim());
         //selecciono 
          string queryDatosAf = string.Format("select AF.[ID_Plan_Medico], AF.[Estado_Civil],US.[Direccion], US.[Telefono],US.[Mail] from [ANOTHER_CAT].[tl_Afiliado] as AF"+
                                        "JOIN [ANOTHER_CAT].[tl_Usuario] AS US ON AF.[ID_Afiliado]= US.ID_Usuario WHERE AF.Numero_Afiliado={0}", idAfiliado);
            SqlConnection conexionBase = Conexion.ObtenerConexion();
            using (conexionBase)
            {

                SqlCommand comando = new SqlCommand(queryDatosAf, conexionBase);
                DataSet afiliadoDatos = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(afiliadoDatos);
                conexionBase.Close();

                label_Mail.Text = afiliadoDatos.Tables[0].Rows[0][4].ToString();


            }

            }


        }

    }
}
