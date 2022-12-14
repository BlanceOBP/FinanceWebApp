using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceWebApp.Domain
{
    public class Source
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Summary { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_of_create { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_of_edit { get; set; }

        public int Source_of_income_id { get; set; }
    }
}
