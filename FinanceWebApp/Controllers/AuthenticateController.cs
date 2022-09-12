using FinanceWebApp.DAL;
using FinanceWebApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinanceWebApp.Controllers
{
    public class AuthenticateController : Controller
    { 
            [Route("Authenticate")]
            [HttpGet]

            public async Task<IActionResult> Authorization(string Email, string Password)
            {
                await using var acb = new ApplicationContext();
                var Consilience = acb.users.Count(x =>  x.Email == Email && x.Password == Password) != 0;
                try
                {
                      if (Consilience == true)
                      {
                           var claims = new List<Claim> { new(ClaimTypes.Name, Email) };
                           var jwt = new JwtSecurityToken(
                           claims: claims,
                           signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                           return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
                      }
                      else
                      {
                    throw new Exception("Please check your username or password, you may have made a mistake");
                      }
                }
                catch (Exception ex)
                {
                      return BadRequest(ex.Message);
                }
            }

        [Route("Registration")]
        [HttpPost]
        public async Task<IActionResult> Registration(string name, string lastName, string middleName, DateTime date_of_birth, string email, string login, string password)
        {
            await using var acb = new ApplicationContext();
            var Personality_of_the_login = acb.users.Count(x => x.Login == login) == 1;

            try
            {
                if (Personality_of_the_login == true)
                {
                    throw new Exception("Login is taken.Please enter other login:)");
                }
                else
                {
                    var Date_of_Create = DateTime.Today;
                    var Date_of_Edit = DateTime.Today;

                    var NewUser = new Users { Name = name, LastName = lastName, MiddleName = middleName,Date_of_birth = date_of_birth, Email = email, Login = login, Create_of_date = Date_of_Create, Create_of_edit = Date_of_Edit };
                    acb.users.Add(NewUser);
                    await acb.SaveChangesAsync();
                    return (StatusCode(200));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
       

