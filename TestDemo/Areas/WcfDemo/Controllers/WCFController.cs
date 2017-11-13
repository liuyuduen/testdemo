using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using TestDemo.TestService; 

namespace TestDemo.Areas.WcfDemo.Controllers
{
    public class WCFController : Controller
    {
        //
        // GET: /WcfDemo/WCF/
        public ActionResult Index()
        {
            //TestWCF();
            Update();
            return View();
        }
        public void TestWCF()
        {


            //HomeServiceClient tcp = new HomeServiceClient();

            //var s = tcp.GetLength("WCFService_TCP");

            //var str = tcp.GetStr("WCFService_TCP");

            //TestServiceClient tes = new TestServiceClient();
            //var password = tes.getPassword();

            //Response.Write(string.Format("tcp长度为:{0}\r\n", s));
            //Response.Write(string.Format("str:{0}\r\n", str));
            //Response.Write(string.Format("str:{0}\r\n", password));
            
            //Response.End();
        }

        public void Update() {



            BasicHttpBinding bingding = new BasicHttpBinding();

            BindingParameterCollection param = new BindingParameterCollection();

            var u = new Test() { str = "王八蛋" };

            Message request = Message.CreateMessage(MessageVersion.Soap11, "http://10.13.70.94:19200/HomeService/Update", u);

            //在header中追加ip信息
            request.Headers.Add(MessageHeader.CreateHeader("ip", string.Empty, Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString()));
            request.Headers.Add(MessageHeader.CreateHeader("currenttime", string.Empty, DateTime.Now));

            IChannelFactory<IRequestChannel> factory = bingding.BuildChannelFactory<IRequestChannel>(param);

            factory.Open();

            IRequestChannel channel = factory.CreateChannel(new EndpointAddress("http://10.13.70.94:19200/HomeService"));

            channel.Open();

            var result = channel.Request(request);

            channel.Close();

            factory.Close();
        }
    }
    [DataContract(Namespace = "http://10.13.70.94:19200/HomeService", Name = "Update")]
    class Test
    {
        [DataMember]
        public string str { get; set; }
    }
}