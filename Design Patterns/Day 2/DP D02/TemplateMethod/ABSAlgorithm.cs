using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TemplateMethod
{

    /// <summary>
    /// Define Skelton of an Algorithm in a Function
    /// </summary>
    abstract class ABSAlgorithm
    {

        public void DoSomeAlgorithmWork ()
        {
            LoadData();

            ProcessData();

            PublishOutput();

            ///Deffere Some Steps to Subclass
            SaveResults();

            OptionalStep();
        }

        public abstract void LoadData();
        public abstract void SaveResults();

        public void ProcessData() => Console.WriteLine("Data Processing");
        public void PublishOutput() => Console.WriteLine("Agorithm Output");

        public virtual void OptionalStep () { }





    }
}
