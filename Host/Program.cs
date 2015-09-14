using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
using System.ServiceModel;
using Services;
using Contracts;


namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(HelloService));

            #region 创建服务安全验证相关行为
            var serviceCredentials = new ServiceCredentials();
            //设置服务数字证书，用于加密数据
            serviceCredentials.ServiceCertificate.Certificate = new X509Certificate2(Properties.Resources.KangCity, "", X509KeyStorageFlags.PersistKeySet);
            //设置客户端数字证书的有效性验证模式
            serviceCredentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            #endregion

            host.Description.Behaviors.Add(serviceCredentials);


            host.Open();
            Console.WriteLine("Service is ready");
            Console.Read();

            //using (ServiceHost host =
            //    new ServiceHost(
            //        typeof(HelloService),
            //        new Uri("http://localhost:8080/HelloService")))
            //{

            //    var binding = new WSHttpBinding();
            //    binding.Security.Mode = SecurityMode.Message;
            //    binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

                

            //    host.AddServiceEndpoint(
            //        typeof(IHelloService).FullName,
            //        binding,
            //        "");

            //    host.Open();
            //    Console.WriteLine("Service is ready");
            //    Console.Read();
            //}

        }
    }
}
