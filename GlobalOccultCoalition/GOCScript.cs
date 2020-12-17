using MEC;
using Synapse;
using System.Collections.Generic;

namespace GlobalOccultCoalition
{
    public class GOCScript : Synapse.Api.Roles.Role
    {
        public override int GetRoleID() => 19;

        public override string GetRoleName() => "GOC-PHYSICS-Member";

        public override Team GetTeam() => Team.RIP;

        public override List<Team> GetFriends() => PluginClass.Config.ff ? new List<Team> { Team.CDP } : new List<Team> { Team.CDP, Team.RIP };

        public override List<Team> GetEnemys() => new List<Team> { Team.CHI, Team.SCP };

        public override void Spawn()
        {
            Player.DisplayInfo = $"<color={PluginClass.Config.Color}>GOC-PHYSICS-Member</color>";
            Player.RoleType = RoleType.NtfLieutenant;
            Timing.CallDelayed(0.2f, () => Player.Position = PluginClass.Config.GOCSpawn.Parse().Position);
            Player.Inventory.Clear();
            foreach (var item in PluginClass.Config.Inventory)
                Player.Inventory.AddItem(item.Parse());
            Player.Health = PluginClass.Config.Health;
            Player.MaxHealth = PluginClass.Config.Health;
            Player.Ammo9 = PluginClass.Config.Ammo.Ammo9;
            Player.Ammo7 = PluginClass.Config.Ammo.Ammo7;
            Player.Ammo5 = PluginClass.Config.Ammo.Ammo5;
        }

        public override void DeSpawn() => Player.DisplayInfo = "";
    }
}
