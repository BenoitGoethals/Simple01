using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Simple02
{
   public class DataStorage
    {
       
        private IEnumerable<string> _url=new List<string>();

        private readonly Dictionary<string, string> _websitesDictionary =new Dictionary<string, string>();
   

        public void Populate()
        {
            List<Task> list=new List<Task>();
            try
            {
                _url = File.ReadAllLines("top.csv").Skip(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            foreach (var url in _url)
            {
                CancellationToken cancellationToken =new CancellationToken();
                Task task =new Task(() =>
                {
                    string response;
                    try
                    {
                         response = new WebClient().DownloadString(new Uri("http://" + url));
                    }
                    catch (Exception e)
                    {
                        response = "null";
                    }
                    _websitesDictionary.Add(url,response);

                  

                 

                },cancellationToken);
                list.Add(task);
                task.Start();
                Console.WriteLine("start task "+task.Id);
            }
          
            Task.WaitAll(list.ToArray());
           Console.WriteLine("Loaded");

        }


        public List<string> Data()
        {
            return _websitesDictionary.Values.ToList();
        }

    }
}
