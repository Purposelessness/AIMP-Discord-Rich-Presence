using System;
using AIMP.SDK.FileManager.Objects;

namespace AIMP_Discord_Rich_Presence
{
    public struct TrackInfo
    {
        public TrackInfo(IAimpFileInfo fileInfo) : this(fileInfo.Title, fileInfo.Album, fileInfo.Artist, fileInfo.FileName)
        {
        }

        public TrackInfo(string title, string album, string artist, string fileName)
        {
            Title = title;
            Album = album;
            Artist = artist;
            FileName = fileName;
        }

        public string Title { get; }
        public string Album { get; }
        public string Artist { get; }
        public string FileName { get; }
    }
}