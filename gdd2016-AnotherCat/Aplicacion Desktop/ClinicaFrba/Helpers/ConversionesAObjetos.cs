﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Clases;
using Clases.Profesionales;
using System.Configuration;

namespace Helpers
{
    public static class ConversionesAObjetos
    {
        #region USUARIO
        public static Usuario ToUsuario(this SqlDataReader rdr)
        {
            return rdr.ToUsuarios().FirstOrDefault();
        }
        public static List<Usuario> ToUsuarios(this SqlDataReader rdr)
        {
            List<Usuario> list = new List<Usuario>();
            while (rdr.Read())
            {
                list.Add(new Usuario()
                {
                    Username = (string)rdr["usuario_id"],
                    Password = (string)rdr["usuario_password"],
                    Descripcion = (string)rdr["usuario_descripcion"],
                    Activo = (bool)rdr["usuario_habilitado"],
                    Intentos = (int)rdr["usuario_cant_intentos"]
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region PLAN
        public static Plan ToPlan(this SqlDataReader rdr)
        {
            return rdr.ToPlanes().FirstOrDefault();
        }
        public static List<Plan> ToPlanes(this SqlDataReader rdr)
        {
            List<Plan> list = new List<Plan>();
            while (rdr.Read())
            {
                decimal preciocuot;
                if (rdr["plan_cuota_precio"].ToString() == "")
                {
                    preciocuot = 0;
                }
                else
                {
                    preciocuot = (decimal)rdr["plan_cuota_precio"];
                }
                list.Add(new Plan()
                {

                    Id = (decimal)rdr["plan_id"],
                    PrecioBonoConsulta = (decimal)rdr["plan_precio_bono_consulta"],
                    Descripcion = (string)rdr["plan_descripcion"],
                    CuotaPrecio = preciocuot

                });

            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region MODIFICACION PLAN
        public static ModifPlan ToModifPlan(this SqlDataReader rdr)
        {
            return rdr.ToModifPlanes().FirstOrDefault();
        }
        public static List<ModifPlan> ToModifPlanes(this SqlDataReader rdr)
        {
            List<ModifPlan> list = new List<ModifPlan>();
            while (rdr.Read())
            {
                list.Add(new ModifPlan()
                {
                    FechaNacimiento = (DateTime)rdr["modif_plan_fecha"],
                    ModifId = (decimal)rdr["modif_id"],
                    Motivo = (string)rdr["modif_motivo"],
                    NroAfiliado = (decimal)rdr["modif_afiliado"],
                    PlanNuevo = (decimal)rdr["modif_plan_nuevo"],
                    PlanViejo = (decimal)rdr["modif_plan_viejo"],
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region AFILIADO
        public static Afiliado ToAfiliados(this SqlDataReader rdr)
        {
            return rdr.ToAfiliado().FirstOrDefault();
        }
        public static List<Afiliado> ToAfiliado(this SqlDataReader rdr)
        {
            SqlDataReader milector = rdr;
            List<Afiliado> list = new List<Afiliado>();
            while (milector.Read())
            {
                list.Add(new Afiliado()
                   {
                       Username = (string)rdr["usuario_id"], //definir si usuario va a tener id usuario
                       NroAfiliado = (decimal)rdr["afiliado_nro"],
                       Nombre = (string)rdr["afiliado_nombre"],
                       Apellido = (string)rdr["afiliado_apellido"],
                       Dni = (decimal)rdr["afiliado_dni"],
                       Mail = (string)rdr["afiliado_mail"],
                       Telefono = (decimal)rdr["afiliado_telefono"],
                       Direccion = (string)rdr["afiliado_direccion"],
                       EstadoCivil = (string)rdr["afiliado_estado_civil"],
                       FechaNacimiento = (DateTime)rdr["afiliado_fecha_nac"], //fecha nacimiento
                       Sexo = (string)rdr["afiliado_sexo"],
                       PlanUsuario = (decimal)rdr["afiliado_plan"],
                       CantidadHijos = (decimal)rdr["afiliado_cant_hijos"],
                       TipoDocumento = (string)rdr["afiliado_tipo_dni"],
                   });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region PROFESIONAL
        public static Profesional ToProfesionales(this SqlDataReader rdr)
        {
            return rdr.ToProfesional().FirstOrDefault();
        }
        public static List<Profesional> ToProfesional(this SqlDataReader rdr)
        {
            List<Profesional> list = new List<Profesional>();
            while (rdr.Read())
            {
                list.Add(new Profesional()
                {
                    Username = (string)rdr["usuario_id"], //definir si usuario va a tener id usuario
                    Matricula = (int)rdr["profesional_matricula"],
                    Nombre = (string)rdr["profesional_nombre"],
                    Apellido = (string)rdr["profesional_apellido"],
                    Dni = (decimal)rdr["profesional_dni"],
                    TipoDocumento = (string)rdr["profesional_tipo_doc"],// tipo documento
                    Mail = (string)rdr["profesional_mail"],
                    Telefono = (string)rdr["profesional_telefono"],
                    Direccion = (string)rdr["profesional_direccion"],
                    FechaNacimiento = (DateTime)rdr["profesional_fecha_nacimiento"], //fecha nacimiento
                    sexo = (string)rdr["profesional_sexo"],

                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region PROFESIONAL2

        public static List<Profesional> ToProfesional2(this SqlDataReader rdr)
        {
            List<Profesional> list = new List<Profesional>();
            while (rdr.Read())
            {
                list.Add(new Profesional()
                {
                    Matricula = (int)rdr["profesional_matricula"],
                    Nombre = (string)rdr["profesional_nombre"],
                    Apellido = (string)rdr["profesional_apellido"],
                    Mail = (string)rdr["profesional_mail"],
                    Telefono = (string)rdr["profesional_telefono"],
                    Direccion = (string)rdr["profesional_direccion"]
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region ROL
        public static Rol ToRol(this SqlDataReader rdr)
        {
            return rdr.ToRoles().FirstOrDefault();
        }
        public static List<Rol> ToRoles(this SqlDataReader rdr)
        {
            List<Rol> list = new List<Rol>();
            while (rdr.Read())
            {
                list.Add(new Rol()
                {
                    Id = (int)rdr["rol_id"],
                    Descripcion = (string)rdr["rol_descripcion"],
                    Habilitado = (bool)rdr["rol_habilitado"]
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region FUNCION
        public static Funcion ToFuncion(this SqlDataReader rdr)
        {
            return rdr.ToFunciones().FirstOrDefault();
        }
        public static List<Funcion> ToFunciones(this SqlDataReader rdr)
        {
            List<Funcion> list = new List<Funcion>();
            while (rdr.Read())
            {
                list.Add(new Funcion()
                {
                    Id = (int)rdr["funcion_id"],
                    Descripcion = (string)rdr["funcion_descripcion"],
                    //Activo = (bool)rdr["funcionXrol_activo"]
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region ESPECIALIDAD
        public static Especialidad ToEspecialidades(this SqlDataReader rdr)
        {
            return rdr.ToEspecialidad().FirstOrDefault();
        }

        public static List<Especialidad> ToEspecialidad(this SqlDataReader rdr)
        {
            List<Especialidad> list = new List<Especialidad>();
            while (rdr.Read())
            {
               // if(rdr.
                list.Add(new Especialidad()
                {
                    Descripcion = (string)rdr["especialidad_descripcion"],
                    Id = (decimal)rdr["especialidad_codigo"],
                    Tipo = (string)rdr["tipo_especialidad_descripcion"]
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region ESPECIALIDAD2

        public static List<Especialidad> ToEspecialidad2(this SqlDataReader rdr)
        {
            List<Especialidad> list = new List<Especialidad>();
            while (rdr.Read())
            {
                // if(rdr.
                list.Add(new Especialidad()
                {
                    Descripcion = (string)rdr["especialidad_descripcion"],
                    Id = (decimal)rdr["especialidad_codigo"],
                    Tipo = (string)rdr["especialidad_tipo"]
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region FRANJA
        public static Franja ToFranjas(this SqlDataReader rdr)
        {
            return rdr.ToFranja().FirstOrDefault();
        }
        public static List<Franja> ToFranja(this SqlDataReader rdr)
        {
            List<Franja> list = new List<Franja>();
            while (rdr.Read())
            {
                /*string afil;
                if (rdr["id_afiliado"].ToString() != string.Empty)
                {
                    afil = "";
                }
                else
                {
                    afil = (string)rdr["id_afiliado"].ToString();
                }*/
                list.Add(new Franja()
                {
                    Dia = (int)rdr["dia"],
                    HoraInicio = (int)rdr["hora_inicio"],
                    MinutoInicio = (int)rdr["minuto_inicio"],
                    HoraFin = (int)rdr["hora_fin"],
                    MinutoFin = (int)rdr["minuto_fin"],
                    Id = (int)rdr["franja_id"],
                    Cancelada = (bool)rdr["franja_cancelada"],
                    Agenda = (int)rdr["agenda_id"],
                    FechaInicio = (DateTime)rdr["franja_fecha_inicio"],
                    FechaFin = (DateTime)rdr["franja_fecha_fin"],
                //    Afiliado = afil,
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region LISTADOS
        public static List<Listado_1> ToListado_1(this SqlDataReader rdr)
        {
            SqlDataReader milector = rdr;
            List<Listado_1> list = new List<Listado_1>();
            while (milector.Read())
            {
                list.Add(new Listado_1()
                {
                    Especialidad_descripcion = (string)rdr["especialidad_descripcion"],
                    Cantidad = (int)rdr["cantidad_cancelaciones"],
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        public static List<Listado_2> ToListado_2(this SqlDataReader rdr)
        {
            SqlDataReader milector = rdr;
            List<Listado_2> list = new List<Listado_2>();
            while (milector.Read())
            {
                list.Add(new Listado_2()
                {
                    Matricula = (int)rdr["profesional_matricula"],
                    Nombre = (string)rdr["profesional_nombre"],
                    Apellido = (string)rdr["profesional_apellido"],
                    Cantidad = (int)rdr["cantidad_consultas"],
                    Especialidad = (string)rdr["especialidad_descripcion"],
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        public static List<Listado_3> ToListado_3(this SqlDataReader rdr)
        {
            SqlDataReader milector = rdr;
            List<Listado_3> list = new List<Listado_3>();
            while (milector.Read())
            {
                list.Add(new Listado_3()
                {
                    Matricula = (int)rdr["profesional_matricula"],
                    Nombre = (string)rdr["profesional_nombre"],
                    Apellido = (string)rdr["profesional_apellido"],
                    Cantidad = (decimal)rdr["cantidad_horas"],
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        public static List<Listado_4> ToListado_4(this SqlDataReader rdr)
        {
            SqlDataReader milector = rdr;
            List<Listado_4> list = new List<Listado_4>();
            while (milector.Read())
            {
                list.Add(new Listado_4()
                {
                    NroAfiliado = (decimal)rdr["afiliado_nro"],
                    Nombre = (string)rdr["afiliado_nombre"],
                    Apellido = (string)rdr["afiliado_apellido"],
                    Cantidad = (int)rdr["cantidad_bonos"],
                    Grupo_Familiar = (string)rdr["pertenece_grupo_familiar"],
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        public static List<Listado_5> ToListado_5(this SqlDataReader rdr)
        {
            SqlDataReader milector = rdr;
            List<Listado_5> list = new List<Listado_5>();
            while (milector.Read())
            {
                list.Add(new Listado_5()
                {
                    Especialidad_descripcion = (string)rdr["especialidad_descripcion"],
                    Cantidad = (int)rdr["cantidad_bonos"],
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region TURNOS
        public static Turno ToTurnos(this SqlDataReader rdr)
        {
            return rdr.ToTurno().FirstOrDefault();
        }
        public static List<Turno> ToTurno(this SqlDataReader rdr)
        {
            SqlDataReader milector = rdr;
            List<Turno> list = new List<Turno>();
            while (milector.Read())
            {

                //string enfermedades;
                decimal afiliado;
                DateTime llegada;
                //string sintomas;
                bool tiempo = false; ;
                decimal id = (decimal)rdr["turno_nro"];
                if (rdr["afiliado_nro"].ToString() != "")
                {
                    afiliado = (decimal)rdr["afiliado_nro"];
                }
                else
                {
                    afiliado = 0;
                }
                if (rdr["turno_tiempo"].ToString() == "0")
                {
                    tiempo = false;
                }
                else
                {
                    tiempo = true;
                }
                DateTime fecha = (DateTime)rdr["turno_fecha"];
                string estado = (string)rdr["turno_estado"];
                if (rdr["turno_hora_llegada"].ToString() != "")
                {
                    llegada = (DateTime)rdr["turno_hora_llegada"];
                }
                else
                {
                    llegada = ConfigTime.getFechaSinHora();
                }
                /*if (rdr["turno_sintomas"].ToString() != "")
                {
                    sintomas = (string)rdr["turno_sintomas"];
                }
                else
                {
                    sintomas = "";
                }
                if (rdr["turno_enfermedades"].ToString() != "")
                {
                    enfermedades = (string)rdr["turno_enfermedades"];
                }
                else
                {
                    enfermedades = "";
                }*/
                int idmedicoespecialidad = (int)rdr["turno_medico_especialidad_id"];
                list.Add(new Turno()
                   {

                       Id = id, 
                       Afiliado = afiliado,
                       Fecha = fecha,
                       Estado = estado,
                       Llegada = llegada,
                      // Sintomas = sintomas,
                       //Enfermedades = enfermedades,
                       IdMedicoEspecialidad = idmedicoespecialidad,
                       Tiempo = tiempo,
                   });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region TURNOS_PROCEDURE
        public static List<turnosProcedure> ToTurnosProc(this SqlDataReader rdr)
        {
            List<turnosProcedure> list = new List<turnosProcedure>();
            while (rdr.Read())
            {
                list.Add(new turnosProcedure()
                {
                    turno = (string)rdr["turno"],
                    dia = (string)rdr["dia"],
                    mes = (string)rdr["mes"],
                    horario = (string)rdr["hora"]
                    
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region TURNO_RESERVADO
        public static List<turnosProcedure> ToTurnoReservado(this SqlDataReader rdr)
        {
            List<turnosProcedure> list = new List<turnosProcedure>();
            while (rdr.Read())
            {
                list.Add(new turnosProcedure()
                {
                    turno = (string)rdr["turno"],
                    dia = (string)rdr["dia"],
                    mes = (string)rdr["mes"],
                    horario = (string)rdr["hora"]
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region BONOS
        public static Bono ToBonos(this SqlDataReader rdr)
        {
            return rdr.ToBono().FirstOrDefault();
        }
        public static List<Bono> ToBono(this SqlDataReader rdr)
        {
            SqlDataReader milector = rdr;
            List<Bono> list = new List<Bono>();
            while (milector.Read())
            {
                decimal id = (decimal)rdr["bono_id"];
                decimal afil = (decimal)rdr["bono_afiliado"];
                decimal plan = (decimal)rdr["bono_plan"];
                decimal turno;
                if (rdr["bono_turno"].ToString() != string.Empty)
                {
                    turno = (decimal)rdr["bono_turno"];
                }
                else { 
                  turno = 0;
                }
                decimal nrobono;
                DateTime fecha = (DateTime)rdr["bono_fecha_compra"];
                string utilizado = (string)rdr["bono_utilizado"];
                if (rdr["bono_nro_bono_afiliado"].ToString() != string.Empty)
                {
                    nrobono = (decimal)rdr["bono_nro_bono_afiliado"];
                }
                else { nrobono = 0; }

                list.Add(new Bono()
                {
                    Id = id,
                    Afiliado = afil,
                    Plan = plan,
                    Turno = turno,
                    FechaCompra = fecha,
                    Utilizado = utilizado,
                    NroBonoAfiliado = nrobono,
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion

        #region FECHA
        public static Fecha ToFechas(this SqlDataReader rdr)
        {
            return rdr.ToFecha().FirstOrDefault();
        }
        public static List<Fecha> ToFecha(this SqlDataReader rdr)
        {
            List<Fecha> list = new List<Fecha>();
            while (rdr.Read())
            {
                list.Add(new Fecha()
                {
                    DiaMesAnio = (DateTime)rdr["turno_fecha"],
                });
            }
            ConexionesDB.DB.Close();
            return list;
        }
        #endregion
    }
}
