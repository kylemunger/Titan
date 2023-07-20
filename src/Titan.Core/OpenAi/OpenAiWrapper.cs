using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Titan.Core.Constants;
using Titan.Core.Exceptions;

namespace Titan.Core.OpenAi
{
    /// <summary>
    /// Handles OpenAI requests via the OpenAI API.
    /// Implements the IOpenAiWrapper interface.
    /// </summary>
    public class OpenAiWrapper : IOpenAiWrapper
    {
        /// <summary>
        /// Http client used for HTTP communications.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// The API key used for authenticating with the OpenAI API.
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// Initialize a new instance of the OpenAiWrapper Class.
        /// </summary>
        public OpenAiWrapper(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        /// <summary>
        /// Sends a message asynchronously to OpenAi and returns the corresponding response.
        /// </summary>
        /// <param name="request">The OpenAi request to send.</param>
        /// <returns>Task representing the asynchronous operation with an OpenAi Response as a result.</returns>
        /// <exception cref="OpenAiApiException">Thrown when there is error in communication with OpenAI API.</exception>
        public async Task<OpenAiResponse> SendRequestAsync(IOpenAiRequest request)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, OpenAiConstants.OPENAI_API_CHAT_URL);
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
            requestMessage.Content = new StringContent(request.GetRequest().ToString(), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);
            string responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new OpenAiApiException("Error communicating with OpenAI API.", response.StatusCode, responseContent);
            }

            return new OpenAiResponse(JObject.Parse(responseContent));
        }
    }
}
