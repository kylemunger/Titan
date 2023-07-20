using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.OpenAi
{
    /// <summary>
    /// Defines interface for OpenAi interactions.
    /// </summary>
    internal interface IOpenAiWrapper
    {
        /// <summary>
        /// Asynchronously sends a message to OpenAi and retrieves the corresponding response.
        /// </summary>
        /// <param name="request">The request to send to OpenAi.</param>
        /// <returns>A task that represents the asynchronous operation. The task's result is the OpenAi response.</returns>
        Task<OpenAiResponse> SendMessageAsync(IOpenAiRequest request);
    }
}
