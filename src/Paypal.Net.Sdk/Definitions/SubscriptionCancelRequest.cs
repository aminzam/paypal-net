using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public class SubscriptionCancelRequest {
    
    [JsonProperty("reason")]
    public string Reason { get; set; }
  }
}