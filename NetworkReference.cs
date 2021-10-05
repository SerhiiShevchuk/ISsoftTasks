using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_NET01_1.Enums;
using System.ComponentModel.DataAnnotations;

namespace Task_NET01_1
{
    class NetworkReference : Material
    {
        [Required(ErrorMessage = "ContentURL is empty", AllowEmptyStrings = false)]
        public string ContentURL { get; set; }
        public ReferenceType Type { get; set; }

        public override object Clone()
        {
            return new NetworkReference() { 
                Descript = this.Descript, 
                ContentURL = this.ContentURL,
                Type = this.Type 
            };
        }
    }
}
