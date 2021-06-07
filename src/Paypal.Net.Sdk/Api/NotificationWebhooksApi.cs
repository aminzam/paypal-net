using System.Threading.Tasks;
using Paypal.Net.Sdk.Client;
using Paypal.Net.Sdk.Definitions;

namespace Paypal.Net.Sdk.Api {
  
  /// <summary>
  /// Provides access to PayPal's Webhook API.
  /// </summary>
  /// <remarks>
  /// Official Docs: https://developer.paypal.com/docs/api/webhooks/v1
  /// </remarks>
  public class NotificationWebhooksApi {

    private readonly IPaypalRestApiClient _paypalRestApiClient;

    private const string ApiUrl = "/v1/notifications/webhooks";
    
    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="paypalRestApiClient">PayPal client object that provides HTTP access.</param>
    public NotificationWebhooksApi(IPaypalRestApiClient paypalRestApiClient) {

      _paypalRestApiClient = paypalRestApiClient;
    }

    /// <summary>
    /// Subscribes your webhook listener to events.
    /// </summary>
    /// <param name="webhookCreateRequest">Webhook creation request object.</param>
    /// <returns>A task object representing asynchronous operation.</returns>
    public async Task CreateWebHookAsync(WebhookCreateRequest webhookCreateRequest) {

      await _paypalRestApiClient.Post(webhookCreateRequest, ApiUrl);
    }

    /// <summary>
    /// Lists webhooks for an app.
    /// </summary>
    /// <returns>A task object representing webhook list.</returns>
    public async Task<WebListHookResponse> ListWebHooksAsync() {

      return await _paypalRestApiClient.Get<WebListHookResponse>(ApiUrl);
    }
  }
}