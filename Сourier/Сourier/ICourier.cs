using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Сourier
{
    [ServiceContract]
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    public interface ICourier
    {


        [OperationContract]
        void TakeGoods(int id);

        [OperationContract]
        void TestConnect(string str);

        // TODO: Добавьте здесь операции служб
    }


    // Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
    [DataContract]
    public class Order
    {
        public Order(int id, string name, int Quantity)
        {
            this.ID = id;
            this.PoductName = name;
            this.Quantity = Quantity;
        }
        [DataMember]
        public int ID { get; private set; }

        [DataMember]
        public string PoductName { get; private set; }

        [DataMember]
        public int Quantity { get; private set; }

        [DataMember]
        public int Price { get; set; }
    }
}
