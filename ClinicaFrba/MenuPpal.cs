using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class MenuPpal : Form
    {
        public MenuPpal(Objetos.Usuario usuarioActual)
        {
            InitializeComponent();


            
        }

        private void comprarBonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra_Bono.ComprarBono comprarBonoABM = new Compra_Bono.ComprarBono();
            comprarBonoABM.MdiParent = this;
            comprarBonoABM.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pedirTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Pedir_Turno.PedirTurno pedirTurnoAbm = new Pedir_Turno.PedirTurno();
       //     pedirTurnoAbm.MdiParent = this;
         //   pedirTurnoAbm.Show();
        }

        private void cancelarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    Cancelar_Atencion.CancelarAtencionAfiliado cancelarTurnoAbm = new Cancelar_Atencion.CancelarAtencionAfiliado();
          //  cancelarTurnoAbm.MdiParent = this;
            //cancelarTurnoAbm.Show();
        }

        private void MenuAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void registrarLlegadaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
