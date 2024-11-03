using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekshanteringssystem_AVANCERAD___v2___Ayub_Mohamud
{
    public class Författare
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Land { get; set; }  // Ny egenskap

        public override string ToString() => $"{Namn} från {Land}";  // Utskrift av författarinformation
    }
}