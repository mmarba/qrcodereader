using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
namespace QRCodeReaderAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost hostWeb = new WebServiceHost(typeof(QRService));
            ServiceEndpoint ep = hostWeb.AddServiceEndpoint(typeof(IQRService), new WebHttpBinding(), "");
            ServiceDebugBehavior stp = hostWeb.Description.Behaviors.Find<ServiceDebugBehavior>();
            stp.HttpHelpPageEnabled = false;
            hostWeb.Open();
            Console.WriteLine("Service Host started @ " + DateTime.Now.ToString()); Console.Read();
        }
    }
}

