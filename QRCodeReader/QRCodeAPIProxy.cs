using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QRCodeReader
{
    public class QRCodeAPIProxy
    {
        private readonly string _qrCodeApiReadUrl = "http://api.qrserver.com/v1/read-qr-code/?file=";

        private string GetQREncodedTextFromJsonString(string jsonQrText)
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(jsonQrText));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    // "data" is the JSON field that contains the QR-encoded text
                    if (reader.Value.ToString() == "data")
                    {
                        // next token value should be the QR-encoded text
                        reader.Read();
                        return reader.Value.ToString();
                    }
                }
            }
            return string.Empty;
        }

        public async Task<string> ObtainQRCodeText(string qrCodeFilePath)
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileContent = QRCodeFileUtils.GetFileContent(qrCodeFilePath);
                    var qrCodefileName = Path.GetFileName(qrCodeFilePath);
                    content.Add(new StreamContent(new MemoryStream(fileContent)), "file", qrCodefileName);

                    using (var response = await httpClient.PostAsync(_qrCodeApiReadUrl, content))
                    {
                        response.EnsureSuccessStatusCode();
                        var stringContent = await response.Content.ReadAsStringAsync();
                        return GetQREncodedTextFromJsonString(stringContent);
                    }
                }
            }
        }
    }
}
