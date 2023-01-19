namespace Task_1
{
    internal partial class Program
    {
        [Flags]
        public enum SecurityLevel:byte
        {
            guest               = 0b_0000_0001, 
            Developer           = 0b_0000_0010,
            secretary           = 0b_0000_0100,
            DBA                 = 0b_0000_1000,
            securityOfficer     = 0b_0000_1111
        }
    }
}