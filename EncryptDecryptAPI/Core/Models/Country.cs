using System.Text.Json.Serialization;

namespace EncryptDecryptAPI.Core.Models
{
    public class Country
    {
        [JsonIgnore]
        public int CountryId { get; set; }
        public string Id { get; set; }
        public string CountryCode { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}