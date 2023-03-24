using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop
{
    static class CurrentJWT
    {
        static public string? Token { get; set; }
        static public DateTime Expiration { get; set; }
    }
}
