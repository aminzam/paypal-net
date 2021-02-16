using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using Paypal.Net.Sdk.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Paypal.Net.Sdk.Tests {

  public class RestApiClientTests {

    [Fact]
    public async void CallsPostsWithBody() {

      // Arrange
      var httpServiceMock = CreateHttpServiceMock(out _);
      var requestBuilderMock = CreateRequestBuilderMock();
      var sut = new PaypalRestApiClient(httpServiceMock.Object, requestBuilderMock.Object, new Mock<IResponseReader>().Object);

      var body = new object();
      string apiPath = "http://example.com/";

      // Act
      await sut.Post(body, apiPath);

      // Assert
      httpServiceMock.Verify(x => x.SendAndReturnResponseAsync(It.Is<HttpRequestMessage>(request => HasValues(request, HttpMethod.Post, body, apiPath).Result)));
    }

    [Fact]
    public async void CallsPostsWithReturnString() {

      // Arrange
      var httpServiceMock = CreateHttpServiceMock(out HttpResponseMessage response);
      var requestBuilderMock = CreateRequestBuilderMock();
      var responseReaderMock = new Mock<IResponseReader>();
      var sut = new PaypalRestApiClient(httpServiceMock.Object, requestBuilderMock.Object, responseReaderMock.Object);

      var body = new object();
      string apiPath = "http://example.com/";

      // Act
      string result = await sut.Post<string>(body, apiPath);

      // Assert
      httpServiceMock.Verify(x => x.SendAndReturnResponseAsync(It.Is<HttpRequestMessage>(request => HasValues(request, HttpMethod.Post, body, apiPath).Result)));
      responseReaderMock.Verify(x => x.ReadResponseAsync<string>(response));
    }

    [Fact]
    public async void CallsPost() {

      // Arrange
      var httpServiceMock = CreateHttpServiceMock(out _);
      var requestBuilderMock = CreateRequestBuilderMock();
      var responseReaderMock = new Mock<IResponseReader>();
      var sut = new PaypalRestApiClient(httpServiceMock.Object, requestBuilderMock.Object, responseReaderMock.Object);

      string apiPath = "http://example.com/";

      // Act
      await sut.Post(apiPath);

      // Assert
      httpServiceMock.Verify(x => x.SendAndReturnResponseAsync(It.Is<HttpRequestMessage>(request => HasValues(request, HttpMethod.Post, null, apiPath).Result)));
    }

    [Fact]
    public async void CallsGet() {

      // Arrange
      var httpServiceMock = CreateHttpServiceMock(out HttpResponseMessage response);
      var requestBuilderMock = CreateRequestBuilderMock();
      var responseReaderMock = new Mock<IResponseReader>();
      var sut = new PaypalRestApiClient(httpServiceMock.Object, requestBuilderMock.Object, responseReaderMock.Object);

      string apiPath = "http://example.com/";

      // Act
      string result = await sut.Get<string>(apiPath);

      // Assert
      httpServiceMock.Verify(x => x.SendAndReturnResponseAsync(It.Is<HttpRequestMessage>(request => HasValues(request, HttpMethod.Get, null, apiPath).Result)));
      responseReaderMock.Verify(x => x.ReadResponseAsync<string>(response));
    }

    [Fact]
    public async void CallsOnePatch() {

      // Arrange
      var httpServiceMock = CreateHttpServiceMock(out HttpResponseMessage response);
      var requestBuilderMock = CreateRequestBuilderMock();
      var responseReaderMock = new Mock<IResponseReader>();
      var sut = new PaypalRestApiClient(httpServiceMock.Object, requestBuilderMock.Object, responseReaderMock.Object);

      var patches = new [] {
        new Definitions.Patch {
          Op = "testOp",
          Path = "testPath",
          Value = "testValue"
        }
      };
      string apiPath = "http://example.com/";

      // Act
      await sut.Patch(patches, apiPath);

      // Assert
      httpServiceMock.Verify(x => x.SendAndReturnResponseAsync(It.Is<HttpRequestMessage>(request => HasValues(request, HttpMethod.Patch, patches, apiPath).Result)));
    }

    [Fact]
    public async void CallsTwoPatches() {

      // Arrange
      var httpServiceMock = CreateHttpServiceMock(out HttpResponseMessage response);
      var requestBuilderMock = CreateRequestBuilderMock();
      var responseReaderMock = new Mock<IResponseReader>();
      var sut = new PaypalRestApiClient(httpServiceMock.Object, requestBuilderMock.Object, responseReaderMock.Object);

      var patches = new [] {
        new Definitions.Patch {
          Op = "testOp1",
          Path = "testPath1",
          Value = "testValue1"
        },
        new Definitions.Patch {
          Op = "testOp2",
          Path = "testPath2",
          Value = "testValue2"
        }
      };
      string apiPath = "http://example.com/";

      // Act
      await sut.Patch(patches, apiPath);

      // Assert
      httpServiceMock.Verify(x => x.SendAndReturnResponseAsync(It.Is<HttpRequestMessage>(request => HasValues(request, HttpMethod.Patch, patches, apiPath).Result)));
    }

    private async Task<bool> HasValues(HttpRequestMessage request, HttpMethod method, object body, string url) {

      return request.Method == method &&
        request.RequestUri == new Uri(url) &&
        await request.Content.ReadAsStringAsync() == Serialize(body);
    }

    private Mock<IHttpService> CreateHttpServiceMock(out HttpResponseMessage response) {

      response = new HttpResponseMessage();
      var httpServiceMock = new Mock<IHttpService>();

      httpServiceMock
       .Setup(x => x.SendAndReturnResponseAsync(It.IsAny<HttpRequestMessage>()))
       .Returns(Task.FromResult(response));

      return httpServiceMock;
    }

    private Mock<IRequestBuilder> CreateRequestBuilderMock() {

      var mock = new Mock<IRequestBuilder>();

      mock
        .Setup(x => x.CreateRequestAsync(It.IsAny<HttpMethod>(), It.IsAny<object>(), It.IsAny<string>()))
        .Returns<HttpMethod, object, string>((method, body, url) => {
          return Task.FromResult(new HttpRequestMessage {
            Method = method,
            Content = new StringContent(Serialize(body)),
            RequestUri = new Uri(url)
          });
        });

      return mock;
    }

    private string Serialize(object input) {

      return input == null ? string.Empty : JsonConvert.SerializeObject(input);
    }
  }
}
