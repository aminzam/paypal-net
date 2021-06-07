using System.Threading.Tasks;
using Paypal.Net.Sdk.Client;
using Paypal.Net.Sdk.Definitions;

namespace Paypal.Net.Sdk.Api {

  /// <summary>
  /// Provides access to PayPal's billing API for subscription.
  /// </summary>
  /// <remarks>
  /// Official Docs: https://developer.paypal.com/docs/api/subscriptions/v1/#subscriptions
  /// </remarks>
  public class BillingSubscriptionApi {

    private const string ApiUrl = "/v1/billing/subscriptions";

    private readonly IPaypalRestApiClient _paypalRestApiClient;
    
    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="paypalRestApiClient">PayPal client object that provides HTTP access.</param>
    public BillingSubscriptionApi(IPaypalRestApiClient paypalRestApiClient) {

      _paypalRestApiClient = paypalRestApiClient;
    }

    /// <summary>
    /// Creates a subscription.
    /// </summary>
    /// <param name="subscriptionCreateRequest">Plan creation request object.</param>
    /// <returns>A task object representing asynchronous operation.</returns>
    public async Task CreateSubscriptionAsync(SubscriptionCreateRequest subscriptionCreateRequest) {

      await _paypalRestApiClient.Post(subscriptionCreateRequest, ApiUrl);
    }

    /// <summary>
    /// Shows details for a subscription, by ID.
    /// </summary>
    /// <param name="id">The ID of the subscription.</param>
    /// <returns>A task object representing subscription object.</returns>
    public async Task<Subscription> GetSubscriptionAsync(string id) {

      return await _paypalRestApiClient.Get<Subscription>($"{ApiUrl}/{id}");
    }

    /// <summary>
    /// Cancels the subscription.
    /// </summary>
    /// <param name="id">The ID of the subscription.</param>
    /// <param name="subscriptionCancelRequest">Cancellation request object.</param>
    /// <returns>A task object representing asynchronous operation.</returns>
    public async Task CancelSubscription(string id, SubscriptionCancelRequest subscriptionCancelRequest) {

      await _paypalRestApiClient.Post(subscriptionCancelRequest, $"{ApiUrl}/{id}/cancel");
    }
  }
}