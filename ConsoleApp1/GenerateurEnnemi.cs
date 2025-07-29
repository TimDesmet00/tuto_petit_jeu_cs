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
        private static readonly string[] nomsEnnemis = { "Pervert malsain", "Goblin", "Hobgoblin", "Orc", "homme lezard", "Charlotte la Féline", "Velra l'Écorcheuse", "Nox le Sanguinaire", "Kira la Maudite", "Sabrina la Ténébreuse" };
        
        public static Personnage Creer(int niveau, string nom)
        {
            string nomEnnemi = nomsEnnemis[niveau - 1];

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

            return new Personnage(nomEnnemi, vie, vieMax, attaque, defense);
        }
    }
}
