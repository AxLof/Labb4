using System.Linq.Expressions;

namespace Labb3v3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int userChoice=0;
            bool exit = false;

            while (exit == false) //Switch där andvändaren kan välja vad som ska hända baserat på dess input.
            {
                try { 
                printMenu();
                userChoice =Convert.ToInt32(Console.ReadLine());


                    switch (userChoice)
                    {

                        case 1:
                            Person.AddPerson();
                            break;

                        case 2:

                            if (Person.People.Count == 0)
                            {
                                Console.WriteLine("\nDet finns ännu inga personer att visa. Skapa en person genom att välja menyval ett (1)!\n");
                            }
                            else { Person.ListPerson(); }

                            break;

                        case 3:
                            Person.SearchPerson();
                            break;

                        case 4:
                            Person.RemovePerson();
                            break;

                        case 5:
                            exit = true;
                            break;

                        default:
                            break;
                    }

                } catch (Exception e) {  Console.WriteLine("Error, försök igen");}
            }
        }


        //Metod som skrier ut en meny
       public static void printMenu() 
        {
            Console.WriteLine("\nVälj ett alternativ!");
            Console.WriteLine("--------------------");
            Console.WriteLine("[1]: Lägg till en person");
            Console.WriteLine("[2]: Skriv ut alla personer");
            Console.WriteLine("[3]: Sök efter personer");
            Console.WriteLine("[4]: Ta bort en person");
            Console.WriteLine("[5]: Avsluta programmet\n");
        }

        




    }
}