using System;
using System.IO;

namespace PegaBugApp
{
    public class Util
    {
        public static string connectionStringServerDB = @""";
        public void LogMessageToFile(string msg)
        {
            //salva exception no log
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "Log\\" + string.Format("{0:dd-MM-yyyy_hh-mm-ss}", DateTime.Now) +".txt", msg);
        }
    }
}