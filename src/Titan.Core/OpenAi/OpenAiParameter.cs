using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Titan.Core.OpenAi
{
    /// <summary>
    /// OpenAiParameterType enumeration defines the types that OpenAI function parameters can possess.
    /// </summary>
    public enum OpenAiParameterType
    {
        String,
        Integer,
        Number,  // This aligns C# double with JSON Schema's number and OpenAPI's number
        Boolean,
        // Further types can be added here as required
    }

    /// <summary>
    /// Represents a parameter for a function that can be called by OpenAI.
    /// Contains metadata necessary for OpenAI request and the ability to invoke the function.
    /// </summary>
    public class OpenAiParameter
    {
        /// <summary>
        /// Gets or sets the name of the OpenAI function parameter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the OpenAI function parameter, providing instruction on its intended use.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of OpenAiParameterType used by this OpenAI function parameter.
        /// </summary>
        public OpenAiParameterType Type { get; set; }

        /// <summary>
        /// An optional predetermined list of acceptable values for the OpenAI function parameter.
        /// </summary>
        public object[] Enum { get; set; } // 'enum' is a reserved keyword in C#, hence 'Enum' keyword is used.

        /// <summary>
        /// Parameterized constructor for the OpenAiParameter class.
        /// </summary>
        /// <param name="name">The name of the OpenAI function parameter.</param>
        /// <param name="description">The description of the OpenAI function parameter.</param>
        /// <param name="type">The type of OpenAiParameterType used by this OpenAI function parameter.</param>
        /// <param name="typeValues">An optional predetermined list of acceptable values for the OpenAI function parameter.</param>
        public OpenAiParameter(string name, string description, OpenAiParameterType type, object[] typeValues = null)
        {
            Name = name;
            Description = description;
            Type = type;
            Enum = typeValues;
        }

        /// <summary>
        /// Serializes this OpenAiParameter object for use in OpenAI requests to JSON format.
        /// </summary>
        /// <returns>A JSON string representing this OpenAiParameter.</returns>
        public string ToJson()
        {
            var parameterDescription = new
            {
                type = Type.ToString().ToLowerInvariant(),
                description = Description,
                @enum = Enum
            };

            return JsonConvert.SerializeObject(parameterDescription);
        }
    }
}
