using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        public PedirTurno()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Centra los componentes, adaptandose al tamaño del monitor//
            Size resolucionPantalla = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            Pedir_Turno.ElegirHorario abmElegirHorario = new Pedir_Turno.ElegirHorario();
            this.Hide();
            abmElegirHorario.ShowDialog();
            this.Close();
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            AbmRol.Rolppal abmRolAfiliado = new AbmRol.Rolppal();
            this.Hide();
            abmRolAfiliado.ShowDialog();
            this.Close();
        }
    }
}
