using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_NET01_1.Enums;

namespace Task_NET01_1
{
    class TrainingLesson : Entity, IVersionable, ICloneable
    {
        public Material[] Materials { get; set; }
        public sbyte[] Varsion { get; set; }

        public override object Clone()
        {
            Material[] Materials = new Material[this.Materials.Length];
            Materials = this.Materials.Select(x => (Material)x.Clone()).ToArray();

            return new TrainingLesson() {
                Materials = Materials,
                Descript = this.Descript,
                Varsion = this.Varsion           
            };
        }

        public LessonType GetTypeLesson()
        {
            if (Array.Exists(Materials, x => x is VideoMaterial))
            {
                return LessonType.VideoLesson;
            }
              
            return LessonType.TextLesson;
        }
    }
}
