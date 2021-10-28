using System;

namespace SensorLibrary
{
    class RepoFactory : IRepoFactory
    {
        public IRepository CreateRepository(RepoType type)
        {
            switch (type)
            {
                case RepoType.JSON:
                    return new JsonRepo();
                case RepoType.XML:
                    return new XmlRepo();
                default:
                    throw new Exception("Repository type is invalid");
            }
        }
    }
}
