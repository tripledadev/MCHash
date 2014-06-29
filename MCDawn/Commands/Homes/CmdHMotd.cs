// Written by jonnyli1125 for MCDawn
using System;
using System.IO;

namespace MCDawn
{
    public class CmdHMotd : Command
    {
        public override string name { get { return "hmotd"; } }
        public override string[] aliases { get { return new string[] { }; } }
        public override string type { get { return "homes"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public CmdHMotd() { }

        public override void Use(Player p, string message)
        {
            try
            {
                string prefix = Server.HomePrefix;
                if (p.level.name != prefix + p.name.ToLower()) { p.SendMessage("You must be on your home map to use /hmotd ofc"); return; }
                if (message == "") { message = "ignore"; }
                Command.all.Find("map").Use(p, "motd " + message);
            }
            catch { Help(p); }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "&3/hmotd <motd> - Change the MOTD on your home map! :D");
            Player.SendMessage(p, "&9Example:");
            Player.SendMessage(p, "&2/hmotd This is a MOTD");
            Player.SendMessage(p, "&9This would make the loading screen when joining say.");
        }
    }
}
