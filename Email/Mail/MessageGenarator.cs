using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Email
{
    public class MessageGenarator
    {
        private Thread generatingThread;
        private MessageService service;

        public MessageGenarator(MessageService receivingService)
        {
            this.service = receivingService;
        }

        public void Start()
        {
            generatingThread = new Thread(GenerateMessages);
            generatingThread.Start();
        }


        public void GenerateMessages()
        {
            while (true)
            {
                Task.Run(() =>
                {
                    service.AddMessage(new Message());
                });
                Thread.Sleep(100);
            }
        }
    }
}
