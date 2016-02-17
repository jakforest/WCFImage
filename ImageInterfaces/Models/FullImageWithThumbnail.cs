using System.Runtime.Serialization;
using ImageDataLibrary.Helper;

namespace ImageDataLibrary.Models
{
    public class FullImageWithThumbnail : FullImage
    {
        private byte[] _thumbnail;

        public FullImageWithThumbnail(FullImage image)
        {
            Id = image.Id;
            ImageName = image.ImageName;
            FullImageData = image.FullImageData;
            Thumbnail = image.FullImageData.GetThumbnail(75, 75);
        }

        [DataMember]
        public byte[] Thumbnail
        {
            get { return _thumbnail; }
            set { _thumbnail = value; }
        }
    }
}
