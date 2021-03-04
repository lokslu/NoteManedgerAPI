    using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NoteManedgerAPI.Auth;
using NoteManedgerAPI.EF;
using NoteManedgerAPI.EF.Entity;
using NoteManedgerAPI.Models;
using NoteManedgerAPI.repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteManedgerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly _db_User_manedger M_db_User;

        public UserController(ApplicationContext db)
        {
            M_db_User = new _db_User_manedger(db);
        }

        // GET: api/<controller>
       [HttpGet]
        [AllowAnonymous]
        public User ssss()
       {
            var user = new User
            {
                firstName = "s",
                lastName = "s",
                email = "lokslu1@gmail.com",
                password = "qwerty",
            };
            return this.M_db_User.GetUser_by_Email(user.email);

        }

        // GET api/<controller>/5
        

        [HttpGet("{name}")]
        public UserModel Get(string name)
        {
            var user = M_db_User.GetUser_by_Email(name);
            return new UserModel()
            {
                id = user.id,
                firstname = user.firstName,
                lastname = user.lastName,
                email = user.email,
            };
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async void register([FromBody] RegisterModel model)
        {
            var user = new User
            {
                firstName = model.firstName,
                lastName = model.lastName,
                email = model.email,
                password = model.password,
            };
            if (M_db_User.checkNewUser(user.email))
            {
                this.M_db_User.Insert(user);
                await Login(new LoginModel() { email = model.email, password = model.password });   
            }
            else
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("User with this email already exists.");
                return;
            }
        }
       
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task Login([FromBody] LoginModel model)
        {

            var identity = GetIdentity(model.email, model.password);

            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
               access_token = encodedJwt,
               username = identity.Name
            };

            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            Console.WriteLine("Login succeed");
        }

        private ClaimsIdentity GetIdentity(string email, string password)// тип ClaimsIdentity
        {
           
            if (M_db_User.checkUser(email, password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

      

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
