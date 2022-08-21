using System.Drawing;
using AIMP.SDK.FileManager.Objects;

namespace AIMP_Discord_Rich_Presence.Aimp
{
    public struct TrackInfo
    {
        public TrackInfo(IAimpFileInfo fileInfo) : this(fileInfo.Title, fileInfo.Album, fileInfo.Artist,
                                                        fileInfo.Duration, fileInfo.AlbumArt, fileInfo.FileName)
        {
        }

        public TrackInfo(string title, string album, string artist, double duration, Image albumCover, string fileName)
        {
            Title = title;
            Album = album;
            Artist = artist;
            Duration = duration;
            AlbumCover = albumCover;
            FileName = fileName;
        }

        public void Set(IAimpFileInfo fileInfo)
        {
            Set(fileInfo.Title, fileInfo.Album, fileInfo.Artist, 
                fileInfo.Duration, fileInfo.AlbumArt, fileInfo.FileName);
        }

        public void Set(string title, string album, string artist, double duration, Image albumCover, string fileName)
        {
            Title = title;
            Album = album;
            Artist = artist;
            Duration = duration;
            SetCover(albumCover);
            FileName = fileName;
        }

        public void SetCover(Image albumCover)
        {
            AlbumCover = albumCover;
        }

        public bool IsAlbumCoverNull() => AlbumCover == null;

        public string Title { get; private set; }
        public string Album { get; private set; }
        public string Artist { get; private set; }
        public Image AlbumCover { get; private set; }
        public double Duration { get; private set; }
        public string FileName { get; private set; }
    }
}