using Synapse.Api.Plugin;

namespace GlobalOccultCoalition
{
    [PluginInformation(
        Name = "GlobalOccultCoalition",
        Author = "Dimenzio",
        Description = "",
        LoadPriority = 5,
        SynapseMajor = 2,
        SynapseMinor = 2,
        SynapsePatch = 0,
        Version = "v.1.0.0"
        )]
    public class PluginClass : AbstractPlugin
    {
        [Config(section = "GlobalOccultCoalition")]
        public static PluginConfig Config;

        public override void Load()
        {
            SynapseController.Server.RoleManager.RegisterCustomRole<GOCScript>();
            new EventHandlers();
        }
    }
}
