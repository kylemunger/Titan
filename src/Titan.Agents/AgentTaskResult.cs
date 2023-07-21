using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.OpenAi;

namespace Titan.Agents
{
    public class AgentTaskResult : IAgentTaskResult
    {
        public string TaskId { get; }

        public string Result { get; }

        public IAgentTask RequestedTask { get; }

        public AgentTaskResult(IAgentTask task, OpenAiResponse response) 
        {
            throw new NotImplementedException();
        }
    }
}
