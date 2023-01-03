using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    public static class LogList
    {
        private static List<string> logList = new List<string>();

        public static void AddLog(string str) {
            logList.Add(str);
            // TODO insert log to database
        }

        public static void ClearLogList(string str) {
            logList.Clear();
        }


    }
}
