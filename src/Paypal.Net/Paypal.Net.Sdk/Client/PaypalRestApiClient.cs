using Paypal.Net.Sdk.Definitions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paypal.Net.Sdk.Client {

  public class PaypalRestApiClient : IPaypalRestApiClient {

    private readonly IHttpService _httpService;
    private readonly IRequestBuilder _requestBuilder;
    private readonly IResponseReader _responseReader;

    public PaypalRestApiClient(IHttpService httpService, IRequestBuilder requestBuilder, IResponseReader responseReader) {

      _httpService = httpService;
      _requestBuilder = requestBuilder;
      _responseReader = responseReader;
    }

    public async Task Post(object body, string apiRelativeUrl) {

      HttpRequestMessage request = await _requestBuilder.CreateRequestAsync(HttpMethod.Post, body, apiRelativeUrl);

      HttpResponseMessage response = await _httpService.SendAndReturnResponseAsync(request);

      await VerifyResponseAsync(response);
    }

    public async Task<T> Post<T>(object body, string apiRelativeUrl) {

      HttpRequestMessage request = await _requestBuilder.CreateRequestAsync(HttpMethod.Post, body, apiRelativeUrl);

      HttpResponseMessage response = await _httpService.SendAndReturnResponseAsync(request);

      await VerifyResponseAsync(response);

      return await _responseReader.ReadResponseAsync<T>(response);
    }

    public async Task Post(string apiRelativeUrl) {

      HttpRequestMessage request = await _requestBuilder.CreateRequestAsync(HttpMethod.Post, null, apiRelativeUrl);

      HttpResponseMessage response = await _httpService.SendAndReturnResponseAsync(request);

      await VerifyResponseAsync(response);
    }

    public async Task Patch(Patch[] patches, string apiRelativeUrl) {

      HttpRequestMessage request = await _requestBuilder.CreateRequestAsync(HttpMethod.Patch, patches, apiRelativeUrl);

      HttpResponseMessage response = await _httpService.SendAndReturnResponseAsync(request);

      await VerifyResponseAsync(response);
    }

    public async Task<T> Get<T>(string apiRelativeUrl) {

      HttpRequestMessage request = await _requestBuilder.CreateRequestAsync(HttpMethod.Get, null, apiRelativeUrl);

      HttpResponseMessage response = await _httpService.SendAndReturnResponseAsync(request);

      await VerifyResponseAsync(response);

      return await _responseReader.ReadResponseAsync<T>(response);
    }

    private async Task VerifyResponseAsync(HttpResponseMessage response) {

      if (!response.IsSuccessStatusCode)
        throw new Exception(
          $"Error sending request to Paypal. Returned: {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
    }
  }
}