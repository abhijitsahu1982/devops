using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
using System.IO;

namespace RuleEngine
{
    public class Common
    {
        public enum LogicalOperation { AND, OR }

        public static string FetchOperator(string condition, string Value)
        {
            string operatorWithVal = string.Empty;

            switch (condition)
            {
                case "Contains":
                    operatorWithVal = "IN (" + Value.AppendQuotes() + ")";
                    break;
                case "Equals":
                    operatorWithVal = "=" + Value.AppendQuotes() + "";
                    break;
                case "NotEqual":
                    operatorWithVal = "<>" + Value.AppendQuotes() + "";
                    break;

            }

            return operatorWithVal;
        }

        /// <summary>
        /// Writes a single row to a CSV file.
        /// </summary>
        /// <param name="row">The row to be written</param>
        public static void WriteCSV(string Id, string Assignee, string Title)
        {

            string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                "\\" + "TFSAssignment.csv";
            if (!File.Exists(FilePath))
            {
                using (StreamWriter sw = File.CreateText(FilePath))
                {
                    sw.WriteLine(string.Format("{0},{1},{2},{3}", "Id", "Assignee", "Title", "Time Stamp"));
                }
            }

            using (StreamWriter sw = File.AppendText(FilePath))
            {
                var line = string.Format("{0},{1},{2},{3}", Id, Assignee, Title, DateTime.Now);
                sw.WriteLine(line);
                sw.Flush();
            }

        }

        /// <summary>
        /// This method is for writting the Log file with message parameter
        /// </summary>
        /// <param name="message"></param>
        public static void LogFileWrite(string message, bool isException)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (isException)
                { logFilePath = logFilePath + "\\" + "TFSErrorLog" + "." + "txt"; }
                else
                { logFilePath = logFilePath + "\\" + "TFSMessageLog" + "." + "txt"; }


                if (logFilePath.Equals("")) return;

                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();

                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(message);
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }

        }

    }

    public static class ExtentionMethod
    {
        public static string AppendQuotes(this string value)
        {
            string[] splitValues = value.Split(',');
            List<string> strList = new List<string>();
            foreach (var str in splitValues)
            {
                strList.Add("'" + str + "'");
            }
            return string.Join(",", strList.ToArray());
        }
    }
}
