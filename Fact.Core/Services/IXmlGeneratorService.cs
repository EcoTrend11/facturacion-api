using System.Xml.Linq;
using Fact.Core.Models;

namespace Fact.Core.Services;

public interface IXmlGeneratorService
{
    XDocument GenerateInvoice(InvoiceRequest request);
}
