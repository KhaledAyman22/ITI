using IdentityWebApp_43.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace IdentityWebApp_43.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Accout
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User usr)
        {
            //check if valid user (ModelState.IsValid)
            //Insert newUser into DB
            //Create User Identity for this user Using Claims (Name, Email, Password, Phone)
            //Owin Cookie middleware, user identity to create cookie for this user to authenticate him
            
            // Redirect to Home/Index


            if(ModelState.IsValid)
            {
                MainDbContext context = new MainDbContext();

                context.Users.Add(usr);
                context.SaveChanges();

                var userIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim("Name", usr.Name),
                    new Claim(ClaimTypes.Email, usr.Email),
                    new Claim("Password", usr.Password)
                }, "AppCookie");

                //Owin Authentication manager
                Request.GetOwinContext().Authentication.SignIn(userIdentity);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User usr)
        {
            //get User from Db
            //check user is not null
            //if not null { OWIN }
            //else return view

            MainDbContext context = new MainDbContext();

            var loggedUser = context.Users.FirstOrDefault( 
                u => u.Email == usr.Email && u.Password == usr.Password);

            if (loggedUser != null)
            {
                var signInIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, usr.Email),
                    new Claim("Password", usr.Password)
                }, "AppCookie");

                //Owin Authentication manager
                Request.GetOwinContext().Authentication.SignIn(signInIdentity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Name", "User is not Existed");

                return View();
            }
        }

        public ActionResult Logout()
        {
            //Destroy Cookie for this user

            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Login");
        }
    }
}