namespace Common
{
    ///Defualt Access level : Internal
    ///Internal : accessable inside Project (Assembly File) Only
    
    //Avaliable Access levels inside Namespace : 
    //internal (default) 
    //public
    
    public struct TypeA
    {
        ///default access modifier inside struct : private
        int X; ///private int X;

        public int Y;

        internal int Z;
    }
}