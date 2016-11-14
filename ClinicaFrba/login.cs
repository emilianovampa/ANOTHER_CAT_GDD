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
    public partial class login : Form
    {
        

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
            
        {
          
            //Verifico que se ingresen datos en los campos


            if (Usuario.TextLength > 0 && Contrasenia.TextLength > 0)
            {

                ////Obtengo la conexion desde la clase "Conexion"
                //SqlConnection conexionABase = Conexion.ObtenerConexion();

                //string CMD = string.Format("SELECT * FROM [GD2C2016].[ANOTHER_CAT].[tl_Usuario] where [Username] = '{0}'", Usuario.Text.Trim());

                //DataSet ds = Conexion.Ejecutar(CMD);


                //Obtengo la conexion desde la clase "Conexion"
                SqlConnection conexionABase = Conexion.ObtenerConexion();

                //Instancio el objeto Stored Procedure
                SqlCommand cmdLogin = new SqlCommand("[ANOTHER_CAT].[LOGIN]", conexionABase);
                cmdLogin.CommandType = CommandType.StoredProcedure;

                //Le agrego los parametros
                cmdLogin.Parameters.AddWithValue("@auxnombre", Usuario.Text);

                cmdLogin.Parameters.AddWithValue("@auxpass", Password.encriptarPassword(Contrasenia.Text.Trim()));//encriptada


                // cmdLogin.Parameters.AddWithValue("@idrol", idRolSeleccionado);

                //Logica para el manejo de un parametro del tipo OUTPUT
                SqlParameter parametroRetorno = new SqlParameter();
                parametroRetorno.ParameterName = "@RETORNO";
                parametroRetorno.DbType = DbType.Int32;
                parametroRetorno.Direction = ParameterDirection.Output;
                //Agrego dicho parametro
                cmdLogin.Parameters.Add(parametroRetorno);
                //Logica para el manejo de un parametro del tipo OUTPUT idUsuario
                SqlParameter idUsuario = new SqlParameter();
                idUsuario.ParameterName = "@IDUSUARIO";
                idUsuario.DbType = DbType.Int64;
                idUsuario.Direction = ParameterDirection.Output;
                //Agrego dicho parametro
                cmdLogin.Parameters.Add(idUsuario);
               


                //Ejecuto el comando SP
                SqlDataReader reader = cmdLogin.ExecuteReader();

                //Obtengo el valor del parametro de tipo OUTPUT del SP
                string resultadoEjecucion = cmdLogin.Parameters["@RETORNO"].Value.ToString();
                Int64 idUser = Int64.Parse(cmdLogin.Parameters["@IDUSUARIO"].Value.ToString());

                //Cierro la conexion
                conexionABase.Close();

                //Evaluo el resultado de la ejecucion del SP e informo el resultado
                //Resultado = 0 ==> Login Correcto
                //Resultado = 1 ==> Contraseña incorrecta
                //Resultado = 2 ==> El Usuario está inhabilitado
                //Resultado = 3 ==> Ingresó mal la clave 3 veces. Se inhabilitó usuario
                   switch (resultadoEjecucion)
                {
                    case "0":
                        //Esta todo OK. 

                        SeleccionRol selecionRolview = new SeleccionRol(idUser);
                        this.Hide();
                        selecionRolview.Show(this);
                       // this.Close();
                        break;
                    case "1":
                        MessageBox.Show("Contraseña Incorrecta");
                        break;
                    case "2":
                        MessageBox.Show("Su Usuario está inhabilitado. Contactar Administrador");
                        break;
                    case "3":
                        MessageBox.Show("Usted ha sido inhabilitado. Ingresó mal la clave 3 veces");
                        break;
                }

            }
            else
            {
                MessageBox.Show("Complete todos los campos.", "Advertencia", MessageBoxButtons.OK);
                Usuario.Focus();

            }
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

    }
}
