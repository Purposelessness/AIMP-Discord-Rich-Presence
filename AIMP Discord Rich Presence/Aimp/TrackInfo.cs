using System.Drawing;
using AIMP.SDK.FileManager.Objects;

namespace AIMP_Discord_Rich_Presence.Aimp
{
    public struct TrackInfo
    {
        public TrackInfo(IAimpFileInfo fileInfo) : this(fileInfo.Title, fileInfo.Album, fileInfo.Artist, fileInfo.FileName, fileInfo.AlbumArt)
        {
        }

        public TrackInfo(string title, string album, string artist, string fileName, Image albumCover)
        {
            Title = title;
            Album = album;
            Artist = artist;
            FileName = fileName;
            AlbumCover = albumCover;
            IsPlaying = true;
        }

        public void Set(IAimpFileInfo fileInfo)
        {
            Set(fileInfo.Title, fileInfo.Album, fileInfo.Artist, fileInfo.FileName, fileInfo.AlbumArt);
        }

        public void Set(string title, string album, string artist, string fileName, Image albumCover)
        {
            Title = title;
            Album = album;
            Artist = artist;
            FileName = fileName;
            SetCover(albumCover);
            IsPlaying = true;
        }

        public void SetCover(Image albumCover)
        {
            AlbumCover = albumCover;
        }

        public bool IsAlbumCoverNull() => AlbumCover == null;
        
        public bool IsPlaying { get; set; }
        public string Title { get; private set; }
        public string Album { get; private set; }
        public string Artist { get; private set; }
        public string FileName { get; private set; }
        public Image AlbumCover { get; private set; }
    }
}