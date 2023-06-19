using Dapper;
using EncryptDecryptAPI.Core.Models;
using System.Data;

namespace EncryptDecryptAPI.Core.SQL.Queries
{
    public class CountryGetQuery : SqlQuery<Country>
    {
        private readonly int countryId;

        public CountryGetQuery(int countryId)
        {
            this.countryId = countryId;
        }

        public override async Task<Country> RunQuery(IDbConnection dbConnection)
        {
            var sql = @"
                        SELECT 
		                     [CountryId],
		                     [CountryCode], 
		                     [Description],
		                     [IsActive]
	                    FROM [Common].[Country] WITH (NOLOCK)
	                    WHERE [IsActive] = 1
                        AND   [CountryId] = @countryId";

            var dynamicParams = new
            {
                this.countryId,
            };

            return await dbConnection.QueryFirstOrDefaultAsync<Country>(sql,
                dynamicParams,
                commandType: CommandType.Text);
        }
    }
}