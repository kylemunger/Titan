using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Titan.Core.OpenAi;

namespace Titan.Agents
{
    /// <summary>
    /// Represents an agent which can execute certain tasks and interacts with OpenAI.
    /// </summary>
    public interface IAgent : IDisposable
    {
        /// <summary>
        /// Gets or sets the unique identifier for the agent.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Retrieves a list of available functions that the agent can execute.
        /// </summary>
        /// <returns>A list of available functions in the form of OpenAiFunction objects.</returns>
        List<OpenAiFunction> GetAvailableFunctions();

        /// <summary>
        /// Executes a given agent task asynchronously.
        /// </summary>
        /// <param name="task">The agent task to execute.</param>
        /// <returns>An AgentTaskResult object that represents the result of the task execution.</returns>
        Task<IAgentTaskResult> InvokeAgentTaskAsync(IAgentTask task);
    }
}
