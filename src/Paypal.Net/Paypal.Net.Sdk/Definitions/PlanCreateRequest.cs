using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class PlanCreateRequest {
    [JsonProperty("product_id")]
    public string ProductId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("billing_cycles")]
    public BillingCycle[] BillingCycles { get; set; }

    [JsonProperty("payment_preferences")]
    public PaymentPreferences PaymentPreferences { get; set; }

    [JsonProperty("taxes")]
    public Taxes Taxes { get; set; }

    [JsonProperty("quantity_supported")]
    public bool QuantitySupported { get; set; }
  }

}