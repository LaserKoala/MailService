using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Email
{
    public class MessageService
    {
        private BlockingCollection<Message> messagesQueue = new BlockingCollection<Message>();
        private long sentMessages = 0;
        private long receivedMessages = 0;
        private Thread SendThread;


        public void Start()
        {
            SendThread = new Thread(SendMessage);
            SendThread.Start();
        }

        public bool AddMessage(Message message)
        {
            if (messagesQueue.TryAdd(message))
            {
                receivedMessages++;
                return true;
            }
            return false;
        }

        public void SendMessage()
        {
            foreach (var message in messagesQueue.GetConsumingEnumerable())
            {
                Task.Run(() =>
                {
                    sentMessages++;
                });
            }
        }

        public int ViewStoredMessages()
        {
            return messagesQueue.Count;
        }

        public long ViewReceivedMessages()
        {
            return receivedMessages;
        }

        public long ViewSentMessages()
        {
            return sentMessages;
        }
    }
}
