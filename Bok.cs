using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekshanteringssystem_AVANCERAD___v2___Ayub_Mohamud
{
    class Bok
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Författare { get; set; }
        public string Genre { get; set; }
        public int Publiceringsår { get; set; }
        public string Isbn { get; set; }

        public override string ToString() => $"ID: {Id}, Titel: {Titel}, Författare: {Författare}, Genre: {Genre}, År: {Publiceringsår}, ISBN: {Isbn}";
    }
}