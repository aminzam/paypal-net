using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class BillingInfo {
    [JsonProperty("outstanding_balance")]
    public Money OutstandingBalance { get; set; }

    [JsonProperty("cycle_executions")]
    public CycleExecution[] CycleExecutions { get; set; }

    [JsonProperty("last_payment")]
    public LastPayment LastPayment { get; set; }

    [JsonProperty("last_failed_payment")]
    public LastFailedPayment LastFailedPayment { get; set; }

    [JsonProperty("next_billing_time")]
    public DateTime NextBillingTime { get; set; }

    [JsonProperty("final_payment_time")]
    public DateTime FinalPaymentTime { get; set; }

    [JsonProperty("failed_payments_count")]
    public long FailedPaymentsCount { get; set; }
  }

}