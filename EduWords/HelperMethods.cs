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
using System.Threading.Tasks;
using Serialization;

namespace EduWords
{
    public static class HelperMethods
    {

        public static T Clone<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                SilverlightSerializer.Serialize(obj, stream);
                stream.Position = 0;
                return (T)SilverlightSerializer.Deserialize(stream);
            }
        }

    }
}
