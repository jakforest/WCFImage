using System.Runtime.Serialization;

namespace ImageInterfaces.Models
{
    /// <summary>
    /// Class for list of images. Contains thumbnail of image
    /// </summary>
    [DataContract]
    public class ImageItem : ImageCommon
    {
        [DataMember]
        public byte[] ThumbPreview
        {
            get { return _imageData; }
            set { _imageData = value; }
        }
    }
}
