using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Resource {

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("status_update_time")]
    public DateTime StatusUpdateTime { get; set; }

    [JsonProperty("status_change_note")]
    public string StatusChangeNote { get; set; }

    [JsonProperty("plan_id")]
    public string PlanId { get; set; }

    [JsonProperty("start_time")]
    public DateTime StartTime { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("shipping_amount")]
    public Money ShippingAmount { get; set; }

    [JsonProperty("subscriber")]
    public Subscriber Subscriber { get; set; }

    [JsonProperty("auto_renewal")]
    public bool AutoRenewal { get; set; }

    [JsonProperty("billing_info")]
    public BillingInfo BillingInfo { get; set; }

    [JsonProperty("create_time")]
    public DateTime CreateTime { get; set; }

    [JsonProperty("update_time")]
    public DateTime UpdateTime { get; set; }

    [JsonProperty("links")]
    public Link[] Links { get; set; }

    // START PAYMENT SALE COMPLETED FIELDS
    [JsonProperty("amount")]
    public Amount Amount { get; set; }

    [JsonProperty("payment_mode")]
    public string PaymentMode { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("protection_eligibility")]
    public string ProtectionEligibility { get; set; }

    [JsonProperty("protection_eligibility_type")]
    public string ProtectionEligibilityType { get; set; }

    [JsonProperty("clearing_time")]
    public DateTime ClearingTime { get; set; }

    [JsonProperty("parent_payment")]
    public string ParentPayment { get; set; }

    [JsonProperty("transaction_fee")]
    public TransactionFee TransactionFee { get; set; }

    [JsonProperty("receipt_id")]
    public string ReceiptId { get; set; }

    [JsonProperty("billing_agreement_id")]
    public string BillingAgreementId { get; set; }

    [JsonProperty("soft_descriptor")]
    public string SoftDescriptor { get; set; }

    [JsonProperty("invoice_number")]
    public string InvoiceNumber { get; set; }
    // END PAYMENT SALE COMPLETED FIELDS
  }

}