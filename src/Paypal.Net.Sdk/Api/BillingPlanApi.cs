using System.Threading.Tasks;
using Paypal.Net.Sdk.Client;
using Paypal.Net.Sdk.Definitions;

namespace Paypal.Net.Sdk.Api {

  /// <summary>
  /// Provides access to PayPal's billing API for plans.
  /// </summary>
  /// <remarks>
  /// Official Docs: https://developer.paypal.com/docs/api/subscriptions/v1/#plans
  /// </remarks>
  public class BillingPlanApi {

    private readonly IPaypalRestApiClient _paypalRestApiClient;

    private const string ApiUrl = "/v1/billing/plans";

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="paypalRestApiClient">PayPal client object that provides HTTP access.</param>
    public BillingPlanApi(IPaypalRestApiClient paypalRestApiClient) {

      _paypalRestApiClient = paypalRestApiClient;
    }

    /// <summary>
    /// Creates a plan that defines pricing and billing cycle details for subscriptions.
    /// </summary>
    /// <param name="plan">Plan request object that contains desired configuration.</param>
    /// <returns>A task object representing plan creation response.</returns>
    public async Task<PlanCreateResponse> CreatePlanAsync(PlanCreateRequest plan) {

      return await _paypalRestApiClient.Post<PlanCreateResponse>(plan, ApiUrl);
    }

    /// <summary>
    /// Lists billing plans.
    /// </summary>
    /// <returns>A task object representing list of plans.</returns>
    public async Task<PlanListResponse> ListPlansAsync() {

      return await _paypalRestApiClient.Get<PlanListResponse>(ApiUrl);
    }

    /// <summary>
    /// Activates a plan, by ID.
    /// </summary>
    /// <param name="planId">The ID for the plan.</param>
    /// <returns>A task object representing asynchronous operation.</returns>
    public async Task ActivatePlanAsync(string planId) {

      await _paypalRestApiClient.Post($"{ApiUrl}/{planId}/activate");
    }

    /// <summary>
    /// Deactivates a plan, by ID.
    /// </summary>
    /// <param name="planId">The ID for the plan.</param>
    /// <returns>A task object representing asynchronous operation.</returns>
    public async Task DeactivatePlan(string planId) {

      await _paypalRestApiClient.Post($"{ApiUrl}/{planId}/deactivate");
    }

    /// <summary>
    /// Updates pricing for a plan. For example, you can update a regular billing cycle from $5 per month to $7 per month.
    /// </summary>
    /// <param name="planId">The ID for the plan.</param>
    /// <param name="planUpdatePricingRequest">Request object.</param>
    /// <returns>A task object representing asynchronous operation.</returns>
    public async Task UpdatePricingAsync(string planId, PlanUpdatePricingRequest planUpdatePricingRequest) {

      await _paypalRestApiClient.Post(planUpdatePricingRequest, $"{ApiUrl}/{planId}/update-pricing-schemes");
    }

    /// <summary>
    /// Shows details for a plan, by ID.
    /// </summary>
    /// <param name="planId">The ID of the plan.</param>
    /// <returns>A task object representing plan details.</returns>
    public async Task<PlanDetailsResponse> GetPlanDetails(string planId) {

      return await _paypalRestApiClient.Get<PlanDetailsResponse>($"{ApiUrl}/{planId}");
    }
  }
}