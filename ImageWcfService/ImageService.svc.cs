using ImageDataLibrary.Interfaces;
using ImageDataLibrary.Models;
using ImageWcfService.DataService.Interfaces;
using System;

namespace ImageWcfService
{
    public class ImageService : IImageService
    {
        public IDataService _dataService = DataService.DataService.Instance;

        public ImageItem[] GetImageList()
        {
            ImageItem[] result = _dataService.GetImages();
            return result;
        }

        public FullImage GetImageById(Guid imageId)
        {
            FullImage result = _dataService.GetImage(imageId);
            return result;
        }

        public FullImage PostImage(FullImage image)
        {
            FullImageWithThumbnail imageWT = new FullImageWithThumbnail(image);
            bool resultCreate = _dataService.CreateImage(imageWT);
            if (resultCreate)
            {
                FullImage result = _dataService.GetImage(image.Id);
                return result;
            }
            else
            {
                return null;
            }
        }

        public FullImage PutImage(FullImage image)
        {
            FullImageWithThumbnail imageWT = new FullImageWithThumbnail(image);
            bool resultUpdate = _dataService.UpdateImage(imageWT);
            FullImage result = _dataService.GetImage(image.Id);
            return result;
        }

        public bool DeleteImage(Guid id)
        {
            bool result = _dataService.DeleteImage(id);
            return result;
        }
    }
}
