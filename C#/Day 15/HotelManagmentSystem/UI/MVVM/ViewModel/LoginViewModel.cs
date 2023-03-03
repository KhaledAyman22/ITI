using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.MVVM.ViewModel
{
    class LoginViewModel
    {
        public string Username { get; set; }


        public (bool, string) ValidateLogin(string Password)
        {
            using HotelContext context = new();
            Kitchen? Kres;
            Frontend? Fres;

            Kres = context.Kitchens.Where(k => k.Username == Username && k.Password == Password).SingleOrDefault();

            if (Kres == null)
                Fres = context.Frontends.Where(f => f.Username == Username && f.Password == Password).SingleOrDefault();
            else return (true, "Kitchen");

            if (Fres == null) return (false, string.Empty);
            else return (true, "Frontend");
        }
    }
}
