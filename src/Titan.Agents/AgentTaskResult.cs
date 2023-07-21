using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.OpenAi;

namespace Titan.Agents
{
    public class AgentTaskResult : IAgentTaskResult
    {
        /// <inheritdoc/>
        public string TaskId { get; }

        /// <inheritdoc/>
        public string Result { get; }

        /// <inheritdoc/>
        public IAgentTask RequestedTask { get; }

        public AgentTaskResult(IAgentTask task, OpenAiResponse response) 
        {
            throw new NotImplementedException();
        }
    }
}
