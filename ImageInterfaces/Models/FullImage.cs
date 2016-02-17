using System.Runtime.Serialization;

namespace ImageDataLibrary.Models
{
    /// <summary>
    /// Full image. Contains full image and thumbnail
    /// </summary>
    [DataContract]
    public class FullImage : ImageCommon
    {
        [DataMember]
        public byte[] FullImageData
        {
            get { return _imageData; }
            set { _imageData = value; }
        }
    }

}
