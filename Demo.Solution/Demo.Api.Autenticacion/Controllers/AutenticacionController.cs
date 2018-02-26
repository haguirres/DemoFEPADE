using Demo.Modelo.CustomClasses;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Demo.Api.Autenticacion.Controllers
{
    public class AutenticacionController : ApiController
    {
        //[HttpGet]
        //public async Task<IHttpActionResult> Get()
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IHttpActionResult> Post()
        //{
        //    string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        //   // Create Security key  using private key above:
        //   // not that latest version of JWT using Microsoft namespace instead of System
        //    var securityKey = new Microsoft
        //       .IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        //    // Also note that securityKey length should be >256b
        //    // so you have to make sure that your private key has a proper length
        //    //
        //    var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
        //                      (securityKey, SecurityAlgorithms.HmacSha256Signature);

        //    //  Finally create a Token
        //    var header = new JwtHeader(credentials);

        //    //Some PayLoad that contain information about the  customer
        //    var payload = new JwtPayload
        //   {
        //       { "some ", "hello "},
        //       { "scope", "http://dummy.com/"},
        //   };

        //    //
        //    var secToken = new JwtSecurityToken(header, payload);
        //    var handler = new JwtSecurityTokenHandler();

        //    // Token to String so you can use it in your client
        //    var tokenString = handler.WriteToken(secToken);
        //    return Ok();
        //}

        [HttpPost]
        [Route("api/demo/autenticacion")]
        public IHttpActionResult Authenticate([FromBody]Usuario usuario)
        {
            var loginResponse = new Usuario { };
            IHttpActionResult response;
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            string token = createToken(usuario.usuario);
            return Ok<string>(token);
            
        }

        private string createToken(string username)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddMinutes(2);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role,"Manager")
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:62657", audience: "http://localhost:62657",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
