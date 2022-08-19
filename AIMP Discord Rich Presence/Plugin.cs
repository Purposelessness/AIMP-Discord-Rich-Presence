using System;
using System.Drawing;
using AIMP;
using AIMP.SDK;
using AIMP.SDK.AlbumArt;
using AIMP.SDK.MenuManager;
using AIMP.SDK.MenuManager.Objects;
using AIMP.SDK.MessageDispatcher;

namespace AIMP_Discord_Rich_Presence
{
    [AimpPlugin("Discord Rich Presence", "Purposelessness", "1.00",
        AimpPluginType = AimpPluginType.Addons, Description = "Displaying the playing track in the discord profile")]
    public class Plugin : AimpPlugin
    {
        private TrackInfoForm _trackInfoForm;
        private MessageHook _hook;

        public override void Initialize()
        {
            var aimpActionResult = Player.Core.CreateObject<IAimpMenuItem>();
            if (aimpActionResult.ResultType == ActionResultType.OK)
            {
                if (aimpActionResult.Result is IAimpMenuItem result)
                {
                    result.Name = "Open current track info form";
                    result.Id = "track_info_form";
                    result.Style = MenuItemStyle.Normal;
                    result.OnExecute += ShowTrackInfoForm;
                    Player.ServiceMenuManager.Add(ParentMenuType.CommonUtilities, result);
                }
            }

            _trackInfoForm = new TrackInfoForm();
            Debug.Instance.OnLogInvoked += (sender, s) => { _trackInfoForm.SetDebugString(s); };
            _hook = new MessageHook();
            Player.ServiceMessageDispatcher.Hook(_hook);
            _hook.OnCoreMessage += (message, param1, param2) =>
            {
                switch (message)
                {
                    case AimpCoreMessageType.EventStreamStart:
                        UpdateTrackInfo();
                        Debug.Instance.Log("[AimpCoreMessageType]: EventStreamStart");
                        break;
                }

                return ActionResultType.OK;
            };
        }

        private async void UpdateTrackInfo()
        {
            var fileInfo = Player.ServicePlayer.CurrentFileInfo;
            if (fileInfo == null)
            {
                _trackInfoForm.SetTrackInfo(new TrackInfo("none", "none", "none", "none"));
                return;
            }

            _trackInfoForm.SetTrackInfo(new TrackInfo(fileInfo));
            var albumCoverFromFile = fileInfo.AlbumArt;
            if (albumCoverFromFile != null)
            {
                _trackInfoForm.SetTrackCover(albumCoverFromFile);
                return;
            }

            var albumCover = await AimpAlbumCoverProvider.GetAlbumCoverAsync(Player);
            if (albumCover != null)
                _trackInfoForm.SetTrackCover(albumCover);
        }

        private void ShowTrackInfoForm(object sender, EventArgs eventArgs)
        {
            if (_trackInfoForm.IsDisposed)
            {
                _trackInfoForm = new TrackInfoForm();
                UpdateTrackInfo();
            }

            _trackInfoForm?.Show();
        }

        public override void Dispose()
        {
            _trackInfoForm.Dispose(false);
            Player.ServiceMessageDispatcher.Unhook(_hook);
        }
    }
}