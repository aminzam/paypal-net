using Moq;
using Paypal.Net.Sdk.Api;
using Paypal.Net.Sdk.Client;
using Paypal.Net.Sdk.Definitions;
using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Paypal.Net.Sdk.Tests {

  public class BillingPlanApiTests {

    private const string ExpectedApiUrl = "/v1/billing/plans";

    [Fact]
    public async void CallsActivatePlan() {

      // Arrange
      var paypalRestApiClientMock = new Mock<IPaypalRestApiClient>();
      var sut = new BillingPlanApi(paypalRestApiClientMock.Object);
      string expectedPlanId = "expected-plan-id";
      string expectedUrl = $"{ExpectedApiUrl}/{expectedPlanId}/activate";

      // Act
      await sut.ActivatePlanAsync(expectedPlanId);

      // Assert
      paypalRestApiClientMock.Verify(x => x.Post(It.Is<string>(url => url.Equals(expectedUrl, StringComparison.InvariantCultureIgnoreCase))));
    }

    [Fact]
    public async void CallsDeactivatePlan() {

      // Arrange
      var paypalRestApiClientMock = new Mock<IPaypalRestApiClient>();
      var sut = new BillingPlanApi(paypalRestApiClientMock.Object);
      string expectedPlanId = "expected-plan-id";
      string expectedUrl = $"{ExpectedApiUrl}/{expectedPlanId}/deactivate";

      // Act
      await sut.DeactivatePlan(expectedPlanId);

      // Assert
      paypalRestApiClientMock.Verify(x => x.Post(It.Is<string>(url => url.Equals(expectedUrl, StringComparison.InvariantCultureIgnoreCase))));
    }

    [Fact]
    public async void CallsUpdatePricing() {

      // Arrange
      var paypalRestApiClientMock = new Mock<IPaypalRestApiClient>();
      var sut = new BillingPlanApi(paypalRestApiClientMock.Object);
      string expectedPlanId = "expected-plan-id";
      var expectedPricingUpdateRequest = new PlanUpdatePricingRequest();
      string expectedUrl = $"{ExpectedApiUrl}/{expectedPlanId}/update-pricing-schemes";

      // Act
      await sut.UpdatePricingAsync(expectedPlanId, expectedPricingUpdateRequest);

      // Assert
      paypalRestApiClientMock.Verify(x => x.Post(expectedPricingUpdateRequest, It.Is<string>(url => url.Equals(expectedUrl, StringComparison.InvariantCultureIgnoreCase))));
    }

    [Fact]
    public async void CallsCreatePlan() {

      // Arrange
      var paypalRestApiClientMock = new Mock<IPaypalRestApiClient>();
      var sut = new BillingPlanApi(paypalRestApiClientMock.Object);
      var planCreationRequest = new PlanCreateRequest();
      string expectedUrl = $"{ExpectedApiUrl}";

      // Act
      await sut.CreatePlanAsync(planCreationRequest);

      // Assert
      paypalRestApiClientMock.Verify(x => x.Post<PlanCreateResponse>(planCreationRequest, It.Is<string>(url => url.Equals(expectedUrl, StringComparison.InvariantCultureIgnoreCase))));
    }

    [Fact]
    public async void CallsGetPlanDetails() {

      // Arrange
      var paypalRestApiClientMock = new Mock<IPaypalRestApiClient>();
      var expectedResult = new PlanDetailsResponse();
      paypalRestApiClientMock
        .Setup(x => x.Get<PlanDetailsResponse>(It.IsAny<string>()))
        .Returns(Task.FromResult(expectedResult));
      var sut = new BillingPlanApi(paypalRestApiClientMock.Object);
      string expectedPlanId = "expected-plan-id";
      string expectedUrl = $"{ExpectedApiUrl}/{expectedPlanId}";

      // Act
      PlanDetailsResponse result = await sut.GetPlanDetails(expectedPlanId);

      // Assert
      paypalRestApiClientMock.Verify(x => x.Get<PlanDetailsResponse>(It.Is<string>(url => url.Equals(expectedUrl, StringComparison.InvariantCultureIgnoreCase))));
      Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async void CallsListPlans() {

      // Arrange
      var paypalRestApiClientMock = new Mock<IPaypalRestApiClient>();
      var expectedResult = new PlanListResponse();
      paypalRestApiClientMock
        .Setup(x => x.Get<PlanListResponse>(It.IsAny<string>()))
        .Returns(Task.FromResult(expectedResult));
      var sut = new BillingPlanApi(paypalRestApiClientMock.Object);
      string expectedUrl = $"{ExpectedApiUrl}";

      // Act
      PlanListResponse result = await sut.ListPlansAsync();

      // Assert
      paypalRestApiClientMock.Verify(x => x.Get<PlanListResponse>(It.Is<string>(url => url.Equals(expectedUrl, StringComparison.InvariantCultureIgnoreCase))));
      Assert.Equal(expectedResult, result);
    }
  }
}
