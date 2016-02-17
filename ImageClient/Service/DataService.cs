using ImageClient.Interfaces;
using ImageDataLibrary.Models;
using System;

namespace ImageClient.Service
{
    public class DataService : IDataService
    {
        public void GetImage(Guid imageId, Action<FullImage, Exception> callback)
        {
            try
            {
                using (ImageServiceClient client = new ImageServiceClient())
                {
                    var item = client.GetImageById(imageId);
                    callback(item, null);
                }
            }
            catch (Exception ex)
            {
                callback(null, ex);
            }
        }

        public void GetImageList(Action<ImageItem[], Exception> callback)
        {
            try
            {
                //using (ImageServiceClient client = new ImageServiceClient())
                {
                    //var items = client.GetImageList();
                    var items = new ImageItem[1] { new ImageItem { _id = Guid.NewGuid(), _imageName = "test image" } };

                    callback(items, null);
                }
            }
            catch (Exception ex)
            {
                callback(null, ex);
            }
        }
    }
}
