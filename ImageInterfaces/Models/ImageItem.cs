using System;
using System.Runtime.Serialization;

namespace ImageDataLibrary.Models
{
    /// <summary>
    /// Class for list of images. Contains thumbnail of image
    /// </summary>
    [DataContract]
    public class ImageItem:ImageCommon
    {
        [DataMember]
        public byte[] Thumbnail
        {
            get { return _imageData; }
            set { _imageData = value; }
        }
    }
}
