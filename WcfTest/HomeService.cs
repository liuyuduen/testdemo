using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Net;
using System.ServiceModel.Channels;

namespace WcfTest
{
    public class HomeService : IHomeService
    {

        public Student Update()
        {

            return new Student() { Name = "一线码农" };
        }

    }

    public class FlyService : IFlyService
    {
        public Student Fly(Student stu)
        {
            return new Student() { Name = "超级码农" };
        }
    }
}
