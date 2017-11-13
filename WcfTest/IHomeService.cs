using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WcfTest
{
    [ServiceContract]
    public interface IHomeService
    { 
        [OperationContract]
        Student Update();

      
    }


    [ServiceContract]
    public interface IFlyService
    {
        [OperationContract]
        Student Fly(Student stu);
    }
}
