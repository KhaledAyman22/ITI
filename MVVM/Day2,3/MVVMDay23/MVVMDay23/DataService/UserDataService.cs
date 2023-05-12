using MVVMDay23.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MVVMDay23.DataService
{
    public class UserDataService
    {
        string Url = "https://jsonplaceholder.typicode.com/users";
        HttpClient Client= new HttpClient();


        public IEnumerable<User> GetAll()
        {
            var content= Client.GetStringAsync(Url).Result;
            var data = JsonConvert.DeserializeObject<List<User>>(content);
            return data;
        }

    }
}
