using System;
using System.IO;

namespace PegaBugApp
{
    /// <summary>
    /// This is where you put the connection string and log everthing
    /// </summary>
    public class Util
    {
        public static string connectionStringServerDB = @"";
        public void LogMessageToFile(string msg)
        {
            //save log exception
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "Log\\" + string.Format("{0:dd-MM-yyyy_hh-mm-ss}", DateTime.Now) +".txt", msg);
        }
    }
}