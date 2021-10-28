using System;

namespace SensorLibrary
{
    class IdGenerator
    {
        private static IdGenerator _instance;
        private IdGenerator() { }

        public static IdGenerator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new IdGenerator();
            }

            return _instance;
        }
        public static Guid GenerateId()
        {
            return Guid.NewGuid();
        }
    }
}
