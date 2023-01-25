using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace D07
{
   



    public class Helper<T>
        where T :
        ///Primary Constraint 
        ///0:1 , Zero or One Constraint
        ///Special Primary Constraint
        ///class , /// T must be class
        ///Special Primary Constraint
        ///struct,
        ///Enum,
        ///Attribute,
        ///General Primary Constraint T : SpecificClass
        //Point,

        INumber<T>,
        IComparable
        ///Secondary Constraint 
        ///Interface Constraint
        ///T : must be any class/struct Implementing IComparable interface
        ///0:* , accept multiple interface constraint
        
        //,new()
        ///Ctor Constraint
        ///0:1
        ///only one ctor constaint available
        ///new() : T have accessable parameterless ctor

    {

        public Helper()
        {
            ///valid 
            ///1. Declaration
            T x;
            T y;
            //2. Initialization
            x = default;
            ///3. =
            y = x;
            ///4. return Statment
            ///return x;
            ///5. System.Object
            if (x.Equals(y))
                ;
            string Str = x.ToString();

            if (y.GetType() == x.GetType()) ;

            int R = y.GetHashCode();

            ///Where T:IComparable
            if (x.CompareTo(y) > 0) ;

            ///where T:class
            //if (x == y) ;
            //x = null;

            ///where T:struct
            //x = new T();

            /// not Valid
            //x = 0;
            //x = null;
            //x = new T();

        }


        public int SearchArray(T[] Arr , T Value)
        {
            for ( int i=0; i < Arr?.Length ; i++ ) 
                if (Arr[i].Equals( Value)) return i;
            return -1;
        }

        public static void BSort(T[] Arr)
        {
            for (int i = 0; i < Arr?.Length; i++)
                for (int j = 0; j < Arr.Length - i - 1; j++)
                    if (Arr[j].CompareTo(Arr[j + 1]) > 0)
                        SWAP(ref Arr[j], ref Arr[j + 1]);

        }
        public static void SWAP(ref T x, ref T y)
        {
            T Temp = x;
            x = y;
            y = Temp;
        }

        public static T Sum ( T X , T y) {  return X + y; }

        public static T SumArray(T[] Arr)
        {
            T Sum = T.Zero;
            //Sum = default;
            for (int i = 0; i < Arr?.Length; i++)
                Sum += Arr[i];
            return Sum;
        }

    }
}
