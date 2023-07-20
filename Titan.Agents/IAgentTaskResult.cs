using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Agents
{
    /// <summary>
    /// Represents the result of a task executed by an agent.
    /// </summary>
    public interface IAgentTaskResult
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task which produced this result.
        /// </summary>
        string TaskId { get; set; }

        /// <summary>
        /// Gets or sets the result of the task execution.
        /// </summary>
        string Result { get; set; }

        /// <summary>
        /// Gets or sets the next task that is requested to be executed by the agent. Can be null.
        /// </summary>
        IAgentTask RequestedTask { get; set; }
    }
}
