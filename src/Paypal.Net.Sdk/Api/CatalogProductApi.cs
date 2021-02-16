using System.Threading.Tasks;
using Paypal.Net.Sdk.Client;
using Paypal.Net.Sdk.Definitions;

namespace Paypal.Net.Sdk.Api {
  
  /// <summary>
  /// Provides access to PayPal's Catalog API.
  /// </summary>
  /// <remarks>
  /// Official Docs: https://developer.paypal.com/docs/api/catalog-products/v1
  /// </remarks>
  public class CatalogProductApi {

    private readonly PaypalRestApiClient _paypalRestApiClient;

    private const string ApiUrl = "/v1/catalogs/products";

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="paypalRestApiClient">PayPal client object that provides HTTP access.</param>
    public CatalogProductApi(PaypalRestApiClient paypalRestApiClient) {

      _paypalRestApiClient = paypalRestApiClient;
    }

    /// <summary>
    /// Creates a product.
    /// </summary>
    /// <param name="product">Product creation request object.</param>
    /// <returns>A task object representing asynchronous operation.</returns>
    public async Task CreateProductAsync(ProductCreateRequest product) {

      await _paypalRestApiClient.Post(product, ApiUrl);
    }

    /// <summary>
    /// Lists products.
    /// </summary>
    /// <returns>A task object representing product list.</returns>
    public async Task<ProductListResponse> ListProductsAsync() {

      return await _paypalRestApiClient.Get<ProductListResponse>(ApiUrl);
    }
  }
}