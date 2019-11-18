using System;
using Job.ReportGenerator.Constants;
using Microsoft.Azure.ServiceBus;

namespace Job.ReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var oneToOneQueueClient = new QueueClient(
                "<your connection string>",
                QueueNames.OneToOneQueueName);
            RegisterServiceBusListener(oneToOneQueueClient);
            Console.ReadKey();
        }

        static void RegisterServiceBusListener(IQueueClient queueClient)
        {
            // Configure the MessageHandler Options in terms of exception handling, number of concurrent messages to deliver etc.
            var messageHandlerOptions = new MessageHandlerOptions(ServiceBusMessageErrorHandler.HandleException)
            {
                // Maximum number of Concurrent calls to the callback `ProcessMessagesAsync`, set to 1 for simplicity.
                // Set it according to how many messages the application wants to process in parallel.
                MaxConcurrentCalls = 1,

                // Indicates whether MessagePump should automatically complete the messages after returning from User Callback.
                // False below indicates the Complete will be handled by the User Callback as in `ProcessMessagesAsync` below.
                AutoComplete = true
            };

            // Register the function that will process messages
            queueClient.RegisterMessageHandler(ReportGeneratorListener.GenerateReportAsync, messageHandlerOptions);
        }
    }
}
