using AIMP;
using AIMP_Discord_Rich_Presence.Aimp;
using AIMP_Discord_Rich_Presence.Aimp.TrackInfoPresenter;
using AIMP.SDK;
using AIMP.SDK.MessageDispatcher;

namespace AIMP_Discord_Rich_Presence
{
    [AimpPlugin("Discord Rich Presence", "Purposelessness", "1.00",
        AimpPluginType = AimpPluginType.Addons, Description = "Displaying the playing track in the discord profile")]
    public class Plugin : AimpPlugin
    {
        public override void Initialize()
        {
            var trackInfoProvider = new PlayerInfoProvider(Player);
            var trackInfoPresenterController = new TrackInfoPresenterController(Player, trackInfoProvider);
        }

        public override void Dispose()
        {
        }
    }
}