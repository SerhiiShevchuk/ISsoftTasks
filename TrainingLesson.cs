using System;
using System.Collections.Generic;
using System.Linq;
using Task_NET01_1.Enums;

namespace Task_NET01_1
{
    class TrainingLesson : Entity, IVersionable
    {
        public TrainingLesson(List<Material> materials = null, sbyte[] version = null, string descript = null) : base(descript)
        {
            Materials = materials;
            Version = version;
        }
        public override object Clone()
        {
            var cloneMaterials = this.Materials.Select(x => (Material)x.Clone()).ToList();

            return new TrainingLesson(cloneMaterials, (sbyte[])this.Version.Clone(), this.Descript)
            {
                Guid = this.Guid,
            };
        }

        public LessonType GetLessonType()
        {
            if (Materials.Any(x => x is VideoMaterial))
            {
                return LessonType.VideoLesson;
            }

            return LessonType.TextLesson;
        }

        public List<Material> Materials { get; set; }
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
    }
}