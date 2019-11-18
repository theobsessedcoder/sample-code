using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;

namespace Api.Application.Controllers
{
    [Route("reports")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IQueueClient _queueClient;
        private readonly ITopicClient _topicClient;

        public ReportingController(IQueueClient queueClient, ITopicClient topicClient)
        {
            _queueClient = queueClient;
            _topicClient = topicClient;
        }

        /// <summary>
        /// Kick-off report generation for the specified report
        /// (one-to-one example)
        /// </summary>
        /// <param name="id">The id of the report to generate</param>
        [Route("")]
        [HttpPost]
        public async Task<StatusCodeResult> InitiateReportGeneration([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(400);
            }

            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(id));
            await _queueClient.SendAsync(serviceBusMessage);
            return StatusCode(204);
        }

        /// <summary>
        ///  Kick-off report generation for the specified report
        /// (one-to-many example)
        /// </summary>
        /// <param name="id">The id of the report to generate</param>
        [Route("topic")]
        [HttpPost]
        public async Task<StatusCodeResult> InitiateReportGenerationToTopic([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(400);
            }

            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(id));
            await _topicClient.SendAsync(serviceBusMessage);
            return StatusCode(204);
        }
    }
}
