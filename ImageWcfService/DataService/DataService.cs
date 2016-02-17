using System;
using System.Linq;
using ImageWcfService.DataService.Interfaces;
using ImageDataLibrary.Models;

namespace ImageWcfService.DataService
{
    internal class DataService : IDataService
    {
        #region singleton
        private static DataService _instance;
        private static object syncRoot = "syncRoot";

        public static IDataService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new DataService();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region Interface realization
        public bool CreateImage(FullImageWithThumbnail image)
        {
            try
            {
                using (ImagesDatabaseEntities context = new ImagesDatabaseEntities())
                {
                    Image newImage = new Image
                    {
                        Id = Guid.NewGuid()
                    };
                    UpdateImageWithNewData(newImage, image);
                    context.Images.Add(newImage);
                    bool result = context.SaveChanges() > 0;
                    return result;
                }
            }
            catch (Exception ex)
            {
                //logger
                return false;
            }
        }

        public bool DeleteImage(Guid imageId)
        {
            try
            {
                using (ImagesDatabaseEntities context = new ImagesDatabaseEntities())
                {
                    Image image = context.Images.FirstOrDefault(i => i.Id == imageId);
                    if (image != null)
                    {
                        context.Images.Remove(image);
                        bool result = context.SaveChanges() > 0;
                        return result;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                //logger
                return false;
            }
        }

        public FullImage GetImage(Guid imageId)
        {
            try
            {
                using (ImagesDatabaseEntities context = new ImagesDatabaseEntities())
                {
                    FullImage result = context.Images.Where(i => i.Id == imageId)
                        .Select(i => new FullImage { Id = i.Id, ImageName = i.ImageName, FullImageData = i.Data })
                        .FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                //logger
                return null;
            }
        }

        public ImageItem[] GetImages()
        {
            try
            {
                using (ImagesDatabaseEntities context = new ImagesDatabaseEntities())
                {
                    ImageItem[] result = context.Images
                        .Select(i => new ImageItem { Id = i.Id, ImageName = i.ImageName, Thumbnail = i.Thumbnail })
                        .ToArray();
                    return result;
                }
            }
            catch (Exception ex)
            {
                //logger
                return null;
            }
        }

        public bool UpdateImage(FullImageWithThumbnail image)
        {
            try
            {
                using (ImagesDatabaseEntities context = new ImagesDatabaseEntities())
                {
                    Image updateImage = context.Images.FirstOrDefault(i => i.Id == image.Id);
                    if (updateImage != null)
                    {
                        UpdateImageWithNewData(updateImage, image);
                        bool result = context.SaveChanges() > 0;
                        return result;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                //logger
                return false;
            }
        }
        #endregion

        #region private methods
        private void UpdateImageWithNewData(Image newImage, FullImageWithThumbnail image)
        {
            newImage.Data = image.FullImageData;
            newImage.ImageName = image.ImageName;
            newImage.Thumbnail = image.Thumbnail;
        }
        #endregion
    }
}