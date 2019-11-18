using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Job.ReportGenerator
{
    public class ServiceBusMessageErrorHandler
    {
        public static Task HandleException(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            //Note: in practice, we'd likely log this information to application monitoring software
            //rather than simply print it out
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            Console.WriteLine($"Exception message {exceptionReceivedEventArgs.Exception.Message}");
            Console.WriteLine($"Stack trace: {exceptionReceivedEventArgs.Exception.StackTrace}");

            return Task.CompletedTask;
        }
    }
}
