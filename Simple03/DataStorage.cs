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



namespace Simple03
{
   public class DataStorage
    {
        public DataStorage(EventHandlerNotfication eventHandlerNotfication)
        {
            Status += eventHandlerNotfication;

        }

        public DataStorage()
        {
        }

        public delegate void EventHandlerNotfication(object sender, NotificationStatus args);


        public event EventHandlerNotfication Status= delegate {} ;

        private IEnumerable<string> _url=new List<string>();

        private readonly Dictionary<string, string> _websitesDictionary =new Dictionary<string, string>();
   

        public void Populate()
        {
          
            List<Task> list=new List<Task>();
            try
            {
                _url = File.ReadAllLines("top.csv").Skip(1);
            }
            catch (Exception e)
            {
                Status(this,new NotificationStatus(Notfication.ERROR));
            }
            Status(this, new NotificationStatus(Notfication.Started));
            foreach (var url in _url)
            {
                CancellationToken cancellationToken =new CancellationToken();
                Task task =new Task(() =>
                {
                    string response;
                    try
                    {
                         response = new WebClient().DownloadString(new Uri("http://" + url));
                         _websitesDictionary.Add(url, response);

                         Status(this, new NotificationStatus(Notfication.New, url, response));

                    }
                    catch (Exception e)
                    {
                        response = "null";
                        Status(this, new NotificationStatus(Notfication.ERROR, url, response));
                    }
                   


                },cancellationToken);
                list.Add(task);
                task.Start();
              
            }
          
            Task.WaitAll(list.ToArray());

            Status(this, new NotificationStatus(Notfication.Loaded));
        }


        public List<string> Data()
        {
            return _websitesDictionary.Values.ToList();
        }

    }
}
