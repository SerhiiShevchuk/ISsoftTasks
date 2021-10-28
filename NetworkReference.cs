using System;
using Task_NET01_1.Enums;

namespace Task_NET01_1
{
    class NetworkReference : Material
    {
        public NetworkReference(string contentURL, ReferenceType type,  string descript = null) : base(descript)
        {
            ContentURL = contentURL;
            Type = type;
        }
        public override object Clone()
        {
            return new NetworkReference(this.ContentURL, this.Type, this.Descript)
            {
                Guid = this.Guid,
            };
        }
        
        private string _contentURL;
        public string ContentURL
        {
            get
            {
                return _contentURL;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new Exception("ContentURL is empty or null");
                }
                _contentURL = value;
            }
        }
        public ReferenceType Type { get; set; }
    }
}
