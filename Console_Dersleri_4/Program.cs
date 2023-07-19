using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Console_Dersleri_4.Classes;
using Console_Dersleri_4.Model;

namespace Console_Dersleri_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleDbProjeEntities db = new ConsoleDbProjeEntities();
            GetCurrency getCurency = new GetCurrency();
            Sale sale = new Sale();

            void CurrencyList()
            {
                Console.WriteLine();
                Console.WriteLine("Döviz Listesi");
                Console.WriteLine();
                var values = db.TblCurrency.ToList();
                foreach (var item in values)
                {
                    Console.WriteLine(item.ID + " " + item.CurrecyName);
                }
            }

            void CurrentCurrency()
            {
                Console.WriteLine();
                Console.WriteLine("Güncel Kur Listesi");
                Console.WriteLine();
                var values = db.TblCurrencyValue.ToList();
                foreach (var item in values)
                {
                    Console.WriteLine("Döviz: " + item.TblCurrency.CurrecyName + "Alış: "+ item.CurrencyBuying + "Satış: " + item.CurrencySelling);
                }
            }

            void GetCurrencyClass()
            {
                getCurency.SaveCurrencyDollar();
                getCurency.SaveCurrencyEuro();
                getCurency.SaveCurrencyPound();
            }

            Console.WriteLine("Döviz işlemlerine hoşgeldiniz");
            Console.WriteLine();
            Console.WriteLine("Mevcut Kullanıcı: Admin" + "     Tarih:" + DateTime.Now.ToShortDateString());
            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz ");
            Console.WriteLine();
            Console.WriteLine("1-Döviz Listesi");
            Console.WriteLine("2-Güncel Kurlar");
            Console.WriteLine("3-Satış Yap");
            Console.WriteLine("4-Müşterilere Yapılan Satış Hareketleri");
            Console.WriteLine("5-Müşterilerden Alınan Satış Hareketleri");
            Console.WriteLine("6-Kurları Veri Tabanına Kaydet");
            Console.WriteLine("7-Yardım");
            Console.WriteLine("8-Çıkış Yap");
            Console.WriteLine();
            Console.WriteLine("İşlem Numarası");

            string choose;
            choose = Console.ReadLine();

            if (choose == "1" || choose == "01")
            {
                CurrencyList();
            }
            if (choose == "2" || choose == "02")
            {
                CurrentCurrency();
            }
            if (choose == "3" || choose == "03")
            {
                Console.WriteLine();
                Console.Write("Müşteri Adı: ");
                string customerName = Console.ReadLine();
                Console.Write("Müşteri Soyadı: ");
                string customerSurname = Console.ReadLine();
                Console.Write("Döviz Kodu: ");
                int currencyCode =int.Parse(Console.ReadLine());
                Console.Write("İşlem Türü: ");
                string operationType = Console.ReadLine();
                Console.Write("Güncel Kur Değeri: ");
                decimal currentValue =decimal.Parse(Console.ReadLine());
                Console.Write("Alınacak Tutar: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.Write("Toplam Ücret: ");
                decimal totalAmount = decimal.Parse(Console.ReadLine());

                sale.MakeSale(customerName, customerSurname, currencyCode, operationType, currentValue, amount, totalAmount);
            }
            if (choose == "4" || choose == "04")
            {
                SaleOperation saleOperation = new SaleOperation();
                saleOperation.CustomerSaleOperationAlis();
            }
            if (choose == "5" || choose == "05")
            {
                SaleOperation saleOperation = new SaleOperation();
                saleOperation.CustomerSaleOperationSatis();
            }
            if (choose == "6" || choose == "06")
            {
                GetCurrencyClass();
                Console.WriteLine("Dövizler başarılı bir şekilde veri tabanına kaydedildi");
            }
            if (choose == "7" || choose == "07")
            {
                Console.WriteLine("Tüm sorularınız için mail@mail.com adresinden bize ulaşabilirsiniz");
            }
            if (choose == "8" || choose == "08")
            {
                Environment.Exit(1);
            }

            Console.ReadLine();
        }
    }
}
