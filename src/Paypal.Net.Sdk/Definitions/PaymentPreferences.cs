using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class PaymentPreferences {
    [JsonProperty("auto_bill_outstanding")]
    public bool AutoBillOutstanding { get; set; }

    [JsonProperty("setup_fee")]
    public Money SetupFee { get; set; }

    [JsonProperty("setup_fee_failure_action")]
    public string SetupFeeFailureAction { get; set; }

    [JsonProperty("payment_failure_threshold")]
    public long PaymentFailureThreshold { get; set; }
  }

}