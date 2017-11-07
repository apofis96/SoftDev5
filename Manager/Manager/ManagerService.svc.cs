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
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Product GetDataUsingDataContract(Product composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool CompileOrder(string name, int amount)
        {

        }
    }
}
