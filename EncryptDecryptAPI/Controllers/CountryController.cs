using EncryptDecryptAPI.Core.SQL;
using EncryptDecryptAPI.Core.SQL.Queries;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace EncryptDecryptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly SqlHandler sqlHandler;
        private readonly IDataProtector _protector;

        public CountryController(SqlHandler sqlHandler, IDataProtectionProvider provider)
        {
            this.sqlHandler = sqlHandler;
            _protector = provider.CreateProtector("EncryptDecrypt.CountryController");
        }

        [HttpGet()]
        public async Task<IActionResult> GetCountry()
        {
            var query = new CountryGetAllQuery();
            var result = await this.sqlHandler.ExecuteQuery(query);
            foreach (var country in result)
            {
                var stringId = country.CountryId.ToString();
                country.Id = _protector.Protect(stringId);
            }
            return this.Ok(result);
        }

        [HttpGet("{countryid}")]
        public async Task<IActionResult> GetCountryById(string countryid)
        {
            var id = int.Parse(_protector.Unprotect(countryid));

            var query = new CountryGetQuery(id);
            var result = await this.sqlHandler.ExecuteQuery(query);
            return this.Ok(result);
        }
    }
}