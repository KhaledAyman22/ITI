namespace Task
{
    class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if(x == null || y == null) return false;
            return new string(x.OrderBy(c => c).ToArray()) == new string(y.OrderBy(c => c).ToArray());
        }

        public int GetHashCode(string obj)
        {
            return base.GetHashCode();
        }
    }
}