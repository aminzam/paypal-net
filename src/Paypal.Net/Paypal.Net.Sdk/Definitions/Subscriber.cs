using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Subscriber
  {
    [JsonProperty("name")]
    public SubscriberName Name { get; set; }

    [JsonProperty("email_address")]
    public string EmailAddress { get; set; }

    [JsonProperty("shipping_address")]
    public ShippingAddress ShippingAddress { get; set; }

    [JsonProperty("payer_id")]
    public string PayerId { get; set; }
  }

}