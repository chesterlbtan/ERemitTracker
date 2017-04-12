using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AutoUpdateExe
{
    public static class Update
    {
        public static bool NewUpdateAvailable(string updatelink, string AppLink)
        {
            if (!File.Exists(updatelink))
                return false;

            //should not return false
            if (!File.Exists(AppLink))
                return false;

            string newLink = File.ReadAllText(updatelink);
            string oldLink = File.ReadAllText(AppLink);

            if (newLink == oldLink)
                return false;
            else
                return true;
        }

        public static void UpdateAction(string updatelink, string AppLink, string processname)
        {
            // create command prompt here
            List<string> cmdtxt = new List<string>();
            cmdtxt.Add("echo off");
            cmdtxt.Add("timeout 3");
            cmdtxt.Add("Taskkill /IM \"" + processname + "\" /F");
            cmdtxt.Add("copy /Y \"" + updatelink + "\" \"" + AppLink + "\"");
            cmdtxt.Add("\"" + AppLink + "\"");
            cmdtxt.Add("del %0");
            File.WriteAllLines("update.bat", cmdtxt.ToArray());

            Process gona = new Process();
            gona.StartInfo.FileName = "update.bat";
            gona.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            gona.Start();
        }
    }
}
