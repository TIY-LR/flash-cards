using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace FlashCards.web
{
    public class Utils
    {
    }


    public class Logging
    {
        public string fileName { get; set; } = @"C:\tmp\log.txt";

        public void Log(string msg)
        {
            var writer = System.IO.File.AppendText(fileName);
            writer.WriteLine(DateTime.Now.ToShortDateString() + ":" + msg);
        }
    }
}

