using System;

namespace Simple03
{
    public class NotificationStatus:EventArgs
    {
        public NotificationStatus()
        {
        }

        public NotificationStatus(Notfication notfication,string url=null, string content=null)
        {
            this.url = url;
            this.content = content;
            Notfication = notfication;
        }

        public string url { get; set; }
        public string content { get; set; }

        public Notfication Notfication { get; set; }

        public override string ToString()
        {
            return $"{nameof(url)}: {url}, {nameof(content)}: {content}, {nameof(Notfication)}: {Notfication}";
        }
    }
}