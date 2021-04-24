/// <summary>
/// Código para generar las acciones a la BD.
/// </summary>

namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Class of acctions bd.
    /// </summary>
    public class Acctions
    {
        /// <summary>
        /// Acces class conection.
        /// </summary>
        private readonly Conection conection;

        /// <summary>
        /// Gets or sets class of acction.
        /// </summary>
        /// <param name="conection">A conecction bd.</param>
        public Acctions(Conection conection)
        {
            this.conection = conection;
        }

        /// <summary>
        /// Acction of insert into procedure.
        /// </summary>
        /// <param name="parameters">List of params filter procedure</param>
        /// <param name="storeProcedure">Name of procedure.</param>
        /// <returns>A True or False</returns>
        public bool InsertAny(IDictionary<string, object> parameters, string storeProcedure)
        {
            bool result = false;

            try
            {
                SqlCommand cmd = new SqlCommand(storeProcedure, conection.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd = AddAtributes(cmd, parameters);
                conection.Conex();
                cmd.ExecuteNonQuery();
                conection.CloseConnection();
                result = true;
                return result;
            }
            catch (Exception ex)
            {
                conection.CloseConnection();
                return result;
                throw ex;
            }
        }

        /// <summary>
        /// Consult any by procedure.
        /// </summary>
        /// <param name="parameters">List of params filter procedure not required</param>
        /// <param name="storeProcedure">Name Procedure.</param>
        /// <returns>A object result.</returns>
        public Object GetsAny(string storeProcedure, IDictionary<string, object> parameters = null)
        {
            Object result = new Object();
            try
            {
                SqlCommand cmd = new SqlCommand(storeProcedure, conection.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd = AddAtributes(cmd, parameters);
                }
                conection.Conex();
                SqlDataAdapter sqdt = new SqlDataAdapter();

                DataTable dt = new DataTable();

                sqdt.Fill(dt);

                if (dt != null)
                {
                    result = dt;
                }
                conection.CloseConnection();
                return result;
            }
            catch (Exception ex)
            {
                conection.CloseConnection();
                return result;
                throw ex;
            }
        }

        /// <summary>
        /// Funtion for read paramas and add in sqlcommand.
        /// </summary>
        /// <param name="cmd">Sql Command.</param>
        /// <param name="parameters">Params dilter procedure.</param>
        /// <returns>A Sql Command.</returns>
        private static SqlCommand AddAtributes(SqlCommand cmd, IDictionary<string, object> parameters)
        {
            foreach (var item in parameters)
            {
                Type t = parameters.Values.GetType();

                if (t.Equals(typeof(byte)))
                    cmd.Parameters.Add("@" + item.Key, SqlDbType.Bit).Value = item.Value;
                if (t.Equals(typeof(decimal)) || t.Equals(typeof(Decimal)))
                    cmd.Parameters.Add("@" + item.Key, SqlDbType.Decimal).Value = item.Value;
                if (t.Equals(typeof(float)))
                    cmd.Parameters.Add("@" + item.Key, SqlDbType.Float).Value = item.Value;
                if (t.Equals(typeof(long)) || t.Equals(typeof(Int64)))
                    cmd.Parameters.Add("@" + item.Key, SqlDbType.BigInt).Value = item.Value;
                if (t.Equals(typeof(int)) || t.Equals(typeof(Int32)))
                    cmd.Parameters.Add("@" + item.Key, SqlDbType.Int).Value = item.Value;
                if (t.Equals(typeof(DateTime)))
                    cmd.Parameters.Add("@" + item.Key, SqlDbType.DateTime).Value = item.Value;
                if (t.Equals(typeof(char)))
                    cmd.Parameters.Add("@" + item.Key, SqlDbType.NChar).Value = item.Value;
                if (t.Equals(typeof(string)))
                    cmd.Parameters.Add("@" + item.Key, SqlDbType.NVarChar).Value = item.Value;
            }
            return cmd;
        }
    }
}
