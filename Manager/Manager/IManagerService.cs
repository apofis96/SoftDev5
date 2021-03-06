﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Manager
{
    [ServiceContract]
    public interface IManagerService
    {
        [OperationContract]
        void TestConnection(string str);

        [OperationContract]
        bool CompileOrder(string name, int amount);
    }
}
