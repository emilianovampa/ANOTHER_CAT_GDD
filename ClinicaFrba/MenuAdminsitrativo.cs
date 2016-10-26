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
    public partial class MenuAdminsitrativo : Form
    {
        public MenuAdminsitrativo()
        {
            InitializeComponent();
        }

        private void procesoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comprarBonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra_Bono.ComprarBono comprarBonoABM = new Compra_Bono.ComprarBono();
            comprarBonoABM.MdiParent = this;
            comprarBonoABM.Show();
        }

        private void registrarLlegadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_Llegada.RegistroLlegadaABM RLlegadaAbm = new Registro_Llegada.RegistroLlegadaABM();
            RLlegadaAbm.MdiParent = this;
            RLlegadaAbm.Show();
        }

        private void afiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.AltaAfiliado afiliadoAbm = new Abm_Afiliado.AltaAfiliado();
            afiliadoAbm.MdiParent = this;
            afiliadoAbm.Show();
        }

        private void profesionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Profesional.ProfesionalABM profesionalAbm = new Abm_Profesional.ProfesionalABM();
            profesionalAbm.MdiParent = this;
            profesionalAbm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
