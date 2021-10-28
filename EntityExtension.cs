using System;

namespace Task_NET01_1
{
    public static class EntityExtension
    {
        public static void Identyty(this Entity entity)
        {
            entity.Guid = Guid.NewGuid();
        }
    }
}
