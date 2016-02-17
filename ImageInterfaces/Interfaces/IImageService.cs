using ImageDataLibrary.Models;
using System;
using System.ServiceModel;

namespace ImageDataLibrary.Interfaces
{
    [ServiceContract]
    public interface IImageService
    {

        [OperationContract]
        ImageItem[] GetImageList();

        [OperationContract]
        FullImage GetImageById(Guid imageId);

        [OperationContract]
        FullImage PostImage(FullImage image);

        [OperationContract]
        FullImage PutImage(FullImage image);

        [OperationContract]
        bool DeleteImage(Guid id);

    }
}
