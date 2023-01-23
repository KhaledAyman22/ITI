using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05
{
    class GEngine
    {
        int Data;

        GEngine(int _Data)
        {
            Data = _Data;
            Console.WriteLine("Ctor");
        }

        public static GEngine SingleTonObj { get; } = new(134679);

        //static GEngine Obj;
        //static GEngine() { Obj = new GEngine(134679); }
        //public static GEngine SingleTonObj
        //{
        //    get
        //    {
        //        return Obj;
        //    }
        //}

        public void DoSomeGraphicsWork()
        {
            Console.WriteLine("Processing.....");
        }
    }
}

