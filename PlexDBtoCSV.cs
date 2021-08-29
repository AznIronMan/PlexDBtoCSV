using System;
using System.Diagnostics;

namespace PlexDBtoCSV
{
    class PlexDBtoCSV
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                System.Environment.Exit(1);
            }
            String Database = args[1];
            String SQLite = "sqlite3.exe";
            String SQLExec = "plex_exec.txt";
            String parms = "\"" + Database + "\" -init " + SQLExec + " .exit";
            Console.WriteLine(parms);
            StartIt(SQLite, parms);
            return;
        }

        static void StartIt(String exe, String parm)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = exe;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = parm;
            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                return;
            }
        }
    }
}