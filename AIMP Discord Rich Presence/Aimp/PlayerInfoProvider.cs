using System;
using AIMP.SDK;
using AIMP.SDK.MessageDispatcher;

namespace AIMP_Discord_Rich_Presence.Aimp
{
    public class PlayerInfoProvider : IDisposable
    {
        private readonly IAimpPlayer _player;
        private readonly MessageHook _hook;

        private TrackInfo _currentTrackTrackInfo;

        public TrackInfo TrackInfo => _currentTrackTrackInfo;
        public AimpPlayerState State { get; private set; }
        public double Position { get; private set; }

        public EventHandler OnInfoChanged;
        public EventHandler OnCoverChanged;
        public EventHandler<AimpPlayerState> OnStateChanged;
        public EventHandler<double> OnPositionChanged;

        public PlayerInfoProvider(IAimpPlayer player)
        {
            _player = player;
            _currentTrackTrackInfo = new TrackInfo();
            UpdateTrackInfo();

            _hook = new MessageHook();
            _hook.OnCoreMessage += OnCoreMessage;
            _player.ServiceMessageDispatcher.Hook(_hook);
        }

        private ActionResultType OnCoreMessage(AimpCoreMessageType message, int param1, IntPtr param2)
        {
            switch (message)
            {
                case AimpCoreMessageType.EventPlayerState:
                    OnPlayerStateChanged(param1);
                    break;
                case AimpCoreMessageType.EventPlayerUpdatePosition:
                    Position = _player.ServicePlayer.Position;
                    OnPositionChanged?.Invoke(this, Position);
                    break;
                case AimpCoreMessageType.EventPlayingFileInfo:
                    UpdateTrackInfo();
                    break;
            }

            return ActionResultType.OK;
        }

        private void OnPlayerStateChanged(int param1)
        {
            switch (param1)
            {
                case 0:
                    State = AimpPlayerState.Stopped;
                    OnStateChanged?.Invoke(this, AimpPlayerState.Stopped);
                    Log("Player is stopped");
                    break;
                case 1:
                    State = AimpPlayerState.Pause;
                    OnStateChanged?.Invoke(this, AimpPlayerState.Pause);
                    Log("Player is paused");
                    break;
                case 2:
                    State = AimpPlayerState.Playing;
                    OnStateChanged?.Invoke(this, AimpPlayerState.Playing);
                    Log("Player is playing");
                    break;
            }
        }

        private void UpdateTrackInfo()
        {
            var fileInfo = _player.ServicePlayer.CurrentFileInfo;
            if (fileInfo == null)
            {
                Log("There is no file in player.");
                return;
            }

            if (fileInfo.Duration == 0)
                fileInfo.Duration = _player.ServicePlayer.Duration;

            _currentTrackTrackInfo.Set(fileInfo);
            Log($"File updated: " +
                $"{nameof(_currentTrackTrackInfo.Title)} — {_currentTrackTrackInfo.Title}, " +
                $"{nameof(_currentTrackTrackInfo.Album)} — {_currentTrackTrackInfo.Album}, " +
                $"{nameof(_currentTrackTrackInfo.Artist)} — {_currentTrackTrackInfo.Artist}");
            if (_currentTrackTrackInfo.IsAlbumCoverNull())
            {
                UpdateCoverViaProvider();
            }

            OnInfoChanged?.Invoke(this, null);
        }

        private async void UpdateCoverViaProvider()
        {
            var previousCover = _currentTrackTrackInfo.AlbumCover;
            var albumCover = await AlbumCoverProvider.GetAlbumCoverAsync(_player);
            _currentTrackTrackInfo.SetCover(albumCover);
            if (previousCover != albumCover)
                OnCoverChanged?.Invoke(this, null);
            Log($"Cover loaded using {nameof(AlbumCoverProvider)}");
        }

        private static void Log(string message)
        {
            Debug.Instance.Log("[PlayerInfoProvider] " + message);
        }

        public void Dispose()
        {
            _player.ServiceMessageDispatcher.Unhook(_hook);
        }
    }
}