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

namespace EduWords
{
    public partial class Languages : PhoneApplicationPage
    {
        int licznik;
        CheckBox lastCheckBox;

        public Languages()
        {
            InitializeComponent();
            licznik = 0;
        }

        public void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            
            CheckBox thisCheckBox = (CheckBox)sender;
            if (licznik == 0)
            {
                licznik++;
                lastCheckBox = (CheckBox)sender;
            }
            else
            {
                if (MessageBox.Show("Do you wish to keep these languages?\n" + lastCheckBox.Name + "\n" + thisCheckBox.Name, "Languages picked", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    Global.Jezyk1 = Convert.ToInt32(Global.LanguageNameToId(lastCheckBox.Name));
                    Global.Jezyk2 = Convert.ToInt32(Global.LanguageNameToId(thisCheckBox.Name));
                    NavigationService.Navigate(new Uri("/Tags.xaml", UriKind.Relative));

                }
                else
                {
                    licznik = 0;
                    lastCheckBox.IsChecked = false;
                    thisCheckBox.IsChecked = false;
                }
            }
        }
    }
}