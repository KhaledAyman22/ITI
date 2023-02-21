using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Publisher:EntityBase
    {
        private string pub_id;
        private string? pub_name;
        private string? city;
        private string? state;
        private string? country;

        public string PublisherID
        {
            get => pub_id;
            set
            {
                if (value != pub_id)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    pub_id = value;
                }
            }
        }
        public string? PublisherName
        {
            get => pub_name;
            set
            {
                if (value != pub_name)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    pub_name = value;
                }
            }
        }
        public string? City
        {
            get => city;
            set
            {
                if (value != city)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    city = value;
                }
            }
        }
        public string? PublisherState
        {
            get => state;
            set
            {
                if (value != state)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    state = value;
                }
            }
        }
        public string? Country
        {
            get => country;
            set
            {
                if (value != country)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    country = value;
                }
            }
        }


    }
}
