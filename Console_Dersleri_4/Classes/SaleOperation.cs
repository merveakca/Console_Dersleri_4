using Console_Dersleri_4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Dersleri_4.Classes
{
    public class SaleOperation
    {
        public void CustomerSaleOperationAlis()
        {
            ConsoleDbProjeEntities db = new ConsoleDbProjeEntities();
            var values = db.TblOperation.Where(x=>x.OperationType=="alış").ToList();
            foreach (var item in values)
            {
                Console.WriteLine("ID: " + item.ID + "Müşteri: " + item.CustomerName + " " + item.CustomerSurname + "Döviz: " + item.TblCurrency.CurrecyName + "işlem Türü: " + item.OperationType + "Kur Birim Tutarı: " + item.CurrentValue + "Alınan Tutar: " + item.Amount + "Toplam Tutar: " + item.TotalPrice);
            }
        }
        public void CustomerSaleOperationSatis()
        {
            ConsoleDbProjeEntities db = new ConsoleDbProjeEntities();
            var values = db.TblOperation.Where(x => x.OperationType == "satış").ToList();
            foreach (var item in values)
            {
                Console.WriteLine("ID: " + item.ID + "Müşteri: " + item.CustomerName + " " + item.CustomerSurname + "Döviz: " + item.TblCurrency.CurrecyName + "işlem Türü: " + item.OperationType + "Kur Birim Tutarı: " + item.CurrentValue + "Alınan Tutar: " + item.Amount + "Toplam Tutar: " + item.TotalPrice);
            }
        }
    }
}
