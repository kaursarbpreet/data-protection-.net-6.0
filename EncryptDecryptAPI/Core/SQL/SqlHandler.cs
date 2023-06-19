using EncryptDecryptAPI.Core.Settings;
using System.Data;
using System.Data.SqlClient;

namespace EncryptDecryptAPI.Core.SQL
{
    public class SqlHandler
    {
        private readonly SqlSettings settings;

        public SqlHandler(SqlSettings settings)
        {
            this.settings = settings;
        }

        public async Task<T> ExecuteQuery<T>(SqlQuery<T> query)
        {
            using (var connection = new SqlConnection(this.settings.DBConnectionString))
            {
                await connection.OpenAsync();
                var result = await query.RunQuery(connection);
                return result;
            }
        }

        public async Task<T> ExecuteCommand<T>(
            SqlCommand<T> command,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted
        )
        {
            using (var connection = new SqlConnection(this.settings.DBConnectionString))
            {
                await connection.OpenAsync();
                var transaction = connection.BeginTransaction(isolationLevel);
                var result = await command.RunCommand(connection, transaction);

                transaction.Commit();

                return result;
            }
        }

        public async Task ExecuteCommand<T>(IEnumerable<SqlCommand<T>> commands)
        {
            using (var connection = new SqlConnection(this.settings.DBConnectionString))
            {
                await connection.OpenAsync();
                var transaction = connection.BeginTransaction();

                foreach (var cmd in commands)
                {
                    await cmd.RunCommand(connection, transaction);
                }

                transaction.Commit();
            }
        }
    }
}