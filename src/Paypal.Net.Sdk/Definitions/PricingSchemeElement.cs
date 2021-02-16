using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class PricingSchemeElement {
    [JsonProperty("billing_cycle_sequence")]
    public long BillingCycleSequence { get; set; }

    [JsonProperty("pricing_scheme")]
    public PricingScheme PricingScheme { get; set; }
  }

}