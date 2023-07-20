using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.OpenAi;

namespace Titan.Agents.Constants
{
    /// <summary>
    /// The Agent abstract class represents a generic agent implementation, providing key shared functionalities.
    /// Specific agent types will derive from this base class and implement their own unique behaviors.
    /// </summary>
    public abstract class Agent : IAgent
    {
        // common fields that are required by all agents
        protected string _id;
        protected IOpenAiWrapper _wrapper;
        protected OpenAiModel _model;
        protected List<OpenAiFunction> _functions;
        protected OpenAiMessage _systemMessage;

        /// <summary>
        /// Initializes a new instance of the Agent class.
        /// </summary>
        /// <param name="wrapper">An IOpenAiWrapper instance for OpenAI chat API interactions.</param>
        /// <param name="model">The model used for this particular agent.</param>
        public Agent(IOpenAiWrapper wrapper, OpenAiModel model)
        {
            _id = Guid.NewGuid().ToString();
            _wrapper = wrapper;
            _model = model;
            _functions = new List<OpenAiFunction>();
            _systemMessage = new OpenAiMessage
            {
                Role = "system",
                Content = "You are a helpful chatbot"
            };
        }

        /// <summary>
        /// Gets or sets the unique identifier for this instance of the Agent.
        /// </summary>
        public string Id { get => _id; set => _id = value; }

        /// <summary>
        /// Retrieves a list of available functions that the agent can execute.
        /// </summary>
        /// <returns>A List of OpenAiFunction objects that can be executed by the agent.</returns>
        public List<OpenAiFunction> GetAvailableFunctions()
        {
            return _functions;
        }

        /// <summary>
        /// Invokes an agent task asynchronously and retrieves a result.
        /// </summary>
        /// <param name="task">An IAgentTask representing the task to be executed by the Agent.</param>
        /// <returns>A Task resulting in the IAgentTaskResult that represents the result of the task execution.</returns>
        public async Task<IAgentTaskResult> InvokeAgentTaskAsync(IAgentTask task)
        {
            List<OpenAiMessage> messages = new List<OpenAiMessage>()
            {
                _systemMessage
            };
            messages.AddRange(task.Messages);

            if (task.IsFunctionCall())
            {
                OpenAiFunctionCall functionCall = task.GetFunctionCall();
                OpenAiMessage functionCallResult = new OpenAiMessage()
                {
                    Role = "function",
                    Name = functionCall.GetFunctionName(),
                    Content = await InvokeFunction(functionCall)
                };
                messages.Add(functionCallResult);
            }

            IOpenAiRequest request = new OpenAiRequest(_model, messages, _functions);
            OpenAiResponse response = await _wrapper.SendRequestAsync(request);

            return new AgentTaskResult(task, response);
        }

        /// <summary>
        /// Invokes a specified OpenAiFunctionCall and retrieves the result string.
        /// </summary>
        /// <param name="functionCall">An OpenAiFunctionCall that represents the function to be invoked.</param>
        /// <returns>A Task resulting in a string that represents the result of the function call.</returns>
        public async Task<string> InvokeFunction(OpenAiFunctionCall functionCall)
        {
            Type t = this.GetType();
            MethodInfo method = t.GetMethod(functionCall.GetFunctionName());
            return await (Task<string>)method.Invoke(this, functionCall.GetParameterObjects());
        }

        /// <summary>
        /// Performs clean up activities, such as deallocating resources, for an Agent object.
        /// </summary>
        public void Dispose()
        {

        }
    }
}
