using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookieJwtBearer.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CookieJwtBearer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Jwt()
        {
            var signingHandler = new JwtSecurityTokenHandler();
            var jwtToken = signingHandler.CreateJwtSecurityToken(
                JwtParameters.Issuer,
                JwtParameters.Audience,
                new ClaimsIdentity(User.Claims, "jwt"),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.Add(JwtParameters.ValidFor),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(JwtParameters.SigningKey), SecurityAlgorithms.HmacSha256));

            return Content(jwtToken.RawData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
