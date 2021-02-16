using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Paypal.Net.Sdk.Client {

  internal class RequestBuilder : IRequestBuilder {

    private readonly IConfiguration _configuration;
    private readonly IAuthenticationApi _authenticationApi;

    public RequestBuilder(IConfiguration configuration, IAuthenticationApi authenticationApi) {

      _configuration = configuration;
      _authenticationApi = authenticationApi;
    }

    public async Task<HttpRequestMessage> CreateRequestAsync(HttpMethod method, object body, string apiRelativeUrl) {

      var request = new HttpRequestMessage(method, _configuration["Paypal:ApiBaseUrl"] + apiRelativeUrl);

      request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _authenticationApi.GetAccessTokenAsync());

      string bodyJson = body != null ? JsonConvert.SerializeObject(body) : string.Empty;
      request.Content = new StringContent(bodyJson, Encoding.UTF8, "application/json");

      return request;
    }
  }
}
