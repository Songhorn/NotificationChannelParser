using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationChannelsParser
{
    class Program
    {
        static void Main(string[] args)
        {
            NotificationChannel Channels;
            string TempTitle = "";
            NotificationTitle notiTitle = new NotificationTitle();
            List<NotificationChannel> ChannelLst = new List<NotificationChannel>();
            notiTitle.Input();
            ChannelLst = AssignNotification(notiTitle.Title);
            int i = 1;
            foreach (NotificationChannel NotiCH in ChannelLst)
            {
                if (i < ChannelLst.Count)
                {
                    TempTitle += NotiCH.Channel + ", ";
                }
                else
                {
                    TempTitle += NotiCH.Channel;
                }
                i++;
            }
            Channels = new NotificationChannel(TempTitle);
            Channels.Output();
            Console.ReadLine();         
        }
        public class NotificationTitle
        {
            string Titles;
            public NotificationTitle() 
            {
                this.Titles = "[BE][FE][QA][Urgent] there is error";
            }
            public NotificationTitle(string titles)
            {
                this.Titles = titles;
            }
            public string Title
            {
                get { return Titles; }
                set { Titles = value; }
            }
            public void Input()
            {
                Console.Write("Please Input the Notification Title: ");
                Titles = Console.ReadLine();
            }
            public void Output()
            {
                Console.WriteLine(Titles);
            }
        }
        public static List<NotificationChannel> AssignNotification(string NotiTitle)
        {
            List<NotificationChannel> ChannelLst = new List<NotificationChannel>();
            string[] TitleLst = NotiTitle.Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in TitleLst)
            {
                if(s.Equals("BE") || s.Equals("FE") || s.Equals("QA") || s.Equals("Urgent"))
                {
                    ChannelLst.Add(new NotificationChannel(s));
                }
            }
            return ChannelLst;
        }
        public class NotificationChannel
        {
            string Channels;
            public NotificationChannel()
            {
                this.Channels = "BE, FE, Urgent";
            }
            public NotificationChannel(string channel)
            {
                this.Channels = channel;
            }
            public string Channel
            {
                get { return Channels; }
                set { Channels = value; }
            }
            public void Output()
            {
                Console.WriteLine("Receive channels: " + Channels);
            }
        }
    }
}
