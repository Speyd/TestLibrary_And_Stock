using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logers
{
    public class HelpLoger : Loger
    {
        public static void addLoger(string? text, DateTime time, StackTrace stackTrace)
        {
            Loger.addLoger(text, time, typeof(HelpLoger), stackTrace);
        }
        public static new string showLog()
        {
            return Loger.showLog(typeof(HelpLoger));
        }
    }
}
