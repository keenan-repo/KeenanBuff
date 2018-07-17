using KeenanBuff.Common.Logger.Interfaces;
using System;
using System.IO;

namespace KeenanBuff.Common.Logger
{

    public class FileLogger : IFileLogger
    {
        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KeenanBuffLogs");
        public string fileName = "Log_" + DateTime.UtcNow.ToString("yyyyMMdd")+ ".txt";
        public void Log(string message)
        {
            var fullFilePath = Path.Combine(filePath, fileName);
            if(!Directory.Exists(filePath)){
                Directory.CreateDirectory(filePath);
            }
            
            using (StreamWriter streamWriter = new StreamWriter(fullFilePath))
            {
                streamWriter.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss") +" Log: " + message);
                streamWriter.Close();
            }
        }

        public void Error(string message)
        {
            var fullFilePath = Path.Combine(filePath, fileName);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (StreamWriter streamWriter = new StreamWriter(fullFilePath))
            {
                streamWriter.WriteLine(DateTime.UtcNow.ToString("HH:mm:ss") + " Error: " + message);
                streamWriter.Close();
            }
        }
    }
}