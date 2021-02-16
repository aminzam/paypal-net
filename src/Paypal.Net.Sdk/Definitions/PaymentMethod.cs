using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class PaymentMethod
  {
    [JsonProperty("payer_selected")]
    public string PayerSelected { get; set; }

    [JsonProperty("payee_preferred")]
    public string PayeePreferred { get; set; }
  }

}