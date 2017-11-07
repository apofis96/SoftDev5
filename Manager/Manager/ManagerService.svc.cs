using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Manager
{
    public class ManagerService : IManagerService
    {
        public void TestConnection(string str)
        {
            string fileName = "Connect.log";
            string directory = @"C:\Logs";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (StreamWriter writer = new StreamWriter(new FileStream(Path.Combine(directory, fileName), FileMode.Append)))
            {

                writer.WriteLine(DateTime.Now + " SEASHELL: " + str);
            }
        }

        public bool CompileOrder(string name, int amount)
        {
            bool success;
            int orderID = 0;
            using (StorageServiceReference.StorageClient storage = new StorageServiceReference.StorageClient())
            {
                if(storage.IsAvailable(name, amount))
                {
                    orderID = storage.Dispatch(name, amount);
                    using(CourierServiceReference.CourierClient courier = new CourierServiceReference.CourierClient())
                    {
                        courier.TakeGoods(orderID);
                    }
                    success =  true;
                }
                else success = false;
            }
            Log(success, name, amount, orderID);
            return success;
        }

        public void Log(bool success, string name, int amount, int id)
        {
            string path = @"C:\Logs\Manager.log";
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path)) { }
            }
            using (StreamWriter log = new StreamWriter(new FileStream(path, FileMode.Append)))
            {
                log.WriteLine($"{DateTime.Now} : new order #{id} ({name}, {amount} pcs) has" + 
                    (success ? "" : " not") + " been processed.");
            }
        }
    }
}
