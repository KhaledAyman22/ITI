namespace Task
{

    class CustomStringComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int len = Math.Min(x.Length, y.Length);

            for (int i = 0; i < len; i++)
            {
                if (x[i] == y[i] || x[i] - 'a' == y[i] || x[i] == y[i] - 'a') continue;
                if (x[i].ToString().ToLower()[0] > y[i].ToString().ToLower()[0]) return 1;
                else return -1;

            }

            return 0;
        }
    }
}