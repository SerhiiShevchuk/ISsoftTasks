using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_NET01_1.Enums;
using System.ComponentModel.DataAnnotations;

namespace Task_NET01_1
{
    class VideoMaterial : Material, IVersionable
    {
        [Required(ErrorMessage = "ContentURL is empty", AllowEmptyStrings = false)]
        public string VideoURL { get; set; }
        public string ImagURL { get; set; }
        public sbyte[] Varsion { get; set; }
        public VideoFormat Format { get; set; }

        public override object Clone()
        {
            return new VideoMaterial() {
                Descript = this.Descript, 
                Format = this.Format, 
                ImagURL = this.ImagURL, 
                VideoURL = this.VideoURL,
                Varsion = this.Varsion 
            };
        }
    }
}