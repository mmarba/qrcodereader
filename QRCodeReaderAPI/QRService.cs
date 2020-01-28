using System.ServiceModel;

namespace QRCodeReaderAPI
{
    public class QRService : IQRService
    {
        [return: MessageParameter(Name = "QrText")]
        public string GetQrCodeText(string qrFilePath)
        {
            var qrCodeApiProxy = new QRCodeReader.QRCodeAPIProxy();
            var qrCodeText = qrCodeApiProxy.ObtainQRCodeText(qrFilePath).ToString();
            return qrCodeText;
        }
    }
}
