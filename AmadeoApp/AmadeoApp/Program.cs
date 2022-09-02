using System;



namespace AmadeoApp
{
    internal class Program
    {
        //SPEXORDS PO PROSTU ZROB SE PRINTA ARGS \/ JAK PODASZ COS PROGRAMIKOWI JAKO PARAMETRY
        static void Main(string[] args)
        {
            Console.WriteLine("Amadeo Helpdesk");
            Console.WriteLine("Witaj w programie helpdeskowym PIM. ");

            var databases = DatabaseManager.GetDatabase();

            foreach (var database in databases)
            {
                Console.WriteLine(database.Key + " " + database.Value);
            }
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.ExecuteQueryOnDB();




            //switch wykorzystujący komendy.
            //SPEXORDS: Mozesz wykorzystac bardzo eleganckie rozwiazanie ktore sluzy do konfiguracji ktore jest natywnie od jakeis wersji .net
            // var configuration = ConfigurationBuilder.AddCommandLine(args).Build() ========> i potem mozesz sie odwolywac do argumentow configuration["metoda"] 

            //AmadeoApp.exe --metoda zabijTerminal --argument 5
            //configuration["metoda"] zwroci stringa "zabijTerminal"
            //configuration["argument"] zwroci stringa "5"



        }
    }
}
