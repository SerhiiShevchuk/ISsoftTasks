using System;

namespace Task_NET01_1
{
    public abstract class Entity : ICloneable
    {
        public Entity(string descript)
        {
            Descript = descript;
            _guid = Guid.NewGuid();
        }
        public override string ToString()
        {
            return Descript;
        }
        public override bool Equals(object obj)
        {
            if (obj is Entity ent)
            {
                return ent.Guid == this.Guid;
            }

            return false;
        }
        public abstract object Clone();

        private string _discript;
        public string Descript
        {
            get
            {
                return _discript;
            }
            set
            {
                if (256 < value?.Length)
                {
                    throw new Exception();
                }
                _discript = value;
            }
        }
        private Guid _guid;
        public Guid Guid { get; set; }
    }
}
