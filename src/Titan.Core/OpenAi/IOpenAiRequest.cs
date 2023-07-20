using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Titan.Core.OpenAi
{
    /// <summary>
    /// Defines an interface for representing a request to OpenAi.
    /// </summary>
    public interface IOpenAiRequest
    {
        /// <summary>
        /// Gets the OpenAiModel enumeration value that represents the model to be used by OpenAi.
        /// </summary>
        OpenAiModel Model { get; }

        /// <summary>
        /// Creates a <see cref="JObject"/> that represents the current request and can be sent to OpenAi as part of a request.
        /// </summary>
        /// <returns>A new <see cref="JObject"/> that represents the current request.</returns>
        JObject GetRequest();
    }
}
