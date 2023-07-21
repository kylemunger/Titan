using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core;
using Titan.Core.OpenAi;

namespace Titan.Agents
{
    public class AgentTask : IAgentTask
    {
        /// <inheritdoc/>
        public string Id { get; set; }

        /// <inheritdoc/>
        public List<OpenAiMessage> Messages { get; set; }

        /// <summary>
        /// Initializes a new blank instance of the <see cref="AgentTask"/> with a singular user message.
        /// </summary>
        /// <param name="userInput">The user input representing the task request.</param>
        public AgentTask(string userInput) 
        {
            Id = Guid.NewGuid().ToString();
            Messages = new List<OpenAiMessage>()
            {
                new OpenAiMessage()
                {
                    Role = "user",
                    Content = userInput
                }
            };
        }

        /// <summary>
        /// Initializes a newinstance of the <see cref="AgentTask"/> object with a list of messages to send in the request.
        /// </summary>
        /// <param name="messages">The message list to send in the request.</param>
        public AgentTask(List<OpenAiMessage> messages)
        {
            Id = Guid.NewGuid().ToString();
            Messages = messages;
        }

        /// <inheritdoc/>
        public bool IsFunctionCall()
        {
            if (Messages.Count > 0)
            {
                OpenAiMessage lastMessage = Messages[Messages.Count - 1];
                return lastMessage.FunctionCall != null;
            }

            return false;
        }

        /// <inheritdoc/>
        public OpenAiFunctionCall GetFunctionCall()
        {
            if (!IsFunctionCall())
            {
                throw new InvalidOperationException();
            }

            return Messages[Messages.Count - 1].FunctionCall;
        }
    }
}
