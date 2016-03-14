using System;

namespace TestMoq
{
    public class Transport : ITransport
    {
        private string connString = string.Empty;
        private string context = string.Empty;
        public Transport(string connString)
        {
            this.connString = connString;
        }

        public string Connect()
        {
            return "ok";
        }

        public void Context(string context)
        {
            this.context = context;
        }
    }
}