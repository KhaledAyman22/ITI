using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.HelperEntity
{
    public class PublisherWithID
    {
        public required string PubId { get; set; }
        public required string PubName { get; set; }
    }
}
