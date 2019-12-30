using System;

namespace ObsessedCoder.GlobalExceptionMiddleware.Models
{
    /// <summary>
    /// Information about an error that occurred when sending a request to the API
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// The error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// A string representation of the immediate frames on the call stack
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// A unique identifier so we can find this in the logs later
        /// </summary>
        public Guid? LogId { get; set; }

        public ErrorResponse()
        {
        }

        /// <summary>
        /// Creates an instance
        /// </summary>
        /// <param name="message">The message describing this error</param>
        /// <param name="stackTrace">A string representation of the immediate frames on the call stack when this error occurred</param>
        /// <param name="logId">The unique id of the log message associated with this error response</param>
        public ErrorResponse(string message, string stackTrace, Guid? logId)
        {
            Message = message;
            StackTrace = stackTrace;
            LogId = LogId;
        }

        /// <summary>
        /// Creates an instance
        /// </summary>
        /// <param name="exception">The exception that is causing this error response</param>
        /// <param name="logId">The unique id of the log message associated with this error response</param>
        public ErrorResponse(Exception exception, Guid? logId = null)
        {
            Message = exception.ToString();
            StackTrace = exception.StackTrace;
            LogId = logId;
        }
    }
}
