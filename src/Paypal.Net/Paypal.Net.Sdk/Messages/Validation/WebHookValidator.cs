using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Paypal.Net.Sdk.Messages.Validation {
  
  // Original source for this class can be found at Paypal's archived repository https://github.com/paypal/PayPal-NET-SDK
  public class WebHookValidator {

    private readonly CertificateManager _certificateManager;

    /// <summary>
    /// PayPal webhook transmission ID HTTP request header
    /// </summary>
    public const string PayPalTransmissionIdHeader = "PAYPAL-TRANSMISSION-ID";

    /// <summary>
    /// PayPal webhook transmission time HTTP request header
    /// </summary>
    public const string PayPalTransmissionTimeHeader = "PAYPAL-TRANSMISSION-TIME";

    /// <summary>
    /// PayPal webhook transmission signature HTTP request header
    /// </summary>
    public const string PayPalTransmissionSignatureHeader = "PAYPAL-TRANSMISSION-SIG";

    /// <summary>
    /// PayPal webhook certificate URL HTTP request header
    /// </summary>
    public const string PayPalCertificateUrlHeader = "PAYPAL-CERT-URL";

    /// <summary>
    /// PayPal webhook authentication algorithm HTTP request header
    /// </summary>
    public const string PayPalAuthAlgorithmHeader = "PAYPAL-AUTH-ALGO";

    public WebHookValidator(CertificateManager certificateManager) {

      _certificateManager = certificateManager;
    }

    public bool ValidateReceivedEvent(IHeaderDictionary requestHeaders, string requestBody, string webhookId) {

      bool isValid = false;

      // Check the headers and ensure all the correct information is present.
      var transmissionId = requestHeaders[PayPalTransmissionIdHeader];
      var transmissionTimestamp = requestHeaders[PayPalTransmissionTimeHeader];
      var signature = requestHeaders[PayPalTransmissionSignatureHeader];
      var certUrl = requestHeaders[PayPalCertificateUrlHeader];
      var authAlgorithm = requestHeaders[PayPalAuthAlgorithmHeader];

      // Convert the provided auth alrogithm header into a known hash alrogithm name.
      var hashAlgorithm = ConvertAuthAlgorithmHeaderToHashAlgorithmName(authAlgorithm);

      // Calculate a CRC32 checksum using the request body.
      var crc32 = Crc32.ComputeChecksum(requestBody);

      // Generate the expected signature.
      var expectedSignature = string.Format("{0}|{1}|{2}|{3}", transmissionId, transmissionTimestamp, webhookId, crc32);
      var expectedSignatureBytes = Encoding.UTF8.GetBytes(expectedSignature);

      // Get the cert from the cache and load the trusted certificate.
      var x509CertificateCollection = _certificateManager.GetCertificatesFromUrl(certUrl);
      var trustedX509Certificate = _certificateManager.GetTrustedCertificateFromFile();

      // Validate the certificate chain.
      isValid = _certificateManager.ValidateCertificateChain(trustedX509Certificate, x509CertificateCollection);

      // Verify the received signature matches the expected signature.
      if (isValid) {

        // Paypal SDK code has this wrong!
        //var rsa = x509CertificateCollection[0].PublicKey.Key as RSACryptoServiceProvider;
        var rsa = x509CertificateCollection[0].PublicKey.Key as RSACng;
        var signatureBytes = Convert.FromBase64String(signature);

        isValid = rsa.VerifyData(expectedSignatureBytes, signatureBytes, new HashAlgorithmName(hashAlgorithm), RSASignaturePadding.Pkcs1);
      }


      return isValid;
    }

    internal static string ConvertAuthAlgorithmHeaderToHashAlgorithmName(string authAlgorithmHeader)
    {
      // The PAYPAL-AUTH-ALGO header will be specified in a name recognized
      // by Java's java.security.Signature class.
      //
      // Currently, only RSA is supported, and the hashing algorithm will
      // be derived with the following assumption on the format:
      //   "<hash_algorithm>withRSA"
      var token = "withRSA";
      if (authAlgorithmHeader.EndsWith(token))
      {
        return authAlgorithmHeader.Split(new string[] { token }, StringSplitOptions.None)[0];
      }

      // At this point, we've encountered an unsupported algorithm.
      throw new Exception($"Unable to map {authAlgorithmHeader} to a known hash algorithm.");
    }
  }

}