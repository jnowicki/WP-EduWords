using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EduWords
{
    public class WebStatic
    {
        async public void test()
        {
            HttpClient httpClient = new HttpClient();
            string data = await httpClient.GetStringAsync("http://project-midas.com/daniel_things/eduWordsPhone/languages.json");
            RootObject language = new RootObject();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(language.GetType());
            try
            {
                language = ser.ReadObject(ms) as RootObject;
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show(e.StackTrace);
            }
            string teststring = "";
            Debug.WriteLine(language.name);
        }
        
        public void WebDownload()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri("http://project-midas.com/daniel_things/eduWordsPhone/languages.json"));
        }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var data = e.Result;
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
            Debug.WriteLine(data);
            /*
            ser.WriteObject(stream1, data);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            Console.Write("JSON form of Person object: ");
            Console.WriteLine(sr.ReadToEnd());
            stream1.Position = 0;
            RootObject root = (RootObject)ser.ReadObject(stream1);
            Debug.WriteLine(root.name);
             */
        }
        
    }

    public class RootObject
    {
        public int id {get; set;}
        public string name {get; set;}
        public string url { get; set; }
    }
}
