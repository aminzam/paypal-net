using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Subscription {

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("plan_id")]
    public string PlanId { get; set; }

    [JsonProperty("start_time")]
    public DateTimeOffset StartTime { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("shipping_amount")]
    public Money ShippingAmount { get; set; }

    [JsonProperty("subscriber")]
    public Subscriber Subscriber { get; set; }

    [JsonProperty("billing_info")]
    public BillingInfo BillingInfo { get; set; }

    [JsonProperty("create_time")]
    public DateTimeOffset CreateTime { get; set; }

    [JsonProperty("update_time")]
    public DateTimeOffset UpdateTime { get; set; }

    [JsonProperty("links")]
    public Link[] Links { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("status_update_time")]
    public DateTimeOffset StatusUpdateTime { get; set; }
  }
}