using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    /// <summary>
    /// Publisher class
    /// </summary>
    internal class Ball
    {
        public int ID {  get; set; }

        Location ballLocation;
        internal Location BallLocation 
        { 
            get => ballLocation;
            set 
            {
                if (value != ballLocation)
                {
                    Location Delta = ballLocation - value;
                    ballLocation = value;
                    ///Notify Subsc
                    ///invoke Subsc. Call Back Methods
                    BallLocationChanged?.Invoke(Delta);
                }
            }
        }

        ///Publisher Declare Event 
        //public event Action BallLocationChanged;
        ///define Delegate Object
        ///V2.0
        public event Action<Location> BallLocationChanged;

    }
}
