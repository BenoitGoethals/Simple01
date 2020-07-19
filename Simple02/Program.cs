using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple02
{
    class Program
    {
        static void Main(string[] args)
        {
            DataStorage dataStorage=new DataStorage();
            dataStorage.Populate();
            foreach (var VARIABLE in dataStorage.Data())
            {
                Console.WriteLine(VARIABLE);
            }

            Console.ReadLine();
        }
    }
}
