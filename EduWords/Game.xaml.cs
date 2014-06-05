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
using Coding4Fun.Toolkit.Controls;

namespace EduWords
{
    public partial class Game : PhoneApplicationPage
    {
        RootObject root = HelperMethods.Clone<RootObject>(Global.Root);
        List<Word> words;
        List<Tag> tagi = Global.Tagi;
        
        int licznik = -1;
        int dobreOdpowiedzi = 0;
        int zleOdpowiedzi = 0;
        int jezyk1 = Global.Jezyk1;
        int jezyk2 = Global.Jezyk2;
        public Game()
        {
            InitializeComponent();
            words = root.words;
            makeDictionary();
            nextQuestion();
        }

        private void inputBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox senderTB = (TextBox)sender;
            if (e.Key.Equals(Key.Enter))
            {
                checkAnswer();
                senderTB.Text = String.Empty;
                
            }
        }
        private void nextQuestion()
        {
            if (words.Count > licznik+1)
            {
                licznik++;
                questionBox.Text = words[licznik].namelanguage1;
            }
            else
            {
                MessageBox.Show("You have finished the game. Good answers: " + dobreOdpowiedzi + ", bad answers: " + zleOdpowiedzi);
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void checkAnswer()
        {

            if (inputBox.Text.ToLower() == root.words[licznik].namelanguage2.ToLower())
            {
                #region wiadomosc o sukcesie
                Grid grid = this.LayoutRoot.Children[1] as Grid;
                ToastPrompt tp = new ToastPrompt();
                tp.Title = "Nice!";
                tp.Message = "Good answer";
                tp.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                tp.FontFamily = new FontFamily("Verdana");
                tp.FontSize = 22;
                tp.MillisecondsUntilHidden = 2000;
                tp.Show();
                #endregion
                nextQuestion();
                dobreOdpowiedzi++;
            }
            else
            {
                #region wiadomosc o zlej odpowiedzi
                Grid grid = this.LayoutRoot.Children[1] as Grid;
                ToastPrompt tp = new ToastPrompt();
                tp.Title = "Wrong";
                tp.Message = "Maybe better luck with next question :)";
                tp.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                tp.FontFamily = new FontFamily("Verdana");
                tp.FontSize = 22;
                tp.MillisecondsUntilHidden = 2000;
                tp.Show();
                #endregion
                nextQuestion();
                zleOdpowiedzi++;
            }
        }
        private void makeDictionary()
        {
            Debug.WriteLine(words.ToArray().Length);
            foreach (Word w in words.ToArray())
            {
                if (!((w.language1_id == jezyk1 && w.language2_id == jezyk2) || (w.language1_id == jezyk2 && w.language2_id == jezyk1)))
                {
                    words.Remove(w);
                }
                else
                {
                    Boolean hasTag = false;
                    foreach (Tag t in w.tags)
                    {
                        if (tagi.Contains(t)) hasTag = true;
                        Debug.WriteLine(w.namelanguage1 + " " + t.name + " " + tagi.Contains(t));
                    }
                    if (!hasTag)
                    {
                        words.Remove(w);
                    }
                }
            
            }
        }
    }
}