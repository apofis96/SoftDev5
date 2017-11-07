using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace Сourier
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : ICourier
    {


        public void TakeGoods(int id)
        {

            //заглушка обращения к складу, который по идее может одать композитный тип, в котором есть ID, Name, Cost(пока равен нулю), IsDelivered(false)
            using (StorageReference.StorageClient storage = new StorageReference.StorageClient())
            {
                StorageReference.Order order = storage.GetDispatchedProducts(id);
                if (!(order is null))
                {
                    using (AccounterReference.AccountantClient account = new AccounterReference.AccountantClient())
                    {
                        order.Price = account.GetPrice(order.ID, order.Quantity);
                        account.LogResult(order.PoductName, order.Quantity, true);
                    }

                }
            }

        }

        bool Deliver(StorageReference.Order order)
        {
            try
            {
                string directory = @"C:\Logs";
                FileStream stream = new FileStream(Path.Combine(directory, order.PoductName + ".xml"), FileMode.Create);
                XmlSerializer xml = new XmlSerializer(typeof(StorageReference.Order));
                xml.Serialize(stream, order);
                stream.Close();
                return true;
            }
            catch (Exception e) {
                TestConnect(e.Message);
                return false;
            }

        }


        public void TestConnect(string str)
        {
            string fileName = "Connect.log";
            string directory = @"C:\Logs";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (StreamWriter writer = new StreamWriter(new FileStream(Path.Combine(directory, fileName), FileMode.Append)))
            {
              
                    writer.WriteLine(DateTime.Now + " KEKOS: "+ str);
              

            }

        }
    }
}
