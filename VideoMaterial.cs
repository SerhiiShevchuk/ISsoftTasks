using System;
using Task_NET01_1.Enums;

namespace Task_NET01_1
{
    class VideoMaterial : Material, IVersionable
    {
        public VideoMaterial(string videoURL, VideoFormat format, sbyte[] version = null, string imageURL = null, string descript = null )
            : base(descript)
        {
            VideoURL = videoURL;
            ImagURL = imageURL;
            Version = version;
            Format = format;
        }
        public override object Clone()
        {
            return new VideoMaterial(this.VideoURL, this.Format)
            {
                Guid = this.Guid,
                ImagURL = this.ImagURL,
                Descript = this.Descript,
                Version = (sbyte[])this.Version.Clone()
            };
        }

        private string _videoURL;
        public string VideoURL {
            get
            {
                return _videoURL;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new Exception("VideoURL can't be null or empty");
                }
                _videoURL = value;
            }
        }
        private sbyte[] _version;
        public sbyte[] Version
        {
            get
            {
                return _version;
            }
            set
            {
                const int SIZE = 8;
                if (value != null && value.Length != SIZE)
                {
                    throw new Exception($"version size can't differ {SIZE}");
                }

                _version = value;
            }
        }
        public string ImagURL { get; set; }
        public VideoFormat Format { get; set; }
    }
}