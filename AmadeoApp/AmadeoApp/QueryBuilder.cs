using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeoApp
{
    internal class QueryBuilder
    {
      public String ResetLock()
        {
            return "UPDATE operatorzy set boperator='---' WHERE NOT boperator='---'";
        }
        public String UncheckBuffor()
        {
            return "UPDATE stan_na_dzien set odebrano=1 WHERE odebrano=0";
        }

        public String FiscalizationReceipt()
        {
            var sb = new StringBuilder();
            String[] idList = GetIdReceipt();
            sb.Append("UPDATE tabelazakupy set fiskalny=1 WHERE fiskalny=0 and numer_wew IN(");
            for(int i = 0; i < idList.Length; i++)
            {
                sb.Append(idList[i]+",");
            }
            sb.Append(")");
            return sb.ToString();
            //usunac przecinek po ostatniej petli
        }
        private String[] GetIdReceipt()
        {
            String[] stringArray = System.IO.File.ReadAllLines(@"C:\Amadeo_helpdesk\AmadeoApp\IdFiles\IdReceiptList.txt");
            return stringArray;

        }
        private String[] GetIdMerchandise()
        {
            String[] stringArray = System.IO.File.ReadAllLines(@"C:\Amadeo_helpdesk\AmadeoApp\IdFiles\IdMerchandise.txt");
            return stringArray;

        }





    }
}
