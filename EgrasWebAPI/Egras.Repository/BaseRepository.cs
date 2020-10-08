using System;
using System.Data;
using System.Data.SqlClient;

namespace Egras.Repository
{
    public class BaseRepository
    {
        protected IDbConnection con;
        public BaseRepository()
        {
            string connectionString = "Data Source=10.130.34.200;Initial Catalog=egras; User ID=sa; Password=123";
            con = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
