using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using System.Text;
using System.ServiceModel;
using Contracts;
using System.ServiceModel.Description;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var binding = new NetTcpBinding();

            //Encrypt, can check with Tcp Trace
            binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
            //Not encrypt
            //binding.Security.Mode = SecurityMode.None;

            var factory = new ChannelFactory<IHelloService>(
                binding, new EndpointAddress(new Uri("net.tcp://localhost:8080/HelloService"),new DnsEndpointIdentity("KangCity")));

            factory.Credentials.ClientCertificate.Certificate = new X509Certificate2(Properties.Resources.KangCity, "", X509KeyStorageFlags.PersistKeySet);
            factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;

            //Add listening port only at client.
            Uri tcpTraceUri = new Uri("net.tcp://localhost:8081/HelloService");
            factory.Endpoint.Behaviors.Add(new ClientViaBehavior(tcpTraceUri));

            var proxy = factory.CreateChannel();
            var result = proxy.Greeting("WCF");
            Console.WriteLine(result);

            Console.Read();

        }
    }
}
