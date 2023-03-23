using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace UI.MVVM.ViewModel
{
    class LoginViewModel
    {
        public string Username { get; set; }


        public (bool, string) ValidateLogin(string Password)
        {
            //using HotelContext context = new();
            Kitchen? Kres;
            Frontend? Fres;


            //Kres = context.Kitchens.Where(k => k.Username == Username && k.Password == Password).SingleOrDefault();

            Kres = DapperConnection.Connection.QuerySingleOrDefault<Kitchen>("select username, password from kitchens where username = @usr and password = @pass",
                new { usr = Username, pass = Password });

            if (Kres == null)
                Fres = DapperConnection.Connection.QuerySingleOrDefault<Frontend>("select username, password from frontends where username = @usr and password = @pass",
                new { usr = Username, pass = Password });

            else
                return (true, "Kitchen");

            if (Fres == null) return (false, string.Empty);
            else return (true, "Frontend");

        }
    }
}
