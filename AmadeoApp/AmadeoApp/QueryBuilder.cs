using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeoApp
{
    //SPEXORDS: to moze w sumie statyczna klasa, nazywa sie niby query builder ale ona nic nie buduje tylko zawiera zbior querek
    public static class QueryBuilder
    {
       //reset operator blokady
      public static string ResetLock()
        {
            return "UPDATE operatorzy set boperator='---' WHERE NOT boperator='---'";
        }
        //bufor czyszczenie 13 baz
        public static string UncheckBuffor()
        {
            return "UPDATE stan_na_dzien set odebrano=1 WHERE odebrano=0";
        }
        //fiskalizowanie paragonów
        public static string FiscalizationReceipt()
        {
            var sb = new StringBuilder();
            string[] idList = GetIds(@"C:\amadeo_helpdesk\AmadeoHelper\AmadeoApp\IdFiles\IdReceiptList.txt");
            sb.Append("UPDATE tabelazakupy set fiskalny=1 WHERE fiskalny=0 and numer_wew IN(");
            sb.Append(String.Join(",", idList));
            //for(int i = 0; i < idList.Length; i++)
            //{
            //    sb.Append(idList[i]+",");
            //}
            sb.Append(")");
            return sb.ToString();         
        }

        public static string UnlockSpecialPrice()
        {
            var sb = new StringBuilder();
            var idList = GetIds(@"C:\amadeo_helpdesk\AmadeoHelper\AmadeoApp\IdFiles\IdMerchandise.txt");
            sb.Append("UPDATE kartotekatowaru set objety_csp=0 where objety_csp=1 and id IN(");
            sb.Append(String.Join(",", idList));
            sb.Append(")");
           return sb.ToString();

        }
        //Ajka ceny detalicznie
        public static string  ChangeRetailPrice(string dateInvoice, string correctPrice, string numberInvoice)
        {
            var sb =$"UPDATE tabelazakupy set detbru='{correctPrice}', bezrab='{correctPrice}' where numer_wew='{numberInvoice}'" +
                $" and data_z='{dateInvoice}'";
            return sb;
        }

        //SPEXORDS: zmienilbym nazwe tej metody ona po prostu czyta z pliku stringi linia po linii i zwraca to jako array
        //(moznaby to wyeksportowac do jakies innej klasy np. Utility )
        public static string[] GetIds(string path)
        {
            string[] stringArray = System.IO.File.ReadAllLines(path);
            return stringArray;
        }
        





    }
}
