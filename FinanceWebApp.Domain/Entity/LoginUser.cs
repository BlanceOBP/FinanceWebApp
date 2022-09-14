using System.ComponentModel.DataAnnotations;


namespace FinanceWebApp.Domain.Entity
{
    public class LoginUser
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
