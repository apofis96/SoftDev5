using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Manager
{
    public class ManagerService : IManagerService
    {
        public bool CompileOrder(string name, int amount)
        {
            return true;
        }

        public void RequestReceiving()
        {

        }

        public void RequestDispatching(string name, int amount)
        {

        }
    }
}
