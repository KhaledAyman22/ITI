using BLL.Entity;
using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityList
{
    public class TitleList:List<Title>
    {
        void Remove(Title? value)
        {
            TitleManager.DeleteTitle(value);

            base.Remove(value);
        }
    }
}
