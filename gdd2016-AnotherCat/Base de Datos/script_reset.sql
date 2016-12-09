use GD2C2016
GO

--Saco todas las constraints
ALTER TABLE ANOTHER_CAT.bono_consulta NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.turno NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.funcionXrol NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.rolXusuario NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.funcion NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.rol NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.franja_horaria NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.agenda NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.medicoXespecialidad NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.especialidad NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.tipo_especialidad NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.modificacion_plan NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.cancelacion_turno NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.profesional NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.compra_bono NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.afiliado NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.usuario NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.plan_medico NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.modificacion_plan NOCHECK CONSTRAINT ALL
GO
ALTER TABLE ANOTHER_CAT.turno NOCHECK CONSTRAINT ALL
GO

/*Lo hago aca xq turno referencia a medXesp */
DROP TABLE ANOTHER_CAT.baja_afiliado
GO

DROP TABLE ANOTHER_CAT.franja_horaria
GO

DROP TABLE ANOTHER_CAT.agenda
GO
DROP TABLE ANOTHER_CAT.bono_consulta
GO
DROP TABLE ANOTHER_CAT.cancelacion_turno
GO
DROP TABLE ANOTHER_CAT.consulta
GO
DROP TABLE ANOTHER_CAT.turno
GO
/*drop tablas relacion*/
DROP TABLE ANOTHER_CAT.funcionXrol
GO
DROP TABLE ANOTHER_CAT.rolXusuario
GO


/* ***************************************** */


/*Tablas que quedaron colgando de la relacion*/
DROP TABLE ANOTHER_CAT.funcion
GO

DROP TABLE ANOTHER_CAT.rol
GO

DROP TABLE ANOTHER_CAT.medicoXespecialidad
GO

DROP TABLE ANOTHER_CAT.especialidad
GO

DROP TABLE ANOTHER_CAT.tipo_especialidad
GO
/* ***************************************** */

DROP TABLE ANOTHER_CAT.modificacion_plan
GO


DROP TABLE ANOTHER_CAT.profesional
GO

DROP TABLE ANOTHER_CAT.compra_bono
GO

DROP TABLE ANOTHER_CAT.afiliado
GO

DROP TABLE ANOTHER_CAT.usuario
GO

DROP TABLE ANOTHER_CAT.plan_medico
GO

DROP TABLE ANOTHER_CAT.Fecha_Config
GO

DROP procedure ANOTHER_CAT.asignar_nro_bonos_afiliado
GO

DROP procedure ANOTHER_CAT.Usuario_Get
GO

DROP procedure ANOTHER_CAT.Usuario_ResetearIntentos
GO

DROP procedure ANOTHER_CAT.Usuario_SumarIntento
GO

DROP procedure ANOTHER_CAT.Usuario_GetAll

DROP procedure ANOTHER_CAT.Usuario_LogIn

