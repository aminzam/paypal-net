using System.Net.Http;
using System.Threading.Tasks;

namespace Paypal.Net.Sdk.Client {

  internal class HttpService : IHttpService {

    public const string PaypalHttpClientName = "PaypalApiHttpClient";

    private readonly IHttpClientFactory _httpClientFactory;

    public HttpService(IHttpClientFactory httpClientFactory) {

      _httpClientFactory = httpClientFactory;
    }

    public async Task<HttpResponseMessage> SendAndReturnResponseAsync(HttpRequestMessage request) {

      HttpClient httpClient = _httpClientFactory.CreateClient(PaypalHttpClientName);

      return await httpClient.SendAsync(request);
    }
  }
}
