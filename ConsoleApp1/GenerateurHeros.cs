using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GenerateurHeros
    {
        private static Random rand = new Random();

        public static Personnage Creer(string nom)
        {
            int vieMax = rand.Next(90, 101);
            int vie = vieMax;
            int attaque = rand.Next(10, 15);
            int defense = rand.Next(5, 11);
            return new Personnage(nom, vie, vieMax, attaque, defense);
        }

        public static void EvolutionHeros(Personnage heros)
        {
            heros.VieMax += rand.Next(5, 11);
            heros.Attaque += rand.Next(1, 4);
            heros.Defense += rand.Next(1, 3);
            heros.Vie= Math.Min(heros.Vie +30, heros.VieMax);
        }
    }
}
