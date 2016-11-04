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
    public partial class MenuProfesional : Form
    {
        public MenuProfesional()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registrarResultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_Resultado.RegistroResultadoABM registroResultadoAbm = new Registro_Resultado.RegistroResultadoABM();
            registroResultadoAbm.MdiParent = this;
            registroResultadoAbm.Show();
        }

        private void cancelarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
       //     Cancelar_Atencion.CancelarAtencionAfiliado cancelAtencionAbm = new Cancelar_Atencion.CancelarAtencionAfiliado();
         //   cancelAtencionAbm.MdiParent = this;
           // cancelAtencionAbm.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar_Agenta_Medico.AgendaMedicoABM agendaMedAbm = new Registrar_Agenta_Medico.AgendaMedicoABM();
            agendaMedAbm.MdiParent = this;
            agendaMedAbm.Show();
        }
    }
}
