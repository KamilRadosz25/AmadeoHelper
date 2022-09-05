using System;



namespace AmadeoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Amadeo Helpdesk");
            Console.WriteLine("Witaj w programie helpdeskowym PIM. ");
            Console.WriteLine("Jaką opcje chcesz wykonać");
            Console.WriteLine("Komendy wpisuj nazwa klienta . funkcja");
            Console.WriteLine("Salami fiskalizowanie paragonów - Salami --FP (Umieść ID po enterze w pliku: IdReceiptList.txt)");
            Console.WriteLine("Ajka zmiana ceny detalicznej faktury - Ajka --ChangePrice");
            Console.WriteLine("Market punkt centrala sciąganie cen objetych ceną specjalną - MP_CENTRALA --UncheckSpecialPrice");
            Console.WriteLine("Resetowanie blokady operatorów na analizy centralne - MP_CENTRALA --ResetLock");
            Console.WriteLine("Odświeżanie buforu cotygodniowe na wszystkie sklepy MP --UncheckBuffor");
            string input = Console.ReadLine();
            switch (input)
            {
                case "Salami --FP":
                        break;
                case "Ajka --ChangePrice":
                    break;
                case "MP_CENTRALA --UncheckSpecialPrice":
                    break;
                case "MP_CENTRALA --ResetLock":
                    break;
                case "MP --UncheckBuffor":
                    break;
                    default: Console.WriteLine("Nie wybrałeś żadnej poprawnej opcji");
                    break;
            }

            var databases = DatabaseManager.GetDatabase();

            foreach (var database in databases)
            {
                Console.WriteLine(database.Key + " " + database.Value);
            }
            DatabaseManager dbManager = new DatabaseManager();




        }
    }
}
