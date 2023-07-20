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
        /// Defines a method to get the request information in JSON format for OpenAi.
        /// </summary>
        /// <returns>A JObject that represents the JSON format of the request information for OpenAi.</returns>
        JObject GetRequest();
    }
}
