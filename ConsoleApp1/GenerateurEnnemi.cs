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
            int baseVieMax = 60 + (niveau * 6);         
            int baseAttaque = 6 + (niveau * 2);      
            int baseDefense = 4 + (niveau * 2); 

            int vieMax = baseVieMax + rand.Next(-5, 6);  
            int attaque = baseAttaque + rand.Next(-2, 3); 
            int defense = baseDefense + rand.Next(-2, 3); 

            vieMax = Math.Max(50, vieMax);
            attaque = Math.Max(5, attaque);
            defense = Math.Max(3, defense);

            int vie = vieMax;

            return new Personnage(nom, vie, vieMax, attaque, defense);
        }
    }
}
