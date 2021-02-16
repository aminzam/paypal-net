using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  //https://developer.paypal.com/docs/api/get-an-access-token-curl/
  public class TokenResponse {

    [JsonProperty(PropertyName = "scope")]
    public string Scope { get; set; }

    [JsonProperty(PropertyName = "access_token")]
    public string AccessToken { get; set; }

    [JsonProperty(PropertyName = "token_type")]
    public string TokenType { get; set; }

    [JsonProperty(PropertyName = "app_id")]
    public string AppId { get; set; }

    [JsonProperty(PropertyName = "expires_in")]
    public string ExpiresIn { get; set; }

    [JsonProperty(PropertyName = "nonce")]
    public string Nonce { get; set; }
  }
}