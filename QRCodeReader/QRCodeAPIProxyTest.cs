using System;
using System.IO;
using NUnit.Framework;

namespace QRCodeReader
{
    [TestFixture]
    public class QRCodeAPIProxyTest
    {

        [Test]
        public void Given_EmptyFilePath_When_ObtainQRCodeText_Then_ArgumentExceptionThrown()
        {
            Assert.That(async () =>
                                    {
                                        var qrAPIProxy = new QRCodeAPIProxy();
                                        var result = await qrAPIProxy.ObtainQRCodeText(string.Empty);
                                    },
                        Throws.ArgumentException);
        }

        [Test]
        public void Given_IncorrectFileName_When_ObtainQRCodeText_Then_ExceptionThrown()
        {
            Assert.That(async () =>
                        {
                            var qrFileFolder = QRCodeFileUtils.GetQrCodeFileExampleFileFolder();
                            // Add current time minutes to existing file name in order to build inexisting file name
                            var qrFileName = DateTime.Now.Minute + QRCodeFileUtils.EXAMPLE_QR_CODE_FILE_NAME;
                            var qrFilePath = Path.Combine(qrFileFolder, qrFileName);
                            var qrAPIProxy = new QRCodeAPIProxy();
                            var result = await qrAPIProxy.ObtainQRCodeText(qrFilePath);
                        },
                        Throws.Exception);
        }

        [Test]
        public async System.Threading.Tasks.Task Given_ExistingTestFileName_When_ObtainQRCodeText_Then_ExpectedQRCodeTextReturnedAsync()
        {
            //Given
            var qrFileFolder = QRCodeFileUtils.GetQrCodeFileExampleFileFolder();
            var qrFileName = QRCodeFileUtils.EXAMPLE_QR_CODE_FILE_NAME;
            var qrFilePath = Path.Combine(qrFileFolder, qrFileName);
            var qrAPIProxy = new QRCodeAPIProxy();

            //When
            var qrCodeText = await qrAPIProxy.ObtainQRCodeText(qrFilePath);

            //Then
            Assert.AreEqual(QRCodeFileUtils.QR_ENCODED_TEXT, qrCodeText, "API should return text value encoded in QR code file.");
        }
    }
}
