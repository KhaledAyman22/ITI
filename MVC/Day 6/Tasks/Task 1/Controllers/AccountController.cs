using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Client client)
        {
            if (client.Email == null || client.Password == null) return View();


            IdentityDbContext db = new IdentityDbContext();
            var res = db.Clients.Where(c => c.Email == client.Email && c.Password == client.Password).SingleOrDefault();

            if (res == null) { 
                ModelState.AddModelError("Email", "Wrong email or password.");
                return View();
            }

            return SetIdentity(client);
        }

        [HttpPost]
        public ActionResult Register(Client client)
        {
            if (!ModelState.IsValid) return View();

            IdentityDbContext db = new IdentityDbContext();

            var res = db.Clients.Where(c => c.Email == client.Email).SingleOrDefault();
            
            if(res != null)
            {
                ModelState.AddModelError("Email", "Email already exists, please login.");
                return View();
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return SetIdentity(client);
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Login");
        }

        private ActionResult SetIdentity(Client client)
        {
            var identity = new ClaimsIdentity(
                new List<Claim>(){
                    new Claim(ClaimTypes.Email, client.Email),
                    new Claim("Password", client.Password)
                },
                "AppCookie"
            );

            Request.GetOwinContext().Authentication.SignIn(identity);
            return RedirectToAction("Index", "Home");
        }
    }
}