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

                //Obtengo la conexion desde la clase "Conexion"
                SqlConnection conexionABase = Conexion.ObtenerConexion();

                //Instancio el objeto Stored Procedure
                SqlCommand cmdLogin = new SqlCommand("[ANOTHER_CAT].[LOGIN]", conexionABase);
                cmdLogin.CommandType = CommandType.StoredProcedure;

                //Le agrego los parametros
                cmdLogin.Parameters.AddWithValue("@auxnombre", Usuario.Text);

               //cmdLogin.Parameters.AddWithValue("@auxpass", Password.encriptarPassword(Contrasenia.Text).Trim());//encriptada
             cmdLogin.Parameters.AddWithValue("@auxpass", Contrasenia.Text.Trim().ToString());

                //Logica para el manejo de un parametro del tipo OUTPUT
                SqlParameter parametroRetorno = new SqlParameter();
                parametroRetorno.ParameterName = "@RETORNO";
                parametroRetorno.DbType = DbType.Int32;
                parametroRetorno.Direction = ParameterDirection.Output;
                //Agrego los parametros
                cmdLogin.Parameters.Add(parametroRetorno);

                //Logica para el manejo de un parametro del tipo OUTPUT idUsuario
                SqlParameter idUsuario = new SqlParameter();
                idUsuario.ParameterName = "@IDUSUARIO";
                idUsuario.DbType = DbType.Int64;
                idUsuario.Direction = ParameterDirection.Output;
                //Agrego los parametros
                cmdLogin.Parameters.Add(idUsuario);

                //Logica para el manejo de un parametro del tipo OUTPUT cantidadRoles
                SqlParameter cantRoles = new SqlParameter();
                cantRoles.ParameterName = "@CANTROLES";
                cantRoles.DbType = DbType.Int32;
                cantRoles.Direction = ParameterDirection.Output;

                //Agrego los parametros
                 cmdLogin.Parameters.Add(cantRoles);
          


                //Ejecuto el comando SP
                SqlDataReader reader = cmdLogin.ExecuteReader();

                //Obtengo el valor del parametro de tipo OUTPUT del SP
                string resultadoEjecucion = cmdLogin.Parameters["@RETORNO"].Value.ToString();
                Int64 idUser = Int64.Parse(cmdLogin.Parameters["@IDUSUARIO"].Value.ToString());
                Int32 cantRol = Int32.Parse(cmdLogin.Parameters["@CANTROLES"].Value.ToString());

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
                        if (cantRol > 1)
                        {
                            SeleccionRol selecionRolview = new SeleccionRol(idUser);
                            this.Hide();
                            selecionRolview.Show(this);
                        }
                        else
                        {
                             Objetos.Usuario usuarioActual = new Objetos.Usuario();
                            usuarioActual.id_user = idUser;

                            conexionABase = Conexion.ObtenerConexion();
                           // string CMD = string.Format("SELECT  r.Nombre  from [ANOTHER_CAT].tl_Usuario_Rol as ur join [GD2C2016].[ANOTHER_CAT].tl_rol as R on ur.ID_Rol = r.ID_Rol where ur.ID_Usuario='{0}'", idUser);
                            string CMD = string.Format("SELECT  ID_Rol  from [ANOTHER_CAT].tl_Usuario_Rol where ID_Usuario='{0}'", idUser); 
                            SqlCommand comandoLlenado = new SqlCommand(CMD, conexionABase);
                            SqlDataReader ReadRol= comandoLlenado.ExecuteReader();
                            ReadRol.Read();
                           // string rolUsuario = ReadRol[0].ToString();
                           usuarioActual.Id_rol = Int32.Parse(ReadRol[0].ToString());
                           conexionABase.Close();
                            MenuPpal menuPpal = new MenuPpal(usuarioActual);
                            this.Hide();
                            menuPpal.Show(this);
                            }
                            
                       
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
