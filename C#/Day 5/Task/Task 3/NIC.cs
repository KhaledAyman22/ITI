using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    enum NICType
    {
        Ethernet = 0, TokenRing = 1
    }

    internal class NIC
    {
        public string Manufacture { get; set; }
        
        public string MAC {get; set;}

        public NICType Type{get; set; }

        static NIC NetworkInterfaceControl;

        private NIC(){}

        public static NIC GetInstance()
        {
            if (NetworkInterfaceControl == null)
            {
                NetworkInterfaceControl = new NIC();
                return NetworkInterfaceControl;
            }

            else return NetworkInterfaceControl;
        }
    }
}
