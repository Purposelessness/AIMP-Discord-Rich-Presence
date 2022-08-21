using System;
using AIMP.SDK;
using AIMP.SDK.MessageDispatcher;

namespace AIMP_Discord_Rich_Presence.Aimp
{
    public class TrackInfoProvider : IDisposable
    {
        private readonly IAimpPlayer _player;
        private readonly MessageHook _hook;
        
        private TrackInfo _currentTrackInfo;

        public TrackInfo Info => _currentTrackInfo;

        public EventHandler OnInfoUpdated;
        public EventHandler OnCoverUpdated;

        public TrackInfoProvider(IAimpPlayer player)
        {
            _player = player;
            _currentTrackInfo = new TrackInfo();
            UpdateTrackInfo();

            _hook = new MessageHook();
            _hook.OnCoreMessage += (message, param1, param2) =>
            {
                switch (message)
                {
                    case AimpCoreMessageType.EventStreamStart:
                        UpdateTrackInfo();
                        break;
                }

                return ActionResultType.OK;
            };
            _player.ServiceMessageDispatcher.Hook(_hook);
        }

        private void UpdateTrackInfo()
        {
            var fileInfo = _player.ServicePlayer.CurrentFileInfo;
            if (fileInfo == null)
            {
                _currentTrackInfo.IsPlaying = false;
                Log("There is no file in player.");
                return;
            }

            Log($"Album cover is null? {fileInfo.AlbumArt == null}");
            
            _currentTrackInfo.Set(fileInfo);
            Log($"File updated: " +
                $"{nameof(_currentTrackInfo.Title)} — {_currentTrackInfo.Title}, " +
                $"{nameof(_currentTrackInfo.Album)} — {_currentTrackInfo.Album}, " +
                $"{nameof(_currentTrackInfo.Artist)} — {_currentTrackInfo.Artist}");
            if (_currentTrackInfo.IsAlbumCoverNull())
            {
                UpdateCoverViaProvider();
            }
            
            OnInfoUpdated?.Invoke(this, null);
        }

        private async void UpdateCoverViaProvider()
        {
            var albumCover = await AlbumCoverProvider.GetAlbumCoverAsync(_player);
            Log($"Album cover got from provider ({albumCover == null})");
            _currentTrackInfo.SetCover(albumCover);
            OnCoverUpdated?.Invoke(this, null);
            Log($"Cover loaded using {nameof(AlbumCoverProvider)}");
        }

        private static void Log(string message)
        {
            Debug.Instance.Log("[TrackInfoProvider]: " + message);
        }

        public void Dispose()
        {
            _player.ServiceMessageDispatcher.Unhook(_hook);
        }
    }
}