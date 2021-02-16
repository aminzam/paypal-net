using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class ShippingAddressName
  {
    [JsonProperty("full_name")]
    public string FullName { get; set; }
  }

}