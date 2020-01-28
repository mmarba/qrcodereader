using System;
using System.IO;
using System.Reflection;

namespace QRCodeReader
{
    public static class QRCodeFileUtils
    {
        public const string QR_ENCODED_TEXT = "MoisesExample";
        public const string EXAMPLE_QR_CODE_FILE_NAME = QR_ENCODED_TEXT + ".png";

        public static byte[] GetFileContent(string filePath)
        {
            var fileContent = File.ReadAllBytes(filePath);
            return fileContent;
        }

        public static string GetQrCodeFileExampleFileFolder()
        {
            var assemblyFilePath = Assembly.GetExecutingAssembly().CodeBase;
            var assemblyFilePathUri = new UriBuilder(assemblyFilePath);
            string folder = Uri.UnescapeDataString(assemblyFilePathUri.Path);
            string completeFolder = Path.GetDirectoryName(folder) + @"\..\..\QRCodeFiles\";
            return completeFolder;
        }
    }
}
