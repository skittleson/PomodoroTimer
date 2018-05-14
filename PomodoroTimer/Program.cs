using Ooui;
using PomodoroTimer.Core.Services;
using PomodoroTimer.Web;
using System;

namespace PomodoroTimer
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Routes.Initialization();
                OouiGlobals.Initialization();
                if (UI.ServerEnabled) {
                    Console.WriteLine("PomodoroTimer - Any key to Exit");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
