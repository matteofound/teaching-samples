using Supabase.Core;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ActorsRestService.Models
{
    [Table("Country")]
    public partial class Country: BaseModel
    {
        [PrimaryKey("country_code")]
        public string CountryCode { get; set; }

        [Column("country_name")]
        public string? CountryName { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
    }

}