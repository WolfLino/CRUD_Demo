using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CRUD.API.HealthChecks
{
    public class HealthCheck : IHealthCheck
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IHttpClientFactory httpClientFactory;

        public HealthCheck(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var request = httpContextAccessor.HttpContext.Request;
            string myUrl = request.Scheme + "://" + request.Host.ToString();

            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync(myUrl);
            var pageContents = await response.Content.ReadAsStringAsync();
            if (pageContents.Contains("product1"))
            {
                return HealthCheckResult.Healthy("The check indicates a healthy result.");
            }

            return HealthCheckResult.Unhealthy("The check indicates an unhealthy result.");
        }
    }
}
