using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Titan.Agents.Constants;
using Titan.Core.OpenAi;

namespace Titan.Agents
{
    /// <summary>
    /// The SystemControllerAgent class encapsulates the system controller which can manage and interact with other agents.
    /// </summary>
    public class SystemControllerAgent : Agent
    {
        private List<IAgent> _agents;

        /// <summary>
        /// Initializes a new instance of the SystemControllerAgent class.
        /// </summary>
        /// <param name="wrapper">An IOpenAiWrapper instance for OpenAI chat API interactions.</param>
        /// <param name="model">The model used for this particular agent.</param>
        public SystemControllerAgent(IOpenAiWrapper wrapper, OpenAiModel model) : base(wrapper, model)
        {
            _id = Guid.NewGuid().ToString();
            _systemMessage = new OpenAiMessage() { Role = "system", Content = SystemMessageConstants.SYSTEM_CONTROLLER };
            _functions = new List<OpenAiFunction>();
            _agents = new List<IAgent>();
            _wrapper = wrapper;
            _model = model;

            // Open Agent Function
            List<OpenAiParameter> openAgentParameters = new List<OpenAiParameter>()
            {
                //todo
            };
            OpenAiFunction openAgentFunction = new OpenAiFunction("OpenAgent", "Opens a new agent", openAgentParameters);

            // Close Agent Function
            List<OpenAiParameter> closeAgentParameters = new List<OpenAiParameter>()
            {
                //todo
            };
            OpenAiFunction closeAgentFunction = new OpenAiFunction("CloseAgent", "Closes an agent", closeAgentParameters);

            // Send Request to Agent Function
            List<OpenAiParameter> sendRequestToAgentParameters = new List<OpenAiParameter>()
            {
                //todo
            };
            OpenAiFunction sendRequestToAgentFunction = new OpenAiFunction("SendRequestToAgent", "Sends a request to an opened agent", sendRequestToAgentParameters);

            _functions.Add(openAgentFunction);
            _functions.Add(closeAgentFunction);
            _functions.Add(sendRequestToAgentFunction);
        }

        /// <summary>
        /// Opens a new agent.
        /// </summary>
        /// <param name="obj">A JObject parameter object that represents the parameters for the function call.</param>
        /// <returns>A Task resulting in a string that represents the result of the function call.</returns>
        private Task<string> OpenAgent(JObject obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes an existing agent.
        /// </summary>
        /// <param name="obj">A JObject parameter object that represents the parameters for the function call.</param>
        /// <returns>A Task resulting in a string that represents the result of the function call.</returns>
        private Task<string> CloseAgent(JObject obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a request to an open agent.
        /// </summary>
        /// <param name="obj">A JObject parameter object that represents the parameters for the function call.</param>
        /// <returns>A Task resulting in a string that represents the result of the function call.</returns>
        private Task<string> SendRequestToAgent(JObject obj)
        {
            throw new NotImplementedException();
        }
    }
}
