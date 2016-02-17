using ImageDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageClient.Interfaces
{
    public interface IDataService
    {
        void GetImage(Guid imageId, Action<FullImage, Exception> callback);
        void GetImageList(Action<ImageItem[], Exception> callback);
        bool CreateImage(FullImage image);
        bool UpdateImage(FullImage image);
    }
}
