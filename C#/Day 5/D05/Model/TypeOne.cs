namespace Model
{
    public class TypeOne
    {
        /*private*/ int x; ///Default private 

        private protected int M; ///inside derived classes from the same Project ONLY

        protected int y; ///any Class inheriting from TypeOne (within the same assembly or outside assembly file)

        internal int z; ///Same Project Only

        internal protected int L; ///inside assembly file and out of assembly file inside Derived classes only

        public int K;

        public override string ToString()
        {
            return $"{x} , {y} , {z} ,{L}, {M},{K}";
        }
    }
}