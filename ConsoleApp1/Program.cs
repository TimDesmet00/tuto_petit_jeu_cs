// See https://aka.ms/new-console-template for more information
using ConsoleApp1;


class Program
{
    static void Main(string[] args)
    {
        int potions = 5;        
        Random rand = new Random();        
        

        Console.WriteLine("Bienvenue dans l'arène ... ");
        Console.WriteLine("Quel est ton nom heros ? ");

        string nomHeros = Console.ReadLine();
        Personnage heros = GenerateurHeros.Creer(nomHeros);

        bool victoire = CombatManager.LancerCombat(heros, ref potions);
        if (victoire)
        {
            Console.WriteLine("Bravo, tu as tout déchiré !");
        }
        else
        {
            Console.WriteLine("Essaie encore, tu peux le faire !");
        }

        Console.WriteLine("\nAppuie sur Entrée pour quitter le jeu...");
        Console.ReadLine();
    }
}
