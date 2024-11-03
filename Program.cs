using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Bibliotekshanteringssystem_AVANCERAD___v2___Ayub_Mohamud
{
    class Program
    {
        static void Main()
        {
            var bibliotek = new Bibliotek();
            string filnamn = "LibraryData.json";
            bibliotek.LaddaData(filnamn);

            // Lägg till exempeldata om biblioteket är tomt.
            if (!bibliotek.Böcker.Any())
            {
                bibliotek.Böcker.AddRange(new List<Bok>
            {
                new Bok { Id = 1, Titel = "Moby Dick", Författare = "Herman Melville", Genre = "Äventyr", Publiceringsår = 1851, Isbn = "978-0-14-243724-7" },
                new Bok { Id = 2, Titel = "Pride and Prejudice", Författare = "Jane Austen", Genre = "Romantik", Publiceringsår = 1813, Isbn = "978-0-19-953556-9" },
                new Bok { Id = 3, Titel = "1984", Författare = "George Orwell", Genre = "Dystopi", Publiceringsår = 1949, Isbn = "978-0-452-28423-4" }
            });
                Console.WriteLine("Exempelböcker har lagts till i biblioteket.");
            }

            while (true)
            {
                Console.WriteLine("\nMenyalternativ:\n1. Lägg till bok\n2. Lägg till författare\n3. Uppdatera bok\n4. Uppdatera författare\n5. Ta bort bok\n6. Ta bort författare\n7. Lista alla böcker\n8. Sök böcker\n9. Spara och avsluta");
                switch (Console.ReadLine())
                {
                    case "1": LäggTill(bibliotek.Böcker, new Bok()); break;
                    case "2": LäggTill(bibliotek.Författare, new Författare()); break;
                    case "3": Uppdatera(bibliotek.Böcker); break;
                    case "4": Uppdatera(bibliotek.Författare); break;
                    case "5": TaBort(bibliotek.Böcker); break;
                    case "6": TaBort(bibliotek.Författare); break;
                    case "7": Lista(bibliotek.Böcker); break;
                    case "8": SökBöcker(bibliotek); break;
                    case "9": bibliotek.SparaData(filnamn); return;
                    default: Console.WriteLine("Ogiltigt val, försök igen."); break;
                }
            }
        }

        static void LäggTill<T>(List<T> lista, T obj)
        {
            (obj as dynamic).Id = lista.Count + 1;
            if (obj is Bok bok)
            {
                Console.Write("Titel: "); bok.Titel = Console.ReadLine();
                Console.Write("Författare: "); bok.Författare = Console.ReadLine();
                Console.Write("Genre: "); bok.Genre = Console.ReadLine();
                Console.Write("Publiceringsår: "); bok.Publiceringsår = int.Parse(Console.ReadLine());
                Console.Write("ISBN: "); bok.Isbn = Console.ReadLine();
            }
            else if (obj is Författare författare)
            {
                Console.Write("Namn: "); författare.Namn = Console.ReadLine();
                Console.Write("Land: "); författare.Land = Console.ReadLine();
            }
            lista.Add(obj);
            Console.WriteLine($"{(obj is Bok ? "Bok" : "Författare")} tillagd!");
        }

        static void Uppdatera<T>(List<T> lista)
        {
            Console.Write("Ange ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                T objekt = lista.FirstOrDefault(o => (o as dynamic).Id == id);
                if (objekt != null)
                {
                    if (objekt is Bok bok)
                    {
                        Console.Write("Ny titel: "); bok.Titel = Console.ReadLine();
                        Console.Write("Ny författare: "); bok.Författare = Console.ReadLine();
                        Console.Write("Ny genre: "); bok.Genre = Console.ReadLine();
                        Console.Write("Nytt publiceringsår: "); bok.Publiceringsår = int.Parse(Console.ReadLine());
                        Console.Write("Ny ISBN: "); bok.Isbn = Console.ReadLine();
                    }
                    else if (objekt is Författare författare)
                    {
                        Console.Write("Nytt namn: "); författare.Namn = Console.ReadLine();
                        Console.Write("Nytt land: "); författare.Land = Console.ReadLine();
                    }
                    Console.WriteLine("Uppdaterad!");
                }
                else Console.WriteLine("Objekt med angivet ID hittades inte.");
            }
            else Console.WriteLine("Ogiltig inmatning. Ange ett giltigt ID.");
        }

        static void TaBort<T>(List<T> lista)
        {
            Console.Write("Ange ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var objekt = lista.FirstOrDefault(o => (o as dynamic).Id == id);
                if (objekt != null) { lista.Remove(objekt); Console.WriteLine("Borttagen!"); }
                else Console.WriteLine("Objekt med angivet ID hittades inte.");
            }
            else Console.WriteLine("Ogiltig inmatning. Ange ett giltigt ID.");
        }

        static void Lista<T>(List<T> lista)
        {
            if (!lista.Any()) Console.WriteLine("Inga objekt att lista.");
            else lista.ForEach(o => Console.WriteLine(o.ToString()));
        }

        static void SökBöcker(Bibliotek bibliotek)
        {
            Console.Write("Sök: ");
            var sökord = Console.ReadLine();
            var resultat = bibliotek.Böcker.Where(b => b.Titel.Contains(sökord) || b.Författare.Contains(sökord)).ToList();
            Console.WriteLine(resultat.Any() ? "Resultat:\n" + string.Join("\n", resultat) : "Inga böcker hittades.");
        }
    }
}