using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinanceWebApp.Domain
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_of_birth { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime Create_of_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Create_of_edit { get; set; }
    }


}
