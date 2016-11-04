using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Compra_Bono
{
    public partial class ComprarBono : Form
    {
        private float precioBono;

        public ComprarBono()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            

            if (MessageBox.Show("Bonos comprados con exito!!!!", "Alerta",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                 == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void lblNombreAfiliado_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            float montoTotal = float.Parse(numCantBonos.Value.ToString()) * precioBono;
            lblTotalNum.Text = montoTotal.ToString();
        }
    }
}
