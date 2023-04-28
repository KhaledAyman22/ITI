using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DummyDb
    {
        public static int TracksCounter = 0;
        public static int TraineesCounter = 0;

        public static List<Track> Tracks = new();
        public static List<Trainee> Trainees = new();
    }
}
