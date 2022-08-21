using System;
using AIMP.SDK;
using AIMP.SDK.MenuManager;
using AIMP.SDK.MenuManager.Objects;

namespace AIMP_Discord_Rich_Presence.Aimp.TrackInfoPresenter
{
    public class TrackInfoPresenterController : IDisposable
    {
        private TrackInfoPresenterView _view;
        private readonly TrackInfoProvider _provider;

        public TrackInfoPresenterController(IAimpPlayer player, TrackInfoProvider provider)
        {
            _provider = provider;
            
            _view = new TrackInfoPresenterView();
            Debug.Instance.OnLogInvoked += (sender, s) => { _view.SetDebugString(s); };

            _provider.OnInfoUpdated += OnTrackInfoUpdated;
            _provider.OnCoverUpdated += OnTrackCoverUpdated;
            
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
                _view.SetTrackInfo(_provider.Info);
            }
            
            _view.Show();
        }

        private void OnTrackInfoUpdated(object o, EventArgs args)
        {
            _view.SetTrackInfo(_provider.Info);
        }

        private void OnTrackCoverUpdated(object o, EventArgs args)
        {
            _view.SetTrackCover(_provider.Info.AlbumCover);
        }
        
        public void Dispose()
        {
            _provider.OnInfoUpdated -= OnTrackInfoUpdated;
            _provider.OnCoverUpdated -= OnTrackCoverUpdated;
            _view.Dispose();
        }
    }
}