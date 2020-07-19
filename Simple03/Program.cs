using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simple03
{
    class Program
    {
        static void Main(string[] args)
        {
            DataStorage dataStorage = new DataStorage(DataStorage_Status);
      //      dataStorage.Status += DataStorage_Status;
            dataStorage.Populate();
        
            Console.ReadLine();
        }

        private static void DataStorage_Status(object sender, NotificationStatus e)
        {
            Console.WriteLine(e.url+" "+e.Notfication);
        }
    }
}
