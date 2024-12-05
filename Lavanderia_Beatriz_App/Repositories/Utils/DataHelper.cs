using Lavanderia_Beatriz_App.Repositories.Utils;
using System.Data;
using System.Data.Common;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Lavanderia_Beatriz_App.Repositories.Utils
{
    public class DataHelper
    {
        private static DataHelper _instancia;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-8MJD5EG;Initial Catalog=LavanderiaBeatriz;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        public static DataHelper GetInstance()
        {
            if (_instancia == null)
                _instancia = new DataHelper();

            return _instancia;
        }

        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parametros)
        {
            DataTable t = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                t.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch (SqlException)
            {
                t = null;
            }

            return t;
        }


        public int ExecuteSPDML(string sp, List<ParameterSQL>? parametros)
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }

            return rows;
        }
        public int ExecuteSPDMLTransac(string sp, List<ParameterSQL>? parametros, SqlTransaction t)
        {
            //grabar con transaccion
            bool result = true;


            return 0;
        }
        public SqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
