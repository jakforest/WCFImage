using ImageInterfaces.Models;
using System;
using System.ServiceModel;

namespace ImageInterfaces.Interfaces
{
    [ServiceContract]
    public interface IImageService
    {

        [OperationContract]
        ImageItem[] GetImageList();

        [OperationContract]
        FullImage GetImageById(Guid imageId);

    }
}
