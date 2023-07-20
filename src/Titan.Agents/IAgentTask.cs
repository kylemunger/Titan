using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.OpenAi;

namespace Titan.Agents
{
    /// <summary>
    /// Represents a task that can be executed by an agent.
    /// </summary>
    public interface IAgentTask
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets a list of messages involved in the task execution.
        /// </summary>
        List<OpenAiMessage> Messages { get; set; }

        /// <summary>
        /// Determines if the last message in the <see cref="Messages"/> list is of the assistant role.
        /// If the assistant role is the issuer of the last message and it contains a function call, this method returns true.
        /// </summary>
        /// <returns><c>true</c> if the last message in the <see cref="Messages"/> list is of the assistant role; <c>false</c> otherwise.</returns>
        bool IsFunctionCall();

        /// <summary>
        /// Retrieves the function call from the last message in the <see cref="Messages"/> list 
        /// if it is of the assistant role and contains a function call. 
        /// </summary>
        /// <returns>The function call from the last message in the <see cref="Messages"/> list, or 
        /// <c>null</c> if the last message is not of the assistant role or does not contain a function call.</returns>
        /// <exception cref="InvalidOperationException">Thrown when a function call is expected but not found.</exception>
        OpenAiFunctionCall GetFunctionCall();
    }
}
