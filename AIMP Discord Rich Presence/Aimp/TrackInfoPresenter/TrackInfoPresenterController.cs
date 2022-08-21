using System;
using AIMP.SDK;
using AIMP.SDK.MenuManager;
using AIMP.SDK.MenuManager.Objects;

namespace AIMP_Discord_Rich_Presence.Aimp.TrackInfoPresenter
{
    public class TrackInfoPresenterController : IDisposable
    {
        private TrackInfoPresenterView _view;
        private readonly PlayerInfoProvider _infoProvider;

        public TrackInfoPresenterController(IAimpPlayer player, PlayerInfoProvider infoProvider)
        {
            _infoProvider = infoProvider;
            
            _view = new TrackInfoPresenterView();
            Debug.Instance.OnLogInvoked += (sender, s) => { _view.SetDebugString(s); };

            _infoProvider.OnInfoUpdated += OnTrackInfoUpdated;
            _infoProvider.OnCoverUpdated += OnTrackCoverUpdated;
            _infoProvider.OnStateUpdated += OnPlayerStateUpdated;
            
            CreateMenuItem(player);
        }

        private void CreateMenuItem(IAimpPlayer player)
        {
            var aimpActionResult = player.Core.CreateObject<IAimpMenuItem>();
            if (aimpActionResult.ResultType != ActionResultType.OK ||
                !(aimpActionResult.Result is IAimpMenuItem result)) return;
            result.Name = "Open current track info form";
            result.Id = "track_info_form";
            result.Style = MenuItemStyle.Normal;
            result.OnExecute += ShowView;
            player.ServiceMenuManager.Add(ParentMenuType.CommonUtilities, result);
        }

        private void ShowView(object sender, EventArgs eventArgs)
        {
            if (_view == null || _view.IsDisposed)
            {
                _view  = new TrackInfoPresenterView();
                UpdateView();
            }
            
            _view.Show();
        }

        private void UpdateView()
        {
            _view.SetTrackInfo(_infoProvider.TrackInfo);
            _view.SetPlayerState(_infoProvider.State.ToString());
        }

        private void OnTrackInfoUpdated(object o, EventArgs args)
        {
            _view.SetTrackInfo(_infoProvider.TrackInfo);
        }

        private void OnTrackCoverUpdated(object o, EventArgs args)
        {
            _view.SetTrackCover(_infoProvider.TrackInfo.AlbumCover);
        }
        
        private void OnPlayerStateUpdated(object sender, AimpPlayerState e)
        { 
            _view.SetPlayerState(e.ToString());
        }
        
        public void Dispose()
        {
            _infoProvider.OnInfoUpdated -= OnTrackInfoUpdated;
            _infoProvider.OnCoverUpdated -= OnTrackCoverUpdated;
            _view.Dispose();
        }
    }
}