using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelarAtencionMedico : Form
    {
        public CancelarAtencionMedico()
        {
            InitializeComponent();
        }

        private void cancelarAtencionMedico_Load(object sender, EventArgs e)
        {
            monthCalendar1.Visible = monthCalendar2.Visible = true;
            hora1.Enabled = minuto1.Enabled = hora2.Enabled = minuto2.Enabled = monthCalendar1.Enabled = monthCalendar2.Enabled = drop_fecha.Enabled = false;


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fecha.Checked == true)
            {
                chk_dias.Checked = false;
                drop_fecha.Enabled = true;
            }
            else
            {
                chk_horario.Checked = false;
                drop_fecha.Enabled = false;
            }

        }

        private void chk_horario_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_horario.Checked == true)
            {
                chk_fecha.Checked = true;
                hora1.Enabled = minuto1.Enabled = hora2.Enabled = minuto2.Enabled = true;
            }
            else
            {
                hora1.Enabled = minuto1.Enabled = hora2.Enabled = minuto2.Enabled = false;
            }
        }

        private void chk_dias_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_dias.Checked == true)
            {
                chk_fecha.Checked = false;
                monthCalendar1.Enabled = monthCalendar2.Enabled = true;
            }
            else
            {
                monthCalendar1.Enabled = monthCalendar2.Enabled = false;
            }

        }
    }
}
