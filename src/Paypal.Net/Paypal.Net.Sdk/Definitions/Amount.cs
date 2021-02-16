using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public class Amount {

    [JsonProperty("total")]
    public string Total { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("details")]
    public Details Details { get; set; }
  }
}