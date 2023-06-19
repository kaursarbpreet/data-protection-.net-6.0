using System.Data;

namespace EncryptDecryptAPI.Core.SQL
{
    public abstract class SqlQuery<T>
    {
        public abstract Task<T> RunQuery(IDbConnection dbConnection);
    }
}