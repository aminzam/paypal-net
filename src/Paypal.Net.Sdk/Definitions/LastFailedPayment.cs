using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class LastFailedPayment {
    [JsonProperty("amount")]
    public Money Amount { get; set; }

    [JsonProperty("time")]
    public DateTimeOffset Time { get; set; }

    [JsonProperty("reason_code")]
    public string ReasonCode { get; set; }

    [JsonProperty("next_payment_retry_date")]
    public DateTimeOffset NextPaymentRetryDate { get; set; }
  }

}