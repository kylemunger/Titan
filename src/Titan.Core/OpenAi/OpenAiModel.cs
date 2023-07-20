using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Core.OpenAi
{
    /// <summary>
    /// Represents the available OpenAI models.
    /// </summary>
    internal enum OpenAiModel
    {
        GPT35,
        GPT4
    }

    /// <summary>
    /// Represents a static class with extensions for the <see cref="OpenAiModel"/> enumeration.
    /// </summary>
    internal static class OpenAiModelExtensions
    {
        /// <summary>
        /// Private field containing a dictionary that maps OpenAiModel values to their string representations.
        /// </summary>
        private static Dictionary<OpenAiModel, string> _openAiModelToString = new Dictionary<OpenAiModel, string>
        {
            { OpenAiModel.GPT35, "gpt-3.5-turbo-0613" },
            { OpenAiModel.GPT4, "gpt-4-0613" },
        };

        /// <summary>
        /// Converts an OpenAiModel to its corresponding string value.
        /// </summary>
        /// <param name="model">The OpenAiModel to convert.</param>
        /// <returns>The string representation of the specified OpenAiModel.</returns>
        public static string ToString(this OpenAiModel model)
        {
            return _openAiModelToString[model];
        }
    }
}
