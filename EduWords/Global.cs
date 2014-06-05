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

namespace EduWords
{
    public static class Global
    {
        private static List<Tag> tagi = new List<Tag>();
        public static List<Tag> Tagi
        {
            set { tagi = value; }
            get { return tagi; }
        }

        private static int jezyk1;
        public static int Jezyk1
        {
            set { jezyk1 = value; }
            get { return jezyk1; }
        }
        private static int jezyk2;
        public static int Jezyk2
        {
            set { jezyk2 = value; }
            get { return jezyk2; }
        }
        private static RootObject root;
        public static RootObject Root
        {
            set { root = value; }
            get { return root; }
        }

        public static int LanguageNameToId(String language)
        {
            switch (language)
            {
                case "Niemiecki":
                    return 1;
                case "Deutsch":
                    return 2;
                case "Angielski":
                    return 3;
                case "English":
                    return 4;
                case "Polski":
                    return 5;
                case "Hiszpanski":
                    return 6;
                case "Wloski":
                    return 7;
                case "Norweski":
                    return 8;
                case "Kaszubski":
                    return 9;
                case "Japonski":
                    return 10;
                case "Rosyjski":
                    return 11;
                case "Portugalski":
                    return 12;
                case "Bengalski":
                    return 13;
                case "Chinski":
                    return 14;
                case "Swahili":
                    return 15;
                default:
                    throw new FormatException();
            };
        }


    }
}
