using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    ///by default public abstract Members
    interface IMyType
    {
        void FunOne();

        int FunTwo(int T);

        public void FunThree(int T , int TT)
        {
            Console.WriteLine("Default implementation");
        }

        int PropOne { get; set; }
    }


    class TypeOne : IMyType
    {
        int X;

        public void FunThree ( int T , int TT ) 
        {
            Console.WriteLine("Class TypeOne Implementation");
        }


        public TypeOne(int _X)
        {
            X = _X;
        }

        public int PropOne 
        { 
            get { return X; } 
            set { X = value; } 
        }

        public void FunOne()
        {
            Console.WriteLine("Fun One Class TypeOne");
        }

        public int FunTwo(int T)
        {
            return T + X;
        }
    }

    struct TypeTwo : IMyType
    {
        public int X;
        public int Y;

        public TypeTwo(int _x , int _y)
        {
            X = _x;
            Y = _y;
        }

        public int PropOne 
        { get => X + Y; set { X = value; Y = value; } }

        public void FunOne()
        {
            Console.WriteLine("Fune One Struct Type Two");
        }

        public int FunTwo(int T)
        {
            return T + X + Y;
        }
    }


}
