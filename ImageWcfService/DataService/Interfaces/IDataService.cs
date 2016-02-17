using ImageDataLibrary.Models;
using System;

namespace ImageWcfService.DataService.Interfaces
{
    public interface IDataService
    {
        ImageItem[] GetImages();
        FullImage GetImage(Guid imageId);
        bool CreateImage(FullImageWithThumbnail image);
        bool UpdateImage(FullImageWithThumbnail image);
        bool DeleteImage(Guid imageId);
    }
}
