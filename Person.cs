using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3v3
{
    internal class Person
    {
       
        //Initierar en lista som ska innehålla alla personer som andvändaren skapat 
        //Initierar propertys vars värden sätts i constructorn. 
        public static List <Person> People = new List<Person>();
        public string Name { get; set; }  
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string EyeColor { get; private set; }
        public string HairColor { get; set; }
        public int HairLength { get; set; }
        public Gender Gender { get; set; }

        //Constructor som bestämmer vilka egenskaper som objekten i klassen ska innehålla.
        public Person(string name, string lastName, string birthDate, string eyeColor, Hair hair, Gender gender)
        {
            
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            EyeColor= eyeColor;
            HairColor = hair.hairColor;
            HairLength= hair.hairLength;
            Gender Gender = gender;

        }

        public static void AddPerson() //Metod för att lägga till en person med andvändarens input.
        {

            //Initierar variabler som ska innehålla andvändarens input
            int genderChoice = 0;
            string name;
            string lastName;
            string birthDate;
            string eyeColor; 
            Hair hair;
            Gender gender=Gender.Female;
            bool hasRun = false;

            
            
            do //Användaren skriver in sitt förnamn
            {
                Console.WriteLine("\nSkriv in ditt förnamn:");
                name = Person.firstCharUppercase(Console.ReadLine());                      
                Person.NullInputError(name); 
            } while (string.IsNullOrEmpty(name));

            do //Användaren skriver in sitt efternamn
            {
                Console.WriteLine("\nSkriv in ditt efternamn:");
                lastName = Person.firstCharUppercase(Console.ReadLine());
                Person.NullInputError(lastName);
            } while (string.IsNullOrEmpty(lastName));

            do //Användaren skriver in sitt födelsedatum
            {
                Console.WriteLine("\nSkriv in ditt födelsedatum: (Format XXYYZZ)");
                birthDate = Console.ReadLine();
                Person.NullInputError(birthDate);
                if (birthDate.Length != 6)
                {
                    Console.WriteLine("\nError: Du ska skriva in ditt fördelsedatum med sex (6) siffor, försök igen.");
                }
            } while (string.IsNullOrEmpty(birthDate) || birthDate.Length != 6);


            do //Andvändaren skriver in sin ögonfärg
            {
                Console.WriteLine("\nSkriv in din ögonfärg:");
                eyeColor = Person.firstCharUppercase(Console.ReadLine());
                Person.NullInputError(eyeColor);
            } while (string.IsNullOrEmpty(eyeColor));



            do //Andvändaren skriver in sin hårlängd
            {
                hair.hairLength = 0;
                try
                {
                    Console.WriteLine("\nSkriv in din hårlängd: (cm)");
                    hair.hairLength = Convert.ToInt32(Console.ReadLine());                   
                    hasRun = true;
                }
                catch { Console.WriteLine("\nError: Tänk på att endast skriva in siffor."); }
            } while (hasRun == false);


            do //Andvändaren skriver in sin hårfärg
            {
                Console.WriteLine("\nSkriv in din hårfärg:");
                hair.hairColor = Person.firstCharUppercase(Console.ReadLine());
                Person.NullInputError(hair.hairColor);
            } while (string.IsNullOrEmpty(hair.hairColor));

            
           do //Andvändaren väljer sitt kön
            {
                
                try
                {
                    Console.WriteLine("\nVad har du för kön?\n[1]: Kvinna\n[2]: Man");
                    genderChoice = Convert.ToInt32(Console.ReadLine());

                    if (genderChoice == 1)
                    {
                        gender = Gender.Female;
                    }

                    if (genderChoice == 2)
                    {
                        gender = Gender.Male;
                    }

                    else { Console.WriteLine("\nError: Skriv in ett giltigt nummer!"); }
                }
                catch 
                {
                    Console.WriteLine("\nError, du måste skriva in en siffra!");
                }
               

            } while (genderChoice < 1 || genderChoice > 2); 
                
          
            //Skapar en ny person baserat på andvändarens input och sparar personen i listan "People"
            Person newPerson = new Person(name, lastName, birthDate, eyeColor, hair, gender);
            People.Add(newPerson);
            
        }

        public static void ListPerson() //Metod för att skriva ut alla personer i listan "People"
        {
            foreach (Person newPerson in Person.People)
            {
                Console.WriteLine(newPerson.ToString());
            }
        }

        public static void NullInputError(string variableInput) //Metod för att kolla om en sträng är tom och skriver i så fall ut ett felmeddelande. 
        {
            if (string.IsNullOrEmpty(variableInput)) 
            {
                Console.WriteLine("\nError: Tänk på att du alltid måste skriva in ett värde, testa igen.");              
            }
            
            
        }

        public static string firstCharUppercase(string input)  //Metod för att göra första bokstaven i en sträng till stor bokstav och resten små. 
        {
            input = input.ToLower(); 
            char[] c = input.ToCharArray(); 
            c[0] = char.ToUpper(c[0]);
            return new string(c);
        }

        
        public override string ToString() //Metod för att skriva ut all information om en person
        {
            return $"Förnamn: {Name}, Efternamn: {LastName}, Födelsedatum: {BirthDate}, Ögonfärg: {EyeColor}, Hårfärg: {HairColor}, Hårlängd: {HairLength}cm, Kön: {Gender}\n";
        }

        public static void SearchPerson() //Metod där användaren kan söka efter personer.
        {

            if (Person.People.Count == 0)
            {
                Console.WriteLine("\nDet finns ännu inga personer i vårat system. Skapa en ny person genom att välja menyval [1]!");
            }

            else
            {
                Console.WriteLine("\nSkriv in ett förnamn för att söka efter en person:");

                string firstNameSearch = Person.firstCharUppercase(Console.ReadLine());

                Console.WriteLine("\nSkriv in ett efternamn för en mer exakt sökning (frivilligt)");

                string lastNameSearch = Person.firstCharUppercase(Console.ReadLine()); 

                foreach (Person person in Person.People)
                {
                    if (firstNameSearch == person.Name || lastNameSearch == person.LastName)
                    {
                        Console.WriteLine($"\nVi hittade följande matchningar för söksträngen \"{firstNameSearch + lastNameSearch}\"\n");
                        Console.WriteLine(person.ToString());
                    }

                    else { Console.WriteLine("\nTyvärr, vi hittade 0 matchningar."); }
                }
            }

        }

        public static void RemovePerson() //Metod där användaren kan ta bort en person baserat på för och efternamn samt personnummer om nödvändigt. 
        {
            if(People.Count == 0) 
            {
                Console.WriteLine("\nDet finns inga personer att ta bort.");
            }

            else 
            {
                Console.WriteLine("\nSkriv förnamnet på personen du vill ta bort:");
                string firstName= Person.firstCharUppercase(Console.ReadLine());
                Console.WriteLine("\nSkriv efternamnet på personen du vill ta bort:");
                string lastName= Person.firstCharUppercase(Console.ReadLine());

                try
                {

                    foreach (Person person in People)
                    {
                        if(firstName == person.Name && lastName == person.LastName)
                        {
                            People.Remove(person);
                            Console.WriteLine("\nPerson borttagen!");
                        }

                    }
                } 

                catch(Exception e)  //Fungerar inte
                {
                    Console.WriteLine("\nDet finns ingen person som matchar det namn du angav, försök igen.");
                }
                

                
            }
            
        }







    }
}
