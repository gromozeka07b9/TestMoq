namespace TestMoq
{
    public interface ITransport
    {
        void Context(string context);
        string Connect();
    }
}