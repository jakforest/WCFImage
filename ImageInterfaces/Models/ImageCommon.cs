using System;
using System.Runtime.Serialization;

namespace ImageDataLibrary.Models
{
    /// <summary>
    /// Common class for FUllImage and ImageItem. Made abstract to prevent creatrion of this class in mistake
    /// </summary>
    [Serializable]
    public abstract class ImageCommon
    {
        private string _imageName = "image";
        [DataMember]
        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        private Guid _id = Guid.NewGuid();
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        protected byte[] _imageData;

    }
}
