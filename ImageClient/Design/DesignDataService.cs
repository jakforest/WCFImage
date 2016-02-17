using System;
using ImageClient.Interfaces;
using ImageDataLibrary.Models;

namespace ImageClient.Design
{
    public class DesignDataService : IDataService
    {
        public bool CreateImage(FullImage _image)
        {
            return true;
        }

        public void GetImage(Guid imageId, Action<FullImage, Exception> callback)
        {
            callback(null, null);
        }

        public void GetImageList(Action<ImageItem[], Exception> callback)
        {
            var items = new ImageItem[1] { new ImageItem { _id = Guid.NewGuid(), _imageName = "test image" } };
            callback(items, null);
        }

        public bool UpdateImage(FullImage image)
        {
            return true;
        }
    }
}