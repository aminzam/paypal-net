using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class ShippingAddress
  {
    [JsonProperty("name")]
    public ShippingAddressName Name { get; set; }

    [JsonProperty("address")]
    public Address Address { get; set; }
  }

}