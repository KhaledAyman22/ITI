using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GCLegacyTrials
{
    public class TempFile:IDisposable
    {
        FileStream fileStream;
        byte[] Data;
        public string FileName { get; }

        public TempFile()
        {
            FileName = $"TempFile{DateTime.Now.ToLongTimeString().Replace(":", string.Empty)}.dat";
            fileStream = new FileStream($@"D:\{FileName}", FileMode.Create);
            Console.WriteLine($"File {FileName} Created");
            Data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            fileStream.Write(Data, 0, Data.Length);
            fileStream.Close();
        }

        public void DoSomeWork() => Console.WriteLine("Processing......");

        ///Finalizer , Destructor , no Explicit Access Modifier , no Input parameters , 
        ~ TempFile()
        {
            File.Delete($@"D:\{FileName}");
            Console.WriteLine("Destructor");
        }

        //public void DeleteFile()
        //{
        //    File.Delete($@"D:\{FileName}");
        //    Console.WriteLine("File Deleted");
        //    ///no need to Run Destructor
        //    GC.SuppressFinalize(this);
        //}

        public void Dispose()
        {
            File.Delete($@"D:\{FileName}");
            Console.WriteLine("File Deleted using Dispose");
            ///no need to Run Destructor
            GC.SuppressFinalize(this);
            ///Remove this from Finalization List
        }
    }
}
