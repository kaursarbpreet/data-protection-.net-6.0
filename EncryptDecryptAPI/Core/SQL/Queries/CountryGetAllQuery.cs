using Dapper;
using EncryptDecryptAPI.Core.Models;
using System.Data;

namespace EncryptDecryptAPI.Core.SQL.Queries
{
    public class CountryGetAllQuery : SqlQuery<List<Country>>
    {
        public override async Task<List<Country>> RunQuery(IDbConnection dbConnection)
        {
            var sql = @"
                        SELECT 
		                     [CountryId],
		                     [CountryCode], 
		                     [Description],
		                     [IsActive]
	                    FROM [Common].[Country] WITH (NOLOCK)
	                    WHERE [IsActive]=1";

            var data = await dbConnection.QueryAsync<Country>(sql);
            return data.ToList();
        }
    }
}