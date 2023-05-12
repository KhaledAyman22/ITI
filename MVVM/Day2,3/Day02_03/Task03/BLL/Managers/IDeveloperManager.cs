using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task03.BLL.UIModels;

namespace Task03.BLL.Managers
{
    public interface IDeveloperManager
    {
        Task<IEnumerable<Developer_UI>?> GetAll();
        Task<Developer_UI?> Get(int id);
        Task Add(Developer_UI student);
        Task Update(Developer_UI student);
        Task Delete(int id);
    }
}
