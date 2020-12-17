using Synapse;
using Synapse.Api;
using System.Linq;
using UnityEngine;
using ev = Synapse.Api.Events.EventHandler;

namespace GlobalOccultCoalition
{
    public class EventHandlers
    {
        public EventHandlers()
        {
            ev.Get.Round.TeamRespawnEvent += Respawn;
            ev.Get.Player.PlayerEscapesEvent += Escape;
        }

        private void Escape(Synapse.Api.Events.SynapseEventArguments.PlayerEscapeEventArgs ev)
        {
            switch (ev.Player.RealTeam)
            {
                case Team.MTF when ev.Player.Cuffer?.RoleID == 19:
                case Team.RSC when ev.Player.Cuffer?.RoleID == 19:
                    ev.SpawnRole = RoleType.None;
                    ev.Player.RoleID = 19;
                    break;

                case Team.CDP when IsClassDNearGOC(ev.Player):
                    ev.SpawnRole = RoleType.None;
                    ev.Player.RoleID = 19;
                    break;

                case Team.RIP when ev.Player.RoleID == 19 && (ev.Player.Cuffer?.Team == Team.RSC || ev.Player.Cuffer?.Team == Team.MTF):
                    ev.SpawnRole = RoleType.None;
                    ev.Player.RoleID = (int)RoleType.NtfLieutenant;
                    break;
            }
        }

        private bool IsClassDNearGOC(Player classD)
        {
            var chaos = Team.CHI.GetPlayers().Count;
            var goc = Server.Get.GetPlayers(x => x.RoleID == 19).Count;

            //If Only Chaos exist he become Chaos
            if (chaos > 0 && goc == 0) return false;
            //If Only GOC exist he become GOC
            if (goc > 0 && chaos == 0) return true;

            var players = Server.Get.GetPlayers(x => x.Room.RoomType == RoomInformation.RoomType.SURFACE && (x.RealTeam == Team.CHI || x.RoleID == 19));
            //If Goc and Chaos exist but none of them is at the surface he will become Chaos
            if (players.Count == 0) return false;
            players.OrderBy(x => Vector3.Distance(classD.Position, x.Position));
            //If the nearest player to the ClassD a GOC he will become a GOC
            if (players.First().RoleID == 19) return true;
            return false;
        }

        private void Respawn(Synapse.Api.Events.SynapseEventArguments.TeamRespawnEventArgs ev)
        {
            if(ev.Team == Respawning.SpawnableTeamType.NineTailedFox && UnityEngine.Random.Range(1f,100f) <= PluginClass.Config.SpawnChanche)
            {
                ev.Allow = false;
                foreach (var player in ev.Players)
                    player.RoleID = 19;
                Map.Get.GlitchedCassie($"G O C HasEntered AwaitingRecontainment {Server.Get.GetPlayers(x => x.RealTeam == Team.SCP).Count} ScpSubjects");
            }
        }
    }
}
