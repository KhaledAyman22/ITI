using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.BLL.UIModels;

namespace Task02.BLL.Managers
{
    public interface IDeveloperManager
    {
        IEnumerable<Developer_UI>? GetAll();
        Developer_UI? Get(int id);
        void Add(Developer_UI student);
        void Update(Developer_UI student);
        void Delete(int id);
    }
}
