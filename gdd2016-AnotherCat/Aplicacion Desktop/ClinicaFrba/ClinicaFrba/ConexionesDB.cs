﻿
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Helpers
{
      public static class ConexionesDB
    {
        //DB: DataBase
        public static SqlConnection DB;
        static string conn = ConfigurationManager.AppSettings["connection-string"];
      

        static ConexionesDB()
        {
            DB = new SqlConnection(conn);
        }

        //SP: StoredProcedure
        public static void ExecuteNonQuery(string SP, Dictionary<string, object> parametros = null)
        {
            if (parametros == null) parametros = new Dictionary<string, object>();
            if (DB != null && DB.State == ConnectionState.Open)
            {
                DB.Close();
            }
            DB.Open();
            SqlCommand command = new SqlCommand("ANOTHER_CAT." + SP, DB);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var parametro in parametros)
            {
                command.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));
            }

            command.ExecuteNonQuery();
            DB.Close();
        }
        
        public static SqlParameterCollection ExecuteNonQueryWithOutput(string SP, List<string> outputParam, Dictionary<string, object> parametros = null )
        {
            if (parametros == null) parametros = new Dictionary<string, object>();
            if (DB != null && DB.State == ConnectionState.Open)
            {
                DB.Close();
            }
            DB.Open();
            SqlCommand command = new SqlCommand("ANOTHER_CAT." + SP, DB);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var parametro in parametros)
            {
                command.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));
            }
            foreach(string parametro in outputParam){
            	SqlParameter sqlParameter = new SqlParameter(parametro, System.Data.SqlDbType.Int);
            	sqlParameter.Direction = System.Data.ParameterDirection.Output; //Le digo que es output
            	command.Parameters.Add(sqlParameter);
            	
            }

            command.ExecuteNonQuery();
            DB.Close();
            
            return command.Parameters;
        }     
        
        public static int ExecuteNonQueryWithReturn(string SP, Dictionary<string, object> parametros = null)
        {        	
            if (parametros == null) parametros = new Dictionary<string, object>();
            if (DB != null && DB.State == ConnectionState.Open)
            {
                DB.Close();
            }
            DB.Open();
            SqlCommand command = new SqlCommand("ANOTHER_CAT." + SP, DB);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var parametro in parametros)
            {
                command.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));
            }
            
            SqlParameter returnParameter = new SqlParameter();
            returnParameter.Direction = ParameterDirection.ReturnValue;
            
            command.Parameters.Add(returnParameter);

            command.ExecuteNonQuery();
            
            return (int)returnParameter.Value;
            
        }

        public static SqlDataReader ExecuteReader(string SP, Dictionary<string, object> parametros = null)
        {
            if (DB != null && DB.State == ConnectionState.Open)
            {
                DB.Close();
            }
            if (parametros == null) parametros = new Dictionary<string, object>();
            DB.Open();
            SqlCommand command = new SqlCommand("ANOTHER_CAT." + SP, DB);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var parametro in parametros)
            {
                command.Parameters.Add(new SqlParameter(parametro.Key, parametro.Value));
            }
            SqlDataReader result = command.ExecuteReader();
            return result;
        }

    }
}