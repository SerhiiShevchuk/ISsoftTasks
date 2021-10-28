namespace SensorLibrary
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
