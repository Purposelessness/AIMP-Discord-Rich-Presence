using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using AIMP.SDK;
using AIMP.SDK.AlbumArt;

namespace AIMP_Discord_Rich_Presence.Aimp
{
    public class AlbumCoverProvider
    {
        private static readonly AutoResetEvent AutoResetEvent = new AutoResetEvent(false);

        public static Bitmap GetAlbumCover(IAimpPlayer player)
        {
            Bitmap result = null;
            AutoResetEvent.Set();

            player.ServiceAlbumArt.Completed += Handler;
            player.ServiceAlbumArt.Get2(player.ServicePlayer.CurrentFileInfo, AimpFindCovertArtType.None, null);
            AutoResetEvent.WaitOne(TimeSpan.FromSeconds(20));
            player.ServiceAlbumArt.Completed -= Handler;
            
            Debug.Instance.Log($"[AlbumCoverProvider]: Returning cover ({result == null}).");
            
            return result;
            
            void Handler(object sender, AimpGetAlbumArtEventArgs args)
            {
                result = args.CoverImage;
                AutoResetEvent.Set();
            }
        }

        public static Task<Bitmap> GetAlbumCoverAsync(IAimpPlayer player)
        {
            return Task.FromResult(GetAlbumCover(player));
        }
    }
}