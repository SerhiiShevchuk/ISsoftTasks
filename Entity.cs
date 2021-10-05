using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Task_NET01_1
{
    public abstract class Entity : ICloneable
    {
        public Entity()
        {
            gId = Guid.NewGuid();
        }
        public override string ToString()
        {
            return Descript;
        }
        public override bool Equals(object obj)
        {
            if (obj is Entity ent)
            {
                return ent.gId == this.gId;
            }

            return false;
        }

        public abstract object Clone();

        public Guid gId { get; set; }
        [StringLength(256, ErrorMessage = "Invalid Text length")]
        public string Descript { get; set; }
    }

    public static class EntityExtension
    {
        public static void Identyty(this Entity entity)
        {
            entity.gId = Guid.NewGuid();
        }
    }
}
