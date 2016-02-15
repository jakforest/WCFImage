using System;
using System.Runtime.Serialization;

namespace ImageInterfaces.Models
{
    /// <summary>
    ///this is base class fro image data. Made as abstract only for preventing instantiate as object 
    /// </summary>
    public abstract class ImageCommon
    {
        private string _imageName = "image";
        private Guid _id = Guid.NewGuid();
        protected byte[] _imageData;

        [DataMember]
        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
