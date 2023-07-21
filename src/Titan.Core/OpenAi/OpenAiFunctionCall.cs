using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.OpenAi
{
    /// <summary>
    /// The OpenAiFunctionCall class encapsulates a function call intended for execution by an agent.
    /// It includes the functionalities to retrieve function name and its parameters.
    /// </summary>
    public class OpenAiFunctionCall
    {
        /// <summary>
        /// Initializes a new instance of the OpenAiFunctionCall class.
        /// </summary>
        /// <param name="responseFunctionContent">A JObject instance that represents the returned function from a chat API response.</param>
        public OpenAiFunctionCall(JObject responseFunctionContent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the name of the function encapsulated in this OpenAiFunctionCall instance.
        /// </summary>
        /// <returns>A string that represents the name of the function.</returns>
        public string GetFunctionName() 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the parameters of the function encapsulated in this OpenAiFunctionCall instance.
        /// </summary>
        /// <returns>An array containing the parameter values of the function.</returns>
        public object[] GetParameterObjects()
        {
            throw new NotImplementedException();
        }
    }
}
