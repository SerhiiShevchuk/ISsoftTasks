using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Task_NET01_1
{
    class TextMaterial : Material
    {
        [Required(ErrorMessage = "Text is empty", AllowEmptyStrings = false)]
        [StringLength(10000, ErrorMessage = "Invalid Text length ")]
        public string Text { get; set; }

        public override object Clone()
        {
            return new TextMaterial() {
                Descript = this.Descript, 
                Text = this.Text 
            };
        }
    }
}
