using System;
using TestMoq;

namespace TestMoqTests
{
    internal class FakeTransport : ITransport
    {
        string result = string.Empty;
        public FakeTransport(string result)
        {
            this.result = result;
        }

        public string Connect()
        {
            return result;
        }

        public void Context(string context)
        {
            throw new NotImplementedException();
        }
    }
}