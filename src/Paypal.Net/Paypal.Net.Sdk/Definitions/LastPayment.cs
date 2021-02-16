using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class LastPayment {
    [JsonProperty("amount")]
    public Money Amount { get; set; }

    [JsonProperty("time")]
    public DateTime Time { get; set; }
  }

}