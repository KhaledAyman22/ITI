using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.DAL.Models;

namespace Task02.DAL.Repos
{
    public interface IDeveloperRepo
    {
        IEnumerable<Developers>? GetAll();
        Developers? Get(int id);
        void Add(Developers student);
        void Update(Developers student);
        void Delete(int id);
        void Save();
    }
}
