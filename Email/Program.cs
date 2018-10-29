using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;

namespace Email
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new MessageService();
            var generator = new MessageGenarator(service);

            service.Start();
            generator.Start();


            while(true)
            {
                var command = Console.ReadLine();

                if (command == "help")
                {
                    Console.Clear();
                    Console.WriteLine("view - view statistic \nexit - close program");
                    Console.ReadKey();
                    Console.Clear();
                }


                if (command == "view")
                {
                    while (Console.KeyAvailable == false)
                    {
                        Console.WriteLine($"Принято: {service.ViewReceivedMessages()}");
                        Console.WriteLine($"В очереди: {service.ViewStoredMessages()}");
                        Console.WriteLine($"Отправленно: {service.ViewSentMessages()}");
                        Thread.Sleep(40);
                        Console.Clear();
                    }
                    Console.ReadKey();
                }

                if (command == "exit")
                {
                    Environment.Exit(0);
                }
            }
        }

        
    }
}
