using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple01
{
    class Program
    {
        static void Main(string[] args)
        {
            Semaphore semaphoreObject = new Semaphore(initialCount: 1, maximumCount: 1, name: "PrinterApp");
            Printer printerObject = new Printer();

            for (int i = 0; i < 20; ++i)
            {
                int j = i;
                Task.Factory.StartNew(() =>
                {
                    semaphoreObject.WaitOne();
                    printerObject.Print(j);
                    semaphoreObject.Release();
                });
            }
            Console.ReadLine();
        }
    }

    class Printer
    {
        public void Print(int documentToPrint)
        {
            Console.WriteLine("Printing document: " + documentToPrint);
            //code to print document
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

    }
}
