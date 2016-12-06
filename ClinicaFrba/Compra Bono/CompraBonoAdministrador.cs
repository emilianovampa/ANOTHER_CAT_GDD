﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBonoAdministrador : Form
    {
        public CompraBonoAdministrador()
        {
            InitializeComponent();
            textBox_afil_CantBonos.MaxLength = 2;
            labelMonto.Text = "$ -";
            labelStatus.Text = "";
            habilitarControles(false);
        }

        protected Boolean verificarHabilitacion()
        {
            SqlConnection conn = Conexion.ObtenerConexion();
            using (conn)
            {
                conn.Open();
                string afil_habilitacion = "select Habilitado from [ANOTHER_CAT].tl_Afiliado where Numero_Afiliado = " + textBox_afil_numero.Text;
                SqlCommand command = new SqlCommand(afil_habilitacion, conn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                bool habilitacion = reader.GetBoolean(0);
                reader.Close();
                conn.Close();

                return habilitacion;
            }
        }
        protected String verificarQueExistaElAfiliado()
        {
            String nombreAfiliado = "";
            SqlConnection conn = Conexion.ObtenerConexion();
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select Apellido +', '+ Nombre as nombre_y_apellido " +
                                                    "from [ANOTHER_CAT].tl_Usuario where Username = " + textBox_afil_numero.Text, conn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows) nombreAfiliado = reader.GetString(0);

                reader.Close();
                conn.Close();

                return nombreAfiliado;
            }
        }

        protected void calcularMontoAPagar()
        {
            SqlConnection conn = Conexion.ObtenerConexion();
            using (conn)
            {
                conn.Open();
                SqlCommand command = new SqlCommand("select Precio_Bono_Consulta from [ANOTHER_CAT].tl_Plan_Medico " +
                                                     "where Id_Plan_Medico = (select Id_Plan_Medico from [ANOTHER_CAT].tl_Afiliado " +
                                                     "where Numero_Afiliado = @afiliado)", conn);
                command.Parameters.AddWithValue("@afiliado", Convert.ToDecimal(textBox_afil_numero.Text));
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                decimal precio = reader.GetDecimal(0);
                decimal totalAPagar = precio * Convert.ToDecimal(textBox_afil_CantBonos.Text);
                labelMonto.Text = "$ " + totalAPagar.ToString();
                conn.Close();
            }
        }

        protected void habilitarControles(Boolean valor)
        {
            button_confirmar.Enabled = valor;
            buttonMonto.Enabled = valor;
            textBox_afil_CantBonos.Enabled = valor;
        }

        /**************************************************************************************************
        *                                   EVENTOS DEL FORM                                              *
        ***************************************************************************************************/

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            //validar que los campos esten completos
            if (string.IsNullOrEmpty(textBox_afil_numero.Text) || string.IsNullOrEmpty(textBox_afil_CantBonos.Text))
            {
                MessageBox.Show("Debe ingresar el número de Afiliado y/o la cantidad de bonos a comprar.", "Hay campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Se realiza la compra, y muestro el Total a pagar
                calcularMontoAPagar();

                if (MessageBox.Show("¿Está seguro de realizar la compra de " + textBox_afil_CantBonos.Text +
                " bonos por " + labelMonto.Text + "?", "Confirmación de la Compra", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection conn = Conexion.ObtenerConexion();
                    using (conn)
                    {
                        //confirmar la compra
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[ANOTHER_CAT].tl_Compra_Bono", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@afiliado", SqlDbType.Decimal).Value = textBox_afil_numero.Text;
                        cmd.Parameters.AddWithValue("@cantBonos", SqlDbType.VarChar).Value = textBox_afil_CantBonos.Text;
                        cmd.Parameters.AddWithValue("@fecha_sistema", SqlDbType.DateTime).Value = ClinicaFrba.fecha.fechaActual;
                        cmd.ExecuteNonQuery();

                        //limpio los campos
                        textBox_afil_numero.Text = "";
                        textBox_afil_CantBonos.Text = "";
                        labelStatus.Text = "";
                        labelMonto.Text = "$ -";
                        habilitarControles(false);
                        conn.Close();
                    }
                    MessageBox.Show("La Compra se ha realizado con éxito.", "Resultado de la Compra",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de esta funcionalidad ahora?", "Confirmar Salida",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Hide();
        }

        private void buttonMonto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_afil_CantBonos.Text))
            {
                MessageBox.Show("Por favor, indique la cantidad de Bonos a comprar.", "No se ha indicado una cantidad",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else calcularMontoAPagar();
        }

        private void buttonHabilitacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_afil_numero.Text))
            {
                MessageBox.Show("Debe ingresar el número de Afiliado a validar.", "Hay campos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String nombreAfiliado = verificarQueExistaElAfiliado();
                if (nombreAfiliado != "")
                {
                    if (!verificarHabilitacion())
                    {
                        labelStatus.Text = "El afiliado " + nombreAfiliado + " se encuentra actualmente inhabilitado.";
                        habilitarControles(false);
                    }
                    else
                    {
                        labelStatus.Text = "El afiliado " + nombreAfiliado + " se encuentra actualmente habilitado.";
                        habilitarControles(true);
                    }
                }
                else
                {
                    labelStatus.Text = "El afiliado Nº " + textBox_afil_numero.Text + " no pertenece al sistema.";
                    habilitarControles(false);
                }
            }
        }
    }
}