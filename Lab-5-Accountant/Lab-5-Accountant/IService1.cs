using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab_5_Accountant
{

    [ServiceContract]
    public interface IAccountant
    {

        [OperationContract]
        int GetPrice(int productID, int quantity);

        [OperationContract]
        void LogResult(string productName, int quantity, bool success);

    }

}
