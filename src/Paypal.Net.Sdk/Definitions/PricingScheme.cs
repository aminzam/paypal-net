using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class PricingScheme {

    [JsonProperty("fixed_price")]
    public Money FixedPrice { get; set; }

    [JsonProperty("version")]
    public long Version { get; set; }

    [JsonProperty("create_time")]
    public DateTime CreateTime { get; set; }

    [JsonProperty("update_time")]
    public DateTime UpdateTime { get; set; }
  }

}