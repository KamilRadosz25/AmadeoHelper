using System;

namespace AmadeoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Amadeo Helpdesk");
            Console.WriteLine("Witaj w programie helpdeskowym PIM. ");

            QueryBuilder queryBuilder = new QueryBuilder();

            queryBuilder.FiscalizationReceipt();



        }
    }
}
