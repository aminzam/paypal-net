using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Paypal.Net.Sdk.Definitions;

namespace Paypal.Net.Sdk.Client {

  public class AuthenticationApi : IAuthenticationApi {

    private const string PayPalTokenKey = "PaypalTokenResponse";

    private readonly IMemoryCache _cache;
    private readonly IConfiguration _configuration;
    private readonly IHttpService _httpService;
    private readonly IResponseReader _responseReader;

    public AuthenticationApi(IMemoryCache cache, IConfiguration configuration, IHttpService httpService, IResponseReader responseReader) {

      _cache = cache;
      _configuration = configuration;
      _httpService = httpService;
      _responseReader = responseReader;
    }

    public async Task<string> GetAccessTokenAsync() {

      TokenResponse response =
        await _cache.GetOrCreateAsync(PayPalTokenKey, async entry => {

          TokenResponse newResponse = await GetNewAccessTokenAsync();
          entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(double.Parse(newResponse.ExpiresIn));
          return newResponse;
        });


      return response.AccessToken;
    }

    private async Task<TokenResponse> GetNewAccessTokenAsync() {

      const string apiUrl = "/v1/oauth2/token";
      var request = new HttpRequestMessage(HttpMethod.Post, _configuration["Paypal:ApiBaseUrl"] + apiUrl);
      request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("en_US"));

      request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
        Convert.ToBase64String(
          Encoding.ASCII.GetBytes($"{_configuration["Paypal:ClientId"]}:{_configuration["Paypal:Secret"]}")));

      request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/json");

      HttpResponseMessage response = await _httpService.SendAndReturnResponseAsync(request);

      if (!response.IsSuccessStatusCode) {

        string responseContent = await response.Content.ReadAsStringAsync();
        throw new Exception("Failed when getting a new access token. Paypal responded with: " + response + ". Content: " + responseContent);
      }

      return await _responseReader.ReadResponseAsync<TokenResponse>(response);
    }
  }
}