using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class SubscriptionCreateRequest
    {
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        [JsonProperty("start_time")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("shipping_amount")]
        public Money ShippingAmount { get; set; }

        [JsonProperty("subscriber")]
        public Subscriber Subscriber { get; set; }

        [JsonProperty("application_context")]
        public ApplicationContext ApplicationContext { get; set; }
    }

}