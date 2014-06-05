using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using Coding4Fun.Toolkit.Controls;
namespace EduWords
{
    public partial class MainPage : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            if(settings.Contains("root")) Global.Root = (RootObject) settings["root"];
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Languages.xaml", UriKind.Relative));
        }

        private void synchButton_Click(object sender, RoutedEventArgs e)
        {
            WebDownload();
        }
        public void WebDownload()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri("http://project-midas.com/daniel_things/eduWordsPhone/words.json"));
        }
        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            RootObject root = new RootObject();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(root.GetType());
            ms.Position = 0;
            root = ser.ReadObject(ms) as RootObject;
            ms.Close();
            #region Saving to storage
            if (settings.Contains("root"))
            {
                settings.Remove("root");
                settings.Add("root", root);
                settings.Save();
                Global.Root = root;
            }
            else
            {
                settings.Add("root", root);
                settings.Save();
                Global.Root = root;
            }
            #endregion
            #region Toastprompt
            Grid grid = this.LayoutRoot.Children[1] as Grid;
            ToastPrompt tp = new ToastPrompt();
            tp.Title = "Synch success";
            tp.Message = "Downloaded " + root.words.Count + " words" ;
            tp.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            tp.FontFamily = new FontFamily("Verdana");
            tp.FontSize = 22;
            tp.MillisecondsUntilHidden = 3000;
            tp.Show();
            #endregion
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string message = " ";
            foreach (Word w in Global.Root.words)
            {
                message = message + "\n" + w.namelanguage1 + " - " + w.namelanguage2; 
            }
            MessageBox.Show(message);
        }
    }
}