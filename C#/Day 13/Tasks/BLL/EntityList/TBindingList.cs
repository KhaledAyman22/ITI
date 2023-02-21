using BLL.Entity;
using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityList
{
    public class TBindingList:BindingList<Title>
    {
        public TBindingList(List<Title> Ts):base(Ts){}


        protected override void RemoveItem(int index)
        {
            if (!string.IsNullOrEmpty(Items[index].TitleID))
            {
                if (TitleManager.DeleteTitle(Items[index]))
                    base.RemoveItem(index);
            }

            else
                base.RemoveItem(index);
        }
    }
}
