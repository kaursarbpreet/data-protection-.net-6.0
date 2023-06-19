using System.Data;
using System.Data.SqlClient;

namespace EncryptDecryptAPI.Core.SQL
{
    public abstract class SqlCommand<T>
    {
        public abstract Task<T> RunCommand(IDbConnection dbConnection, SqlTransaction transaction);
    }
}