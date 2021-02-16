using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class SubscriberName
  {
    [JsonProperty("given_name")]
    public string GivenName { get; set; }

    [JsonProperty("surname")]
    public string Surname { get; set; }
  }

}