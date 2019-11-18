using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Job.ReportGenerator
{
    public class ReportGeneratorListener
    {
        public static async Task GenerateReportAsync(Message message, CancellationToken cancellationToken)
        {
            //Parse the report id from the message:
            var reportId = Encoding.UTF8.GetString(message.Body);

            Console.WriteLine($"Generating report {reportId}...");
            //(Actual report generation code omitted)
            //.....
        }
    }
}
