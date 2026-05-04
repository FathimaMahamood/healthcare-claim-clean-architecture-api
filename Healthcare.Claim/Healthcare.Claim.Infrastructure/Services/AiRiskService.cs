using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Infrastructure.Services
{
    public class AiRiskService : IAiRiskService
    {
        private readonly HttpClient _httpClient;

        public AiRiskService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            var baseUrl = config["AIService:BaseUrl"];
            _httpClient.BaseAddress = new Uri(baseUrl!);
        }

        public async Task<RiskResponse> AnalyzeAsync(RiskRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync( "/analyze",  request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<RiskResponse>();

            return result!;
        }
    }
}
