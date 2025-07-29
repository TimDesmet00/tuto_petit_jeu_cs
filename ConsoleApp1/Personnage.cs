using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Personnage
    {
        public string Nom;
        public int Vie;
        public int VieMax;
        public int Attaque;
        public int Defense;

        public Personnage(string nom, int vie, int vieMax, int attaque, int defense)
        {
            Nom = nom;
            Vie = vie;
            VieMax = vieMax;
            Attaque = attaque;
            Defense = defense;
        }

        public void AfficherStats()
        {
            Console.WriteLine($"{Nom} - Vie: {Vie}/{VieMax}, Attaque: {Attaque}, Défense: {Defense}");
        }
    }
}
