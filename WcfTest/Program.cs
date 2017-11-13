using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;
using System.ServiceModel.Channels;
using System.Net;
using System.Runtime.Serialization;

namespace WcfTest
{
    class Program
    {

        static void Main0(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(HomeService), new Uri("http://127.0.0.1:1920"));

            host.AddServiceEndpoint(typeof(IHomeService), new BasicHttpBinding(), "HomeServie");

            host.AddServiceEndpoint(typeof(IHomeService), new NetTcpBinding(), "net.tcp://127.0.0.1:1921/HomeServieTcp");

            host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });

            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            host.Open();

            Console.WriteLine("Home服务开启。。。。");
            Console.Read();
        }

        static void Main(string[] args)
        {
            //第一个： 这是Home服务
            ServiceHost host = new ServiceHost(typeof(HomeService), new Uri("http://127.0.0.1:1920"));
            host.AddServiceEndpoint(typeof(IHomeService), new BasicHttpBinding(), "HomeServie");
            host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            host.Open();

            Console.WriteLine("Home服务开启。。。。");

            //第一个： 这是Fly服务
            var host2 = new ServiceHost(typeof(FlyService), new Uri("http://127.0.0.1:1930"));
            host2.AddServiceEndpoint(typeof(IFlyService), new BasicHttpBinding(), "FlyServie");
            host2.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
            host2.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            host2.Open();

            Console.WriteLine("Fly服务开启。。。。");

            Console.Read();
        }

        static void Main2(string[] args)
        {


            //第一个： 这是Home服务
            ServiceHost host = new ServiceHost(typeof(HomeService), new Uri("net.tcp://127.0.0.1:1920"));
            host.AddServiceEndpoint(typeof(IHomeService), new NetTcpBinding() { PortSharingEnabled = true }, "HomeServie");
            host.Open();

            Console.WriteLine("Home服务开启。。。。");

            //第一个： 这是Fly服务
            var host2 = new ServiceHost(typeof(FlyService), new Uri("net.tcp://127.0.0.1:1920"));
            host2.AddServiceEndpoint(typeof(IFlyService), new NetTcpBinding() { PortSharingEnabled = true }, "FlyServie");
            host2.Open();

            Console.WriteLine("Fly服务开启。。。。");

            Console.Read();
        }

    }


}
