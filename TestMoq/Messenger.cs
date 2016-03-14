using System;

namespace TestMoq
{
    public class Messenger
    {
        private ITransport transport;

        public Messenger(ITransport transport)
        {
            this.transport = transport;
        }

        public string Send(string textMsg)
        {            
            return transport.Connect();
        }
    }
}