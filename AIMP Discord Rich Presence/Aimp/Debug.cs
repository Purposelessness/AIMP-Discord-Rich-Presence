using System;
using System.Collections.Generic;

namespace AIMP_Discord_Rich_Presence.Aimp
{
    public class Debug
    {
        private static Debug _instance;
        public List<string> List { get; } = new List<string>();
        public EventHandler<string> OnLogInvoked;

        public static Debug Instance => _instance ?? (_instance = new Debug());
        public void Log(string message)
        {
            List.Add(message);
            OnLogInvoked?.Invoke(this, message);
        }
    }
}