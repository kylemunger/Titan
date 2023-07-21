using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Titan.Core.OpenAi
{
    /// <summary>
    /// Represents a class that implements IOpenAiRequest, which contains specific information required for OpenAi requests.
    /// </summary>
    public class OpenAiRequest : IOpenAiRequest
    {
        /// <inheritdoc/>
        public OpenAiModel Model { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAiRequest"/> class using the specified model, messages and functions.
        /// </summary>
        /// <param name="model">The OpenAi model for which this request is intended.</param>
        /// <param name="messages">A list of <see cref="OpenAiMessage"/> instances that represent the messages associated with this request.</param>
        /// <param name="functions">A list of <see cref="OpenAiFunction"/> instances that represent the function calls to be reported to OpenAi with this request.</param>
        public OpenAiRequest(OpenAiModel model, List<OpenAiMessage> messages, List<OpenAiFunction> functions) 
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public JObject GetRequest()
        {
            throw new NotImplementedException();
        }
    }
}
