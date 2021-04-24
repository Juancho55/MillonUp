/// <summary>
/// Código para generar la conexión a la BD.
/// </summary>

namespace Data
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Class of conecction bd.
    /// </summary>
    public class Conection
    {
        /// <summary>
        /// Variable of conecction.
        /// </summary>
        static string varConecction = @"Data Source=DESKTOP-EVOA1H9;Initial Catalog=BDTestRealCompany;User ID=sa; Password=Colombia2020+";

        /// <summary>
        /// Sql Connection.
        /// </summary>
        public SqlConnection sqlConnection = new SqlConnection(varConecction);

        /// <summary>
        /// Function for coneection open.
        /// </summary>
        public void Conex()
        {
            try
            {
               sqlConnection.Open();
            }
            catch(Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        /// <summary>
        /// Function for conecction close.
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
