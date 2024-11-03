using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Bibliotekshanteringssystem_AVANCERAD___v2___Ayub_Mohamud
{
    class Bibliotek
    {
        public List<Bok> Böcker { get; set; } = new List<Bok>();
        public List<Författare> Författare { get; set; } = new List<Författare>();

        public void LaddaData(string filnamn)
        {
            if (File.Exists(filnamn))
            {
                var json = File.ReadAllText(filnamn);
                var data = JsonSerializer.Deserialize<Bibliotek>(json);
                if (data != null)
                {
                    Böcker = data.Böcker;
                    Författare = data.Författare;
                }
            }
        }

        public void SparaData(string filnamn)
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filnamn, json);
            Console.WriteLine("Data sparad.");
        }
    }
}