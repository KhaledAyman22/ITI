using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTrials
{
    public interface IManager<T>
    {
        bool Add(T Item);
        bool Delete(long ID);
        bool Update(T Item);
        List<T> GetALL();
        T GetByID(long ID);
    }
}
