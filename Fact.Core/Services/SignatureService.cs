using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Linq;

namespace Fact.Core.Services;

public interface ISignatureService
{
    string SignXml(string xml, X509Certificate2 certificate);
}

public class SignatureService : ISignatureService
{
    public string SignXml(string xml, X509Certificate2 certificate)
    {
        var xmlDoc = new XmlDocument { PreserveWhitespace = true };
        xmlDoc.LoadXml(xml);

        var signatureNode = xmlDoc.SelectSingleNode(
            "//*[local-name()='ExtensionContent']");

        if (signatureNode == null)
            throw new InvalidOperationException("ExtensionContent node not found");

        var rsaKey = certificate.GetRSAPrivateKey()
            ?? throw new InvalidOperationException("No RSA private key found in certificate");

        var signedXml = new SignedXml(xmlDoc)
        {
            SigningKey = rsaKey
        };

        signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigC14NTransformUrl;
        signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;

        var reference = new Reference { Uri = "" };
        reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
        reference.AddTransform(new XmlDsigC14NTransform());
        reference.DigestMethod = SignedXml.XmlDsigSHA1Url;
        signedXml.AddReference(reference);

        var keyInfo = new KeyInfo();
        keyInfo.AddClause(new KeyInfoX509Data(certificate));
        signedXml.KeyInfo = keyInfo;

        signedXml.ComputeSignature();
        var signatureElement = signedXml.GetXml();

        var importedSignature = xmlDoc.ImportNode(signatureElement, true);
        signatureNode.AppendChild(importedSignature);

        return xmlDoc.OuterXml;
    }
}
