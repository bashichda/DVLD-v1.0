using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsEventLog
    {
        private static string _sourceName = "DVLD_Application";

        public static void LogException(Exception ex)
        {
            try
            {
                if (!EventLog.SourceExists(_sourceName))
                {
                    EventLog.CreateEventSource(_sourceName, "Application");
                }

                string LogMessage = $"Message : {ex.Message}\n" +
                                    $"Source : {ex.Source}\n" +
                                    $"StackTrace : {ex.StackTrace}";

                EventLog.WriteEntry(_sourceName, LogMessage, EventLogEntryType.Error);

            }
            catch (Exception exception)
            {
                clsEventLog.LogException(exception);
            }
        }
    }
}
