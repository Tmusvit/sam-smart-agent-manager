using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam.helper
{
    internal class RestApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public RestApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<string> Message(string agentId, string conversationId, string message)
        {
            var requestUrl = $"{_baseUrl}/message?agentId={agentId}&conversationId={conversationId}&message={message}";
            var response = await _httpClient.GetAsync(requestUrl);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task SaveAgent(SmartAgent smartAgent)
        {
            var requestUrl = $"{_baseUrl}/agent";
            var json = JsonConvert.SerializeObject(smartAgent);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUrl, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAgent(SmartAgent smartAgent)
        {
            var requestUrl = $"{_baseUrl}/agent/{smartAgent.currentAgentSettings}";
            var response = await _httpClient.DeleteAsync(requestUrl);
            response.EnsureSuccessStatusCode();
        }

    }
}
