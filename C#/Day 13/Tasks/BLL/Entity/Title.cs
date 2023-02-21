using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Title : EntityBase
    {
        private string title_id;
        private string title;
        private string type;
        private string? pub_id;
        private decimal? price;
        private decimal? advance;
        private int? royalty;
        private int? ytd_sales;
        private string? notes;
        private DateTime pubdate;


        public string TitleID
        {
            get => title_id;
            set
            {
                if (value != title_id)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    title_id = value;
                }
            }
        }
        public string TitleName
        {
            get => title;
            set
            {
                if (value != title)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    title = value;
                }
            }
        }
        public string Type
        {
            get => type;
            set
            {
                if (value != type)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    type = value;
                }
            }
        }
        public string? PublisherID
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
        public decimal? Price
        {
            get => price;
            set
            {
                if (value != price)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    price = value;
                }
            }
        }
        public decimal? Advance
        {
            get => advance;
            set
            {
                if (value != advance)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    advance = value;
                }
            }
        }
        public int? Royalty
        {
            get => royalty;
            set
            {
                if (value != royalty)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    royalty = value;
                }
            }
        }
        public int? YTDSales
        {
            get => ytd_sales;
            set
            {
                if (value != ytd_sales)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    ytd_sales = value;
                }
            }
        }
        public string? Notes
        {
            get => notes;
            set
            {
                if (value != notes)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    notes = value;
                }
            }
        }
        public DateTime PublishDate
        {
            get => pubdate;
            set
            {
                if (value != pubdate)
                {
                    if (State != EntityState.Added)
                        State = EntityState.Changed;
                    pubdate = value;
                }
            }
        }
    }
}