DROP procedure ANOTHER_CAT.UsuarioXRol_GetRolesByUser
drop procedure ANOTHER_CAT.Afiliado_Obtener_Nro
drop procedure ANOTHER_CAT.Afiliado_Add
drop procedure ANOTHER_CAT.Afiliado_GetAll
drop procedure ANOTHER_CAT.Afiliado_GetAfiliadoSegunUsuario
drop procedure ANOTHER_CAT.Afiliado_GetByDni
drop procedure ANOTHER_CAT.Afiliado_GetByFilters
drop procedure ANOTHER_CAT.Afiliado_Modify
drop procedure ANOTHER_CAT.Bonos_GetBonosSegunAfiliado
drop procedure ANOTHER_CAT.Funciones_GetAll
drop procedure ANOTHER_CAT.Profesional_Add
drop procedure ANOTHER_CAT.Profesional_GetByDni
drop procedure ANOTHER_CAT.Profesional_GetByFilters
drop procedure ANOTHER_CAT.Profesional_GetProfesionalSegunUsuario
drop procedure ANOTHER_CAT.Profesional_Modify
drop procedure ANOTHER_CAT.Profesionales_GetAll
drop procedure ANOTHER_CAT.Rol_Activate
drop procedure ANOTHER_CAT.Rol_Add
drop procedure ANOTHER_CAT.Rol_Deactivate
drop procedure ANOTHER_CAT.Rol_Exists
drop procedure ANOTHER_CAT.Rol_GetAll
drop procedure ANOTHER_CAT.Rol_GetByName
drop procedure ANOTHER_CAT.Rol_ModifyName
drop procedure ANOTHER_CAT.RolXFuncion_Add
drop procedure ANOTHER_CAT.RolXFuncion_GetFunByRol
drop procedure ANOTHER_CAT.RolXFuncion_Remove
drop procedure ANOTHER_CAT.Usuario_Activo
drop procedure ANOTHER_CAT.Usuario_Add
drop procedure ANOTHER_CAT.Usuario_CambiarContrasenia
drop procedure ANOTHER_CAT.Usuario_Habilitar
drop procedure ANOTHER_CAT.Usuario_Inhabilitar
drop procedure ANOTHER_CAT.RolXFuncion_Active
drop procedure ANOTHER_CAT.Planes_GetAll
drop procedure ANOTHER_CAT.Agregar_Modif_Plan
drop procedure ANOTHER_CAT.Planes_GetPlanAfiliado
drop procedure ANOTHER_CAT.Planes_GetPorId
drop procedure ANOTHER_CAT.Usuario_Exists
drop procedure ANOTHER_CAT.Modif_Plan_Get_All
drop procedure ANOTHER_CAT.Afiliado_Baja_Logica
drop procedure ANOTHER_CAT.RolXUsuario_Activate
drop procedure ANOTHER_CAT.UsuarioXRol_GetRolesInhabxUser
drop procedure ANOTHER_CAT.Afiliado_Agregar_Familiar
drop procedure ANOTHER_CAT.Hijos_En_Cero
drop procedure ANOTHER_CAT.Especialidad_GetByMatricula
drop procedure ANOTHER_CAT.Afiliado_MismoDni
drop procedure ANOTHER_CAT.Get_MedicoXEsp_All
drop procedure ANOTHER_CAT.Get_Especialidades_All
drop procedure ANOTHER_CAT.Get_Especialidades_All_2
drop procedure ANOTHER_CAT.Get_Turnos_Today
drop procedure ANOTHER_CAT.Agenda_Agregar
drop procedure ANOTHER_CAT.Turno_Agregar
drop procedure ANOTHER_CAT.Get_medxesp_id
drop procedure ANOTHER_CAT.Franja_Agregar
drop procedure ANOTHER_CAT.turnos_GetByFilerProfesional
drop procedure ANOTHER_CAT.profesional_GetByFilerEspecialidad
drop procedure ANOTHER_CAT.Comprar_Bono
drop PROCEDURE ANOTHER_CAT.listado_Mas_Cancelaciones_Especialidad 
drop PROCEDURE ANOTHER_CAT.listado_Mas_Cancelaciones_Especialidad_Afiliado
drop PROCEDURE ANOTHER_CAT.listado_Mas_Cancelaciones_Especialidad_Profesional
drop PROCEDURE ANOTHER_CAT.listado_Profesionales_Consultados
drop PROCEDURE ANOTHER_CAT.listado_Profesionales_Menos_Horas 
drop PROCEDURE ANOTHER_CAT.listado_Afiliado_Mas_Bonos
drop PROCEDURE ANOTHER_CAT.listado_Especialidad_Mas_Bonos
drop procedure ANOTHER_CAT.Afiliado_GetAfiliadoSegunNro
drop procedure ANOTHER_CAT.Get_Especialidades_Sin_Agenda
drop procedure ANOTHER_CAT.GetTurnosDiaLlegaron
drop procedure ANOTHER_CAT.Registrar_Resultado
drop procedure ANOTHER_CAT.Get_Turnos_Prof_Reservados
drop procedure ANOTHER_CAT.especialidades_GetByFilerEspecialidad
drop procedure ANOTHER_CAT.Get_Bonos_Afiliado
drop procedure ANOTHER_CAT.Registrar_Llegada
drop procedure ANOTHER_CAT.Cancelar_Turno_Afiliado
drop procedure ANOTHER_CAT.Turnos_Afiliado
drop procedure ANOTHER_CAT.Get_Dias_Turno_Prof
drop procedure ANOTHER_CAT.Get_Franjas_Profesional
drop procedure ANOTHER_CAT.Cancelar_Turnos_Profesional
drop procedure ANOTHER_CAT.Cancelar_Turnos_ProfxFranja 
drop procedure ANOTHER_CAT.Cancelar_Turnos_Varios_Dias 
drop procedure ANOTHER_CAT.reservarTurno_GetByFilerProfesional
drop procedure ANOTHER_CAT.Turnos_Afiliado_Mayor
DROP PROCEDURE ANOTHER_CAT.Reestablecer_Fecha
DROP FUNCTION ANOTHER_CAT.Obtener_Fecha
/*DROP PROCEDURE ANOTHER_CAT.Agregar_Franja_A_Todos_Los_Medicos*/
DROP PROCEDURE ANOTHER_CAT.Obtener_Horas_Profesional
DROP PROCEDURE ANOTHER_CAT.Borrar_Franjas_Agenda
DROP PROCEDURE ANOTHER_CAT.Asignar_agendas
DROP SCHEMA ANOTHER_CAT
GO
