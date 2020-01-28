using System.ServiceModel;
using System.ServiceModel.Web;

namespace QRCodeReaderAPI
{
    [ServiceContract]
    public interface IQRService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "qrCodeText/{qrFilePath}")]
        [return: MessageParameter(Name = "QrText")]
        string GetQrCodeText(string qrFilePath);
    }
}
