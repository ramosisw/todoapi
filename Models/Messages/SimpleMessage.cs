
namespace TodoAPI.Models.Messages
{
    /// <summary>
    /// Response with a simple messae like
    /// <pre>
    /// {
    ///     "code": 200,
    ///     "message": "Success"
    /// }
    /// </pre>
    /// </summary>
    public class SimpleMessage
    {
        /// <summary>
        /// Code of message
        /// </summary>
        /// <value>200</value>
        public int Code { get; set; }

        /// <summary>
        /// Message description
        /// </summary>
        /// <value>Success</value>
        public string Message { get; set; }
    }
}