using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using AIMP.SDK;
using AIMP.SDK.AlbumArt;

namespace AIMP_Discord_Rich_Presence
{
    public class AimpAlbumCoverProvider
    {
        private static readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        public static Bitmap GetAlbumCover(IAimpPlayer player)
        {
            Bitmap result = null;
            _autoResetEvent.Set();
            player.ServiceAlbumArt.Completed += (sender, args) =>
            {
                result = args.CoverImage;
                _autoResetEvent.Set();
            };
            player.ServiceAlbumArt.Get2(player.ServicePlayer.CurrentFileInfo, AimpFindCovertArtType.None, null);
            _autoResetEvent.WaitOne(TimeSpan.FromSeconds(20));
            return result;
        }

        public static Task<Bitmap> GetAlbumCoverAsync(IAimpPlayer player)
        {
            return Task.FromResult(GetAlbumCover(player));
        }
    }
}