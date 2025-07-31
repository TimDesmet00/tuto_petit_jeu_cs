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
        private static readonly string[] nomsEnnemis = { "Rat géant", "Goblin", "Hobgoblin", "Orc", "homme lezard", "Charlotte la Féline", "Velra l'Écorcheuse", "Nox le Sanguinaire", "Kira la Maudite", "Sabrina la Ténébreuse" };
        public static Action[] EntreesEnnemis = new Action[]
        {
            EntrerRatGeant,
            EntrerGobelin,
            EntrerHobgobelin,
            EntrerOrc,
            EntrerHommeLezard,
            EntrerCharlotte,
            EntrerVelra,
            EntrerNox,
            EntrerKira,
            EntrerSabrina
        };
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

        //entrée des ennemis dans l'arène

        public static void EntrerSabrina()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nUne silhouette élégante et ténébreuse s'avance dans l’arène…");
            Console.WriteLine("Ses yeux bleu perçants brillent dans l’ombre. C’est Sabrina, la poupée gothique déchue…\n");
            Console.ResetColor();
        }

        public static void EntrerCharlotte()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nUne panthère gracieuse s’élance, son regard espiègle et brûlant…");
            Console.WriteLine("C’est Charlotte, la Féline fatale, prête à jouer avec sa proie…\n");
            Console.ResetColor();
        }

        public static void EntrerRatGeant()
        {
            Console.WriteLine("\nUn grondement sourd résonne sous tes pieds…");
            Console.WriteLine("Un rat géant surgit, son pelage souillé et ses crocs dégoulinants, prêt à te dévorer !\n");
        }

        public static void EntrerGobelin()
        {
            Console.WriteLine("\nUn rire nasillard perce l’air stagnant de l’arène…");
            Console.WriteLine("Un gobelin bondit hors d’une trappe, brandissant une dague aussi tordue que son sourire.\n");
        }

        public static void EntrerHobgobelin()
        {
            Console.WriteLine("\nDes pas lourds ébranlent le sol…");
            Console.WriteLine("Le hobgobelin entre, cuir clouté et regard de brute, ses muscles tendus d’impatience.\n");
        }

        public static void EntrerOrc()
        {
            Console.WriteLine("\nUn hurlement bestial fend le silence…");
            Console.WriteLine("L’orc s’élance, hache levée, couvert de cicatrices et d’un sang qui n’est pas le sien.\n");
        }

        public static void EntrerHommeLezard()
        {
            Console.WriteLine("\nUn souffle sifflant glisse entre les colonnes de pierre…");
            Console.WriteLine("L’homme-lézard se dresse, langue bifide fouettant l’air, prêt à fondre sur sa proie.\n");
        }

        public static void EntrerVelra()
        {
            Console.WriteLine("\nUn murmure malsain envahit l’arène, glacé comme la mort…");
            Console.WriteLine("Velra l’Écorcheuse apparaît, sa lame traînant sur le sol, laissant derrière elle une traînée de cendre.\n");
        }

        public static void EntrerNox()
        {
            Console.WriteLine("\nUn choc métallique résonne violemment, puis le silence…");
            Console.WriteLine("Nox le Sanguinaire entre dans la lumière, son armure tachée, son regard vide de toute pitié.\n");
        }

        public static void EntrerKira()
        {
            Console.WriteLine("\nDes chaînes grincent lentement, presque comme un sanglot…");
            Console.WriteLine("Kira la Maudite s’avance lentement, ses yeux noyés dans les ombres du passé.\n");
        }
    }
}
