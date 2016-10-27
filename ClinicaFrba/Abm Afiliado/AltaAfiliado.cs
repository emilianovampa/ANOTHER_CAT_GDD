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
            this.Owner.Show();

        }

        private void GuardarAF_Click(object sender, EventArgs e)
        {
            //Falta verificar todos los campos y armar la consulta para el alta

            DialogResult respuesta;
            int cantidadFamiliares=int.Parse(FamAF.Text);
            //Verifico que tenga conyuge o familia a cargo
                
            if (EstadoAF.SelectedIndex == 1 || EstadoAF.SelectedIndex == 3 || cantidadFamiliares > 0)
            {
                //Si tiene conyuge, tiene que ser el afiliado principal
               if ((EstadoAF.SelectedIndex == 1 || EstadoAF.SelectedIndex == 3)&&(finLegajo==1))
               { 
                respuesta = MessageBox.Show("¿Desea afiliar compañero/a?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                { //Si agrego al conyuge, aumento el finLegajo para que termine en 2
                    finLegajo++;
                    Abm_Afiliado.AltaAfiliado conyuge = new Abm_Afiliado.AltaAfiliado();
                    conyuge.ShowDialog(this);
                    //Verifico si ademas posee familiares a cargo y si es asi, voy a aumentar cada vez que acepte afiliar a uno
                    if (cantidadFamiliares != 0)
                    {
                        respuesta = MessageBox.Show("¿Desea afiliar familiares?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        while (cantidadFamiliares > 0)
                        {
                            preguntarPorFamiliares(respuesta);
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
                        respuesta = MessageBox.Show("¿Desea afiliar familiares?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        while (cantidadFamiliares > 0)
                        {
                            preguntarPorFamiliares(respuesta);
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
               {  //Si verifico era el afiliado principal, entonces tenia familiares a cargo.
                   if (finLegajo==1)
                   {
                       finLegajo++;
                       respuesta = MessageBox.Show("¿Desea afiliar familiares?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                       while (cantidadFamiliares > 0)
                       {
                           preguntarPorFamiliares(respuesta);
                           cantidadFamiliares--;

                       }
                       finLegajo = 1;
                       guardarAfiliado();
                   } //Si no era el afiliado principal, entonces no me interesa y guardo como esta.
                   else
                   {
                       guardarAfiliado();
                   }
               }
            }
            else
            { //Guardo afiliado si no esta en pareja y no tiene familia a cargo.
                guardarAfiliado();
            }
            
        }

        private void preguntarPorFamiliares(DialogResult respuesta)
        {
            if (respuesta == DialogResult.Yes)
            {
                Abm_Afiliado.AltaAfiliado familiar = new Abm_Afiliado.AltaAfiliado();
                finLegajo++;
                familiar.ShowDialog();

            }
        
        }

        private void guardarAfiliado()
        {

            string legajo = inicioLegajo.ToString() + "0" + finLegajo.ToString();
            //Guardar en la base de datos armando la consulta con el codigo de afiliado
            MessageBox.Show("¡Ehnorabuena, se ha añadido un nuevo afiliado! "+ "Legajo: "+ legajo, "¡Congratulations!", MessageBoxButtons.OK);
            if (finLegajo != 1)
            {
                this.Hide();
            }
            else
            {
                this.Close();
            }
        }
    }
}
