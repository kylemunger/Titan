using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Titan.Core.Exceptions
{
    /// <summary>
    /// Represents errors that occur during OpenAI API operations.
    /// </summary>
    internal class OpenAiApiException : Exception
    {
        /// <summary>
        /// Gets or sets the HTTP status code associated with this exception.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the Response Content associated with this exception.
        /// </summary>
        public string ResponseContent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAiApiException"/> class with a specified error message, status code and content of the API response.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        /// <param name="statusCode">The HTTP Status Code of the API response.</param>
        /// <param name="responseContent">The content of the API response.</param>
        public OpenAiApiException(string message, HttpStatusCode statusCode, string responseContent)
            : base(message)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }
    }
}
