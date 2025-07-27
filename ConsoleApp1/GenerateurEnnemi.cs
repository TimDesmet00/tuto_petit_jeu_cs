using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GenerateurEnnemi
    {
        private static Random rand = new Random();

        public static Personnage Creer(int niveau, string nom)
        {
            int vie, vieMax, attaque, defense;

            if (niveau <= 3)
            {
                vie = rand.Next(70, 80);
                attaque = rand.Next(8, 12);
                defense = rand.Next(2, 5);
            }
            else if (niveau <= 6)
            {
                vie = rand.Next(80, 100);
                attaque = rand.Next(14, 18);
                defense = rand.Next(5, 8);
            }
            else if (niveau <= 9)
            {
                vie = rand.Next(110, 130);
                attaque = rand.Next(18, 22);
                defense = rand.Next(7, 10);
            }
            else
            {
                vie = rand.Next(160, 190);
                attaque = rand.Next(24, 30);
                defense = rand.Next(10, 13);
            }
            vieMax = vie;

            return new Personnage(nom, vie, vieMax, attaque, defense);
        }
    }
}
