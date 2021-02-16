using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class PlanUpdatePricingRequest {
    [JsonProperty("pricing_schemes")]
    public PricingSchemeElement[] PricingSchemes { get; set; }
  }

}