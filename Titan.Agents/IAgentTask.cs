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
    }
}
