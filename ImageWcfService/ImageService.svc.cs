using ImageInterfaces.Interfaces;
using ImageInterfaces.Models;
using System;

namespace ImageWcfService
{
    public class ImageService : IImageService
    {
        public ImageItem[] GetImageList()
        {
            throw new NotImplementedException();
        }

        public FullImage GetImageById(Guid imageId)
        {
            throw new NotImplementedException();
        }

    }
}
