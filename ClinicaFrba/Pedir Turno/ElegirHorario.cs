﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class ElegirHorario : Form
    {

        private int idTurno;
        private int idDoctor;
        private int idEspecialidad;
        private DateTime fechaTemprana;
        private DateTime fechaTardia;
        private DateTime fechaElegida = new DateTime(1000, 01, 01);
        private int idPaciente;
        private String diaDeLaSemana;

        public ElegirHorario(string doctorElegido, int idDoc, int idAfi, int idEsp)
        {
            InitializeComponent();

            // Setteo los id que ya tengo y no van a cambiar
            this.idPaciente = idAfi;
            this.idEspecialidad = idEsp;
            this.Text = "Elegir fecha para consulta con Dr." + doctorElegido.ToString();

            // Busco fecha de inicio de la disponibilidad actual del profesional
            //SqlCommand dateEarly = new SqlCommand("SELECT P.INICIO_DISPONIBILIDAD FROM [3FG].PROFESIONALES P WHERE P.ID_USUARIO LIKE '" + idDoc + "'", BDComun.obtenerConexion());
            //this.fechaTemprana = (DateTime)dateEarly.ExecuteScalar();

            // Busco fecha de fin de la disponibilidad actual del profesional
            //SqlCommand dateLate = new SqlCommand("SELECT P.FIN_DISPONIBILIDAD FROM [3FG].PROFESIONALES P WHERE P.ID_USUARIO LIKE '" + idDoc + "'", BDComun.obtenerConexion());
            //this.fechaTardia = (DateTime)dateLate.ExecuteScalar();

            // Modifico las labels para que el usuario sepa desde donde hasta donde puede elegir fecha
            //label3.Text = "Primera fecha disponible: " + fechaTemprana.ToString("yyyy-MM-dd");
            //label4.Text = "Ultima fecha disponible: " + fechaTardia.ToString("yyyy-MM-dd");
            this.idDoctor = idDoc;
        }





        // Funcion de creacion de turno
        private void button1_Click(object sender, EventArgs e)
        {
            // Me fijo que el usuario haya elegido fecha
            if (this.fechaElegida.Year != 1000)
            {
                // Abro la conexion
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    // Setteo la query de crear turnos
                    string crearTurno = "INSERT INTO [GD2C2016].[ANOTHER_CAT].tl_Turno(ID_Paciente,ID_Turno,Fecha) VALUES(@idPAciente,@idTurno,@fechaTurno)";

                    using (SqlCommand queryCrearTurno = new SqlCommand(crearTurno))
                    {
                        // Agrego los valores dinamicamente para evitar SQL Injection
                        queryCrearTurno.Connection = Conexion.ObtenerConexion();
                        queryCrearTurno.Parameters.Add("@idPaciente", SqlDbType.BigInt, 8).Value = idPaciente;
                        queryCrearTurno.Parameters.Add("@idTurno", SqlDbType.BigInt, 8).Value = idTurno;
                        queryCrearTurno.Parameters.Add("@fechaTurno", SqlDbType.DateTime, 8).Value = fechaElegida;

                        // Pruebo de ejecutarlo
                        try
                        {
                            queryCrearTurno.ExecuteNonQuery();
                            MessageBox.Show("Turno creado correctamente", "OK", MessageBoxButtons.OK);
                            this.Close();
                        }

                        // Doy un mensaje por si falla
                        catch
                        {
                            MessageBox.Show("Error al tratar de guardar en database", "Error", MessageBoxButtons.OK);
                        }
                        conexion.Close();
                    }
                }
            }
            else MessageBox.Show("No ha seleccionado una fecha", "Error", MessageBoxButtons.OK);
        }





        // Funcion de eleccion de fecha
        private void button2_Click(object sender, EventArgs e)
        {
            // Verifico si la fecha no esta entre las disponibles
            if (dateTimePicker1.Value.Date < this.fechaTemprana.Date || dateTimePicker1.Value.Date > this.fechaTardia.Date)
            {
                MessageBox.Show("La fecha seleccionada no se encuentra dentro de las disponibles", "Error", MessageBoxButtons.OK);
            }
            else
            {
                // Me fijo si el profesional elegido atiende ese dia para esa especialidad
                if (hayAgenda(dateTimePicker1.Value))
                {
                    // Si lo hace, busco si hay turnos disponibles para ese dia que le agraden al usuario
                    if (busquedaDeTurnos(dateTimePicker1.Value))
                    {
                        // Modifico la ventana para reflejar la eleccion del usuario
                        MessageBox.Show("Ha elegido el turno : " + this.fechaElegida.ToString("yyyy-MM-dd HH:mm:ss"), "Error", MessageBoxButtons.OK);
                        label2.Text = "Turno elegido: " + this.fechaElegida.ToString("yyyy-MM-dd HH:mm");
                    }
                    else MessageBox.Show("No quedan mas turnos disponibles para ese día", "Error", MessageBoxButtons.OK);
                }
                else MessageBox.Show("El profesional elegido no atiende ese día", "Error", MessageBoxButtons.OK);
            }
        }





        // Funcion de checkeo de agenda
        private bool hayAgenda(DateTime fecha)
        {
            // Me fijo que dia de la semana tiene la fecha elegida
            switch (fecha.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    this.diaDeLaSemana = "DOMINGO";
                    break;
                case DayOfWeek.Monday:
                    this.diaDeLaSemana = "LUNES";
                    break;
                case DayOfWeek.Tuesday:
                    this.diaDeLaSemana = "MARTES";
                    break;
                case DayOfWeek.Wednesday:
                    this.diaDeLaSemana = "MIERCOLES";
                    break;
                case DayOfWeek.Thursday:
                    this.diaDeLaSemana = "JUEVES";
                    break;
                case DayOfWeek.Friday:
                    this.diaDeLaSemana = "VIERNES";
                    break;
                case DayOfWeek.Saturday:
                    this.diaDeLaSemana = "SABADO";
                    break;
            }

            // Me fijo si el profesional atiende ese dia para la especialidad que elegi
            SqlCommand queryHayAgenda = new SqlCommand("SELECT COUNT(*) FROM [GD2C2016].[ANOTHER_CAT].tl_Profesional p, [GD2C2016].[ANOTHER_CAT].tl_Agenda a, [GD2C2016].[ANOTHER_CAT].tl_Profesional_Agenda pa WHERE (p.ID_Usuario LIKE '" + idDoctor + @"') 
                                                        AND (p.ID_Usuario = pa.ID_Agenda) AND (a.Dia = '" + this.diaDeLaSemana + @"')", Conexion.ObtenerConexion());
            if ((int)queryHayAgenda.ExecuteScalar() > 0)
            {
                return true;
            }
            else return false;
        }





        // Funcion de obtencion de agenda
        private int buscarAgenda()
        {
            // Busco y devuelvo el id de las agendas del profesional para la especialidad elegida
            SqlCommand queryBuscarAgenda = new SqlCommand("SELECT a.ID_Agenda FROM [GD2C2016].[ANOTHER_CAT].tl_Profesional p, [GD2C2016].[ANOTHER_CAT].tl_Profesional_Agenda pa, [GD2C2016].[ANOTHER_CAT].tl_Agenda a WHERE (p.ID_Usuario LIKE '" + idDoctor + @"') 
                                                           AND (p.ID_Usuario = pa.ID_Agenda) AND (a.Dia = '" + this.diaDeLaSemana + @"')", Conexion.ObtenerConexion());
            return int.Parse(queryBuscarAgenda.ExecuteScalar().ToString());
        }



        //seguir aca!!!!!!!!!!!!!!!!!!!!!!!!

        // Funcion de busqueda de turnos
        private bool busquedaDeTurnos(DateTime fecha)
        {
            // Busco la agenda del dia marcado
            int idTurnoTemporaria = buscarAgenda();

            // Busco el inicio de la disponibilidad para esa agenda
            SqlCommand queryBuscarMinimo = new SqlCommand("SELECT Hora_Inicio FROM [GD2C2016].[ANOTHER_CAT].tl_Agenda WHERE ID_Agenda = " + idTurnoTemporaria.ToString(), Conexion.ObtenerConexion());
            TimeSpan horarioMinimo = TimeSpan.Parse(queryBuscarMinimo.ExecuteScalar().ToString());

            // Busco el fin de la disponibilidad para esa agenda
            SqlCommand queryBuscarMaximo = new SqlCommand("SELECT Hora_Fin FROM [GD2C2016].[ANOTHER_CAT].tl_Agenda WHERE ID_Agenda = " + idTurnoTemporaria.ToString(), Conexion.ObtenerConexion());
            TimeSpan horarioMaximo = TimeSpan.Parse(queryBuscarMaximo.ExecuteScalar().ToString());

            // Setteo el turno actual (empiezo con el primero posible del dia) y el turno final del dia
            DateTime ultimoTurno = fecha.Date + horarioMaximo;
            DateTime actualTurno = fecha.Date + horarioMinimo;

            // Voy a retornar este bool para informar que oucrrio con la operacion
            bool eligioTurno = false;

            // Itero el siguiente comportamiento hasta que llegue al turno final del dia o elija uno el usuario
            while (actualTurno < ultimoTurno && !eligioTurno)
            {
                /* Esta hermosa query del infierno busca la cantidad de turnos en todas las agendas
                 * del profesional que voy a estar pisando con el nuevo turno que quiero crear en el
                 * caso de que lo cree con el DateTime actualTurno*/
                SqlCommand disponibilidad = new SqlCommand(@"SELECT COUNT(*) FROM [GD2C2016].[ANOTHER_CAT].tl_Turno T,
                                                            (SELECT A.ID_Agenda FROM [GD2C2016].[ANOTHER_CAT].tl_Profesional_Agenda A,
                                                            [GD2C2016].[ANOTHER_CAT].tl_Profesional P WHERE A.ID_Usuario = P.ID_Usuario
                                                            AND P.ID_Usuario = " + this.idDoctor.ToString() + @") AP
                                                            WHERE T.ID_Agenda = AP.ID_Agenda AND
                                                            T.Fecha = '" + actualTurno.ToString("yyyy-dd-MM HH:mm:ss") + "'", Conexion.ObtenerConexion());

                // Salvo ese valor en una variable
                int turnoPisados = (int)disponibilidad.ExecuteScalar();

                /* Y me fijo si es mayor a 0, en este caso ya existen turnos en este DateTime y paso al siguiente turno
                 * posible que esta 30 minutos mas adelante*/
                if (turnoPisados > 0) { actualTurno = actualTurno.AddMinutes(30); }

                // Si no es mayor a 0, le doy al usuario la oportunidad de seguir buscando turnos en ese dia o quedarse con ese
                else
                {
                    DialogResult dialogResult = MessageBox.Show("El turno " + actualTurno.ToString("yyyy-MM-dd HH:mm:ss") + " esta disponible. Desea reservar ese turno?", "Eleccion de turno", MessageBoxButtons.YesNo);

                    // Si dice que si, setteo las variables fechaElegida e idTurno con los valores actuales
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Agrego que el bool sea verdadero para salir del while antes de la porxima iteracion
                        eligioTurno = true;
                        this.fechaElegida = actualTurno;
                        this.idTurno = idTurnoTemporaria;
                    }
                    // Si dice que no, sigo buscando
                    else if (dialogResult == DialogResult.No)
                    {
                        actualTurno = actualTurno.AddMinutes(30);
                    }
                }
            }
            return eligioTurno;
        }
    }
}
