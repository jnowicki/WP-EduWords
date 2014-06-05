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
using System.Diagnostics;

namespace EduWords
{
    public partial class Tags : PhoneApplicationPage
    {
        List<Tag> allTags = new List<Tag>();
        List<Button> tagButtons = new List<Button>();
        List<Tag> chosenTags = new List<Tag>();
        
        public Tags()
        {
            InitializeComponent();
            allTags = extractTags();
            foreach (Tag t in allTags)
            {
                Button b = new Button();
                b.Name = t.name;
                b.Content = t.name;
                b.Click += tagButton_Click;
                tagButtons.Add(b);
                TagPanel.Children.Add(b);
            }
        }

        private void tagButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = (Button)sender;
            foreach (Tag t in allTags)
            {
                if (senderButton.Name == t.name) chosenTags.Add(t);
            }
            senderButton.Visibility = Visibility.Collapsed;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Uri("/Game.xaml", UriKind.Relative));
            Global.Tagi = allTags;
        }

        public List<Tag> extractTags()
        {
            List<Tag> tags = new List<Tag>();

            foreach (Word w in Global.Root.words)
            {
                tags.AddRange(w.tags);
            }

            List<Tag> properTags = tags.Distinct(new Compare()).ToList();
            foreach (Tag t in properTags)
            {
                Debug.WriteLine(t.name + ", ");
            }
            return properTags;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            string confirmMsg = "";
            foreach (Tag t in chosenTags)
            {
                confirmMsg = confirmMsg + " " + t.name;
            }
            if (MessageBox.Show("Do you want to pick these tags?\n" + confirmMsg, "Let's play", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Global.Tagi = chosenTags;
                NavigationService.Navigate(new Uri("/Game.xaml", UriKind.Relative));
            }
            else
            {
                chosenTags = new List<Tag>();
                foreach (Button b in tagButtons)
                {
                    b.Visibility = Visibility.Visible;
                }
            }
        }
    }
    class Compare : IEqualityComparer<Tag>
    {
        public bool Equals(Tag x, Tag y)
        {
            return x.name == y.name;
        }
        public int GetHashCode(Tag codeh)
        {
            return codeh.name.GetHashCode();
        }
    }
}