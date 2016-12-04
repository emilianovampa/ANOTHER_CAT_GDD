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
    public partial class MenuPpal : Form
    {
        public MenuPpal(Objetos.Usuario usuarioActual)
        {
            InitializeComponent();
            //obtengo todos las funcionalidades para el rol
            string cmd = string.Format("SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Rol_Funcionalidad where ID_Rol={0}",usuarioActual.Id_rol);
            DataSet Roles = Conexion.Ejecutar(cmd);

            //habilito o deshabilito botones segun el rol y la funcionalidad
            comprarBono.Visible = estaHabilitadoRol(7, Roles);//7
            pedirTurno.Visible = estaHabilitadoRol(9, Roles);//9
            cancelarTurno.Visible = estaHabilitadoRol(6, Roles);//6
            registrarLlegada.Visible = estaHabilitadoRol(11, Roles);//11
            registrarResultados.Visible = estaHabilitadoRol(12, Roles);//12
            AfiliadoABM.Visible = estaHabilitadoRol(1, Roles); //1
            agendaABM.Visible = estaHabilitadoRol(10, Roles); //10
            rolABM.Visible = estaHabilitadoRol(5, Roles);//5
            profesionalABM.Visible = estaHabilitadoRol(4, Roles);//4
            EspecialicadMedicaABM.Visible = estaHabilitadoRol(2, Roles);//2
            PlanesMedicosABM.Visible = estaHabilitadoRol(3, Roles);//3
            ListadoEstadisticoABM.Visible = estaHabilitadoRol(8, Roles);//8
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

        private void afiliadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private bool estaHabilitadoRol(int IdFuncionalidad, DataSet Roles )
        {

      

            //Roles.Tables[0].Rows.Contains(idRol);
            foreach (DataRow row in Roles.Tables[0].Rows)
            {
                int id = Int32.Parse(row.ItemArray[0].ToString());

                if (id.Equals(IdFuncionalidad))
                {
                    return true;
                }
            }    
           
            //SqlConnection conexionABase = Conexion.ObtenerConexion();
            //string CMD = string.Format("SELECT ID_Funcionalidad FROM ANOTHER_CAT.tl_Rol_Funcionalidad where ID_Rol=1 and ID_Funcionalidad={0}", idRol);
            //SqlCommand comandoLlenado = new SqlCommand(CMD, conexionABase);
            //SqlDataReader ReadRol = comandoLlenado.ExecuteReader();
            //ReadRol.Read();
            //conexionABase.Close();

            return false;
        }


        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmRol.Alta AbmRolAlta = new AbmRol.Alta();
            AbmRolAlta.MdiParent = this;
           
            AbmRolAlta.Show();
        }

        private void modicarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmRol.Editar AbmRolEdit = new AbmRol.Editar();
            AbmRolEdit.MdiParent = this;
           
            AbmRolEdit.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmRol.Eliminar AbmRolElim = new AbmRol.Eliminar();
            AbmRolElim.MdiParent = this;
        
            AbmRolElim.Show();

        }
    }
}