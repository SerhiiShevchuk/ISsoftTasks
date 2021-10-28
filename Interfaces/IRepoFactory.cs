namespace SensorLibrary
{
    interface IRepoFactory
    {
        public IRepository CreateRepository(RepoType type);
    }
}
