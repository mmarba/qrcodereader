INTRODUCTION:
=============

This implementation of the QR code reader has been done in C# with Visual Studio 17.
It is contained in the solution QRCodeReader.sln, which includes two projects:

- QRCodeReader:
  This is a .Net Core class library with .Net framework version 4.6.1
  It contains class QRCodeAPIProxy, which has a method ObtainQRCodeText that gets a QR code file path string as a parameter 
  and actually performs the call to the QR Code REST API available on the internet that has been provided as part of the exercise 
  to extract the text encoded in the QR files. It returns a string with the QR text.
  It contains also class QRCodeFileUtils, with a few useful auxiliary methods.
  There's also the test class QRCodeAPIProxyTest, with some tests that verify the QRCodeAPIProxy class.
  A folder QRCodeFiles is also included. It contains the test QR code file that is used by the test class to test the happy path.
  Also, folder packages contains the binaries of the nuget packages needed as dependencies of the project.
  
  Dependencies: .Net framework v4.6.1, Newtonsoft.Json v12.0.3, NUnit v3.12.0, Nunit3TestAdapter v3.16.1
  
  
  - QRCodeReaderAPI:
   This is a small .Net Framework console application with a very basic implementation of a REST API service that exposes the
   functionality of the QRCodeReader API proxy mentioned above.
   
   
    
