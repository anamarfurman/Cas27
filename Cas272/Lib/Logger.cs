using System;
using System.IO;
namespace Cas272.Lib
{
    class Logger
    {
        private static string LogFilename = @"C:\Kurs\test.log";

        public static void setFileName(string fileName)
        {
            LogFilename = fileName;
        }

        public static void empty()
        {
            File.WriteAllText(LogFilename, string.Empty);
        }

        public static void log(string messageType, string logMessage)
        {
            writeLog($"[{DateTime.Now}] {messageType}: {logMessage}");

        }

        public static void beginTest(string testName)
        {
            writeLog(separator());
            writeLog($"Starting test: {testName}");

        }

        public static void endTest()        
        {
            writeLog(separator());
        }

        private static void writeLog(string logMessage)
        {
            using (StreamWriter fileHandle = new StreamWriter(LogFilename, true))
            {
                fileHandle.WriteLine(logMessage);
            }
        }
        private static string separator(char character = '=')
        {
            return new string(character, 100);
        }
    }
}
