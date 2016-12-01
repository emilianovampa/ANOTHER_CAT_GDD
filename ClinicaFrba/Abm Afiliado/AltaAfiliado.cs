using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class AltaAfiliado : Form
    {

        public static int finLegajo;
        public static  int inicioLegajo;
        private static Abm_Afiliado.AltaAfiliado _instancia;

        public static Abm_Afiliado.AltaAfiliado getInstance()
        {
            if(_instancia==null)
            {
                _instancia=new Abm_Afiliado.AltaAfiliado();
            }
            return _instancia;
        }
        

        public AltaAfiliado()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AltaAfiliado_Load(object sender, EventArgs e)
        {
            NombreAF.Focus();
            EstadoAF.SelectedIndex = 0;
            
        }

        private void LimpiarAF_Click(object sender, EventArgs e)
        {
            NombreAF.Text = "";
            ApellidoAF.Text = "";
            TipoAF.Text = "";
            DocAF.Text = "";
            DomAF.Text = "";
            TelAF.Text = "";
            MailAF.Text = "";
            NacAF.Text = "";
            EstadoAF.SelectedIndex = 0;
            FamAF.Text = "";
            PlanAF.Text = "";
            if (Sex2.Checked == true)
            {
                Sex1.Checked = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            NacAF.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
            monthCalendar1.Hide();
        }

        private void AltaAfiliado_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void AltaAfiliado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finLegajo == 1)
            {
                _instancia = null;
                this.Owner.Show();
            }
            else
            {
                getInstance();
            }

        }

        private void GuardarAF_Click(object sender, EventArgs e)
        {
            //Falta verificar todos los campos y armar la consulta para el alta

            DialogResult respuesta;
            int cantidadFamiliares=int.Parse(FamAF.Text);
            //Si es el afiliado principal verifico, sino voy directo a guardarlo.
            if (finLegajo==1)
            {
                //Si tiene conyuge
               if (EstadoAF.SelectedIndex == 1 || EstadoAF.SelectedIndex == 3)
               { 
                respuesta = MessageBox.Show("¿Desea afiliar compañero/a?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                { //Si agrego al conyuge, aumento el finLegajo para que termine en 2
                    
                    finLegajo++;  //Pasa a ser 2
                    Abm_Afiliado.AltaAfiliado conyuge = new Abm_Afiliado.AltaAfiliado();
                    conyuge.ShowDialog();
                    //Verifico si ademas posee familiares a cargo y si es asi, voy a aumentar cada vez que acepte afiliar a uno
                    if (cantidadFamiliares != 0)
                    {
                         while (cantidadFamiliares > 0)
                        {
                            respuesta = MessageBox.Show("¿Desea afiliar familiares?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (respuesta == DialogResult.Yes)
                            {
                               
                                Abm_Afiliado.AltaAfiliado familiar = new Abm_Afiliado.AltaAfiliado();
                                finLegajo++;
                                familiar.ShowDialog();

                            }
                            cantidadFamiliares--;

                        }
                        //Luego que termino de preguntar por todos los familiares a cargo, recupero el finLegajo en 1 y guardo
                        finLegajo = 1;
                        guardarAfiliado();
            
                    }
                    else
                    {  //Caso que no tenga ningun familiar a cargo, vuelvo al valor finLegajo en 1
                        finLegajo--;
                        guardarAfiliado();
                    }
                }
                else
                { //No quiso afiliar al conyuge, verificamos que tenga familia a cargo
                    if (cantidadFamiliares != 0)
                    {
                        finLegajo++;
                        while (cantidadFamiliares > 0)
                        {
                            respuesta = MessageBox.Show("¿Desea afiliar familiares?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (respuesta == DialogResult.Yes)
                            {
                                
                                Abm_Afiliado.AltaAfiliado familiar = new Abm_Afiliado.AltaAfiliado();
                                finLegajo++;
                                familiar.ShowDialog();

                            }
                            cantidadFamiliares--;

                        }
                        //Luego que termino de preguntar por todos los familiares a cargo, recupero el finLegajo en 1 y guardo
                        finLegajo = 1;
                        guardarAfiliado();
                    }
                    else
                    {
                        //Como no posee familia a cargo, guardo
                        
                        guardarAfiliado();
                    }
                }
               }

               else
               {  //Verifico si tiene personas a cargo
                   if (cantidadFamiliares!=0)
                   {
                       finLegajo++;
      
                       while (cantidadFamiliares > 0)
                       {
                           respuesta = MessageBox.Show("¿Desea afiliar familiares?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                           if (respuesta == DialogResult.Yes)
                           {
                               Abm_Afiliado.AltaAfiliado familiar = new Abm_Afiliado.AltaAfiliado();
                               finLegajo++;
                               familiar.ShowDialog();

                           }
                           cantidadFamiliares--;

                       }
                       finLegajo = 1;
                       guardarAfiliado();
                   } //No tiene personas a cargo, guardo
                   else
                   {
                       guardarAfiliado();
                   }
               }
            }
            else
            { //Guardo afiliado que no es el principal
                guardarAfiliado();
            }
            
        }


        private void guardarAfiliado()
        {

            string legajo = inicioLegajo.ToString() + "0" + finLegajo.ToString();
            //Guardar en la base de datos armando la consulta con el codigo de afiliado

            //var afiliado = new Dictionary<string, object>()
            //        {
                   
            //            { "@Username", txtNombre.Text+txtApellido.Text+txtDni.Text.ToString()},
            //            { "@Nombre", txtNombre.Text },
            //            {"@TipoDocumento", tipodni},
            //            { "@Apellido", txtApellido.Text },
            //            { "@Dni", Convert.ToInt32(txtDni.Text)  },
            //            { "@Mail",  txtMail.Text  },
            //            { "@Telefono", txtTelefono.Text  },
            //            { "@Direccion",txtDireccion.Text  },
            //            { "@CantHijos",  0 },
            //            { "@EstadoCivil", cmbEstadoCivil.Text.Substring(0,1)},
            //            { "@Fecha", dtpFecha.Value},
            //            { "@Plan", Convert.ToDecimal(planElegido.Id) },
            //            { "@Sexo", cmbSexo.Text.Substring(0,1)},
            //        };

            //if (Alta(afiliado))
            //{
            //    Close();
            //}

            MessageBox.Show("¡Ehnorabuena, se ha añadido un nuevo afiliado! "+ "Legajo: "+ legajo, "¡Congratulations!", MessageBoxButtons.OK);

            if (finLegajo == 1)
            {
                this.Owner.Show();
            }
            else
            {
                getInstance().Show();
            }
            this.Close();
        }


        //private bool Alta(Dictionary<string, object> afiliado)
        //{
        //    try
        //    {
        //        //ConexionesDB.ExecuteNonQuery("Afiliado_Add", afiliado);
        //        //ConexionesDB.ExecuteNonQuery("Hijos_En_Cero", new Dictionary<string, object> { { "@username", txtNombre.Text + txtApellido.Text + txtDni.Text.ToString() } });
        //    }
        //    catch
        //    {
        //        MessageBox.Show("No se pudo agregar el afiliado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //}
    }


}
