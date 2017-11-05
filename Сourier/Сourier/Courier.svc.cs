using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Сourier
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : ICourier
    {
        int id = 0;
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
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

        public void TakeGoods(int id)
        {
            this.id = id;
            //заглушка обращения к складу, который по идее может одать композитный тип, в котором есть ID, Name, Cost(пока равен нулю), IsDelivered(false)
            int i = CostOfGoods(id);

        }

        private int CostOfGoods(int id)
        {
            //обращение к бухалтеру за уточнением стоимости
            return 5;
        }

        public int DeliverGoods()
        {
            return id;
        }

       public void SuccessOfDeliver(int id, bool flag)
        {
            if (flag && id == this.id)
            {
                //Извещаэм бухалтерию о саксесе
            }
        }
    }
}
