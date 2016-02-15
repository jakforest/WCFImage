using System.Runtime.Serialization;

namespace ImageInterfaces.Models
{
    /// <summary>
    /// Full image. Contains full image
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
