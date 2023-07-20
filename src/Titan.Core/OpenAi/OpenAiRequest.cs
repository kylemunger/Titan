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
    internal class OpenAiRequest : IOpenAiRequest
    {
        /// <inheritdoc/>
        public OpenAiModel Model { get; }

        /// <inheritdoc/>
        public JObject GetRequest()
        {
            return new JObject();
        }
    }
}
