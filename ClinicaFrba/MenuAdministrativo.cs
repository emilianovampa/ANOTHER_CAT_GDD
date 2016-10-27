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
    public partial class MenuAdministrativo : Form
    {
        public MenuAdministrativo()
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        { //Solo permitido cargar de a un solo afiliado principal, una vez terminado se puede agregar otro
            Abm_Afiliado.AltaAfiliado nuevoAfiliado = Abm_Afiliado.AltaAfiliado.getInstance();
            //Genero el ultimo indice del afiliado
            Abm_Afiliado.AltaAfiliado.finLegajo = 1;
            Random aleatorio = new Random();
            Abm_Afiliado.AltaAfiliado.inicioLegajo = aleatorio.Next(0, 1000);
            nuevoAfiliado.Show(this);
        }

        private void MenuAdministrativo_Load(object sender, EventArgs e)
        {

        }

        private void MenuAdministrativo_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void MenuAdministrativo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
