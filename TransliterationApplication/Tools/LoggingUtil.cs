using System;

namespace Transliteration.TransliterationApplication.Tools
{
    class LoggingUtil
    {
        public static void WriteToLog(string toBeLogged)
        {
            try
            {
                //maybe add log file size check; delete once reaches 1Mb or so.
                System.IO.File.AppendAllText(
                    System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule
                        .FileName) + @"\Log.txt", toBeLogged + Environment.NewLine);
            }
            catch (System.NullReferenceException e)
            {
                //silent; logging failed.
            }
        }
    }
}
