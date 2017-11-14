using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab_5_Accountant
{
     [ServiceBehavior(
    ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single)]
    public class AccountantService : IAccountant
    {
        int money = 0;

        //ціна за одиницю товару
        Dictionary<int, int> priceList = new Dictionary<int, int>
        {
            [1] = 20,
            [2] = 10,
            [3] = 45,
            [4] = 33,
            [5] = 16,
            [6] = 17
        };



        //отримати загальну ціну на товар
        public int GetPrice(int productID, int quantity)
        {
            if (priceList.ContainsKey(productID))
                return priceList[productID] * quantity;
            return 0;
        }


        //звіт про результат доставки
        public void LogResult(int orderID, int price, string productName, int quantity, bool success)
        {
            money += price;
            Log(orderID, price, productName, quantity, success);
        }



        private void Log(int orderID, int price, string productName, int quantity, bool success)
        {
            string fileName = "Report.log";
            string directory = @"C:\Logs";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (StreamWriter writer = new StreamWriter(new FileStream(Path.Combine(directory, fileName), FileMode.Append)))
            {
                if (success)
                {
                    writer.WriteLine(DateTime.Now + "  Замовлення id={0}, Товар доставлено: {1}, {2} од., ціна - {3} грн., Всього зароблено грошей: {4}", orderID, productName, quantity, price, money);
                }
                else
                {
                    writer.WriteLine(DateTime.Now + "  Замовлення id={0}, Доставка НЕ відбулась: {1}, {2} од., ціна - {3} грн.", orderID, productName, quantity, price);
                }
            }
        }

    }
}
