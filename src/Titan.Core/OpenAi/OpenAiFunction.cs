using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titan.Core.OpenAi
{
    /// <summary>
    /// Represents a function that can be executed by agents.
    /// Contains metadata necessary for OpenAi request and the ability to invoke the function.
    /// </summary>
    public class OpenAiFunction
    {
        /// <summary>
        /// Gets or sets the name of the OpenAI function.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the OpenAI function, providing instruction on its intended use.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parameters of the OpenAI function.
        /// </summary>
        public List<OpenAiParameter> Parameters { get; set; }

        /// <summary>
        /// Parameterized constructor for the OpenAiFunction class.
        /// </summary>
        /// <param name="name">The name of the OpenAI function.</param>
        /// <param name="description">A description of the OpenAI function.</param>
        /// <param name="parameters">The parameters of the OpenAI function.</param>
        /// <param name="functionAction">A delegate pointing to the C# implementation of the OpenAI function.</param>
        public OpenAiFunction(string name, string description, List<OpenAiParameter> parameters)
        {
            Name = name;
            Description = description;
            Parameters = parameters;
        }

        /// <summary>
        /// Serializes this OpenAiFunction object for use in OpenAi requests to JSON format.
        /// </summary>
        /// <returns>A JSON object representing this OpenAiFunction.</returns>
        public JObject ToJson()
        {
            throw new NotImplementedException();
        }
    }
}
