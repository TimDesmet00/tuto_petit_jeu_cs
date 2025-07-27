// See https://aka.ms/new-console-template for more information
using ConsoleApp1;


class Program
{
    static void Main(string[] args)
    {
        int potions = 5;        
        Random rand = new Random();
        int vieMaxHeros = rand.Next(90, 101);
        int vieheros = vieMaxHeros;
        int attaqueHeros = rand.Next(15, 20);
        int defenseHeros = rand.Next(5, 11);
        string[] nomsEnnemis = { "Pervert malsain", "Goblin", "Hobgoblin", "Orc", "homme lezard", "Gorak le Brutal", "Velra l'Écorcheuse", "Nox le Sanguinaire", "Kira la Maudite", "Sabrina la Ténébreuse" };

        Console.WriteLine("Bienvenue dans l'arène ... ");
        Console.WriteLine("Quel est ton nom heros ? ");

        string nomHeros = Console.ReadLine();
        Personnage heros = new Personnage(nomHeros, vieheros,vieMaxHeros, attaqueHeros, defenseHeros);

        for (int niveau = 1; niveau <= 10; niveau++)
        {
            int tour = 1;
            Console.WriteLine($"\nArène {niveau}/10");
            string nomEnnemi = nomsEnnemis[niveau - 1];

            if (nomEnnemi == "Sabrina la Ténébreuse")
            {
                Console.WriteLine("\nUne silhouette élégante et ténébreuse s'avance dans l’arène…");
                Console.WriteLine("Ses yeux bleu perçants brillent dans l’ombre. C’est Sabrina, la poupée gothique déchue…\n");
            }

            Personnage ennemi = GenerateurEnnemi.Creer(niveau, nomEnnemi);

            Console.WriteLine("\nVoici tes stats :");
            heros.AfficherStats();

            Console.WriteLine("\nUn nouvel ennemi apparaît !");
            ennemi.AfficherStats();

            Console.WriteLine("\nLe combat commence !\n");

            while (heros.Vie > 0 && ennemi.Vie > 0)
            {
                Console.WriteLine($"\n--- Tour {tour} ---");
                Console.WriteLine("\nque veux-tu faire ?");
                Console.WriteLine("1. Attaquer");
                Console.WriteLine($"2. Te soigner ({potions} potions restante)");
                Console.WriteLine("3. Fuir, lâchement");
                Console.WriteLine("Choix : ");
                string choix = Console.ReadLine();

                if (choix == "1")
                {
                    bool coupCritique = rand.Next(1, 10) == 1;
                    int degatsHeros = heros.Attaque - ennemi.Defense + rand.Next(-2, 3);
                    degatsHeros = Math.Max(0, degatsHeros);
                    if (coupCritique)
                    {
                        degatsHeros *= 2;
                        Console.WriteLine("Coup critique !");
                    }
                    ennemi.Vie -= degatsHeros;
                    Console.WriteLine($"{heros.Nom} attaque ! {ennemi.Nom} perd {degatsHeros} points de vie. ({Math.Max(0,ennemi.Vie)} restants)");
                }
                else if (choix == "2")
                {
                    if (potions > 0)
                    {
                        int soin = rand.Next(20, 31);
                        heros.Vie = Math.Min(heros.Vie + soin, vieMaxHeros);
                        potions--;
                        Console.WriteLine($"{heros.Nom} se soigne de {soin} points de vie. ({heros.Vie} restants)");
                    }
                    else
                    {
                        Console.WriteLine("Tu n'as plus de potions !");
                    }
                }
                else if (choix == "3")
                {
                    Console.WriteLine($"{heros.Nom} est un couard et fuis le combat !!");
                    return;
                }
                else
                {
                    Console.WriteLine("Choix invalide, tu perds ton tour !");
                }

                // Si l'ennemi est mort
                if (ennemi.Vie <= 0)
                {
                    Console.WriteLine($"\n{ennemi.Nom} a été vaincu ! {heros.Nom} gagne le combat !");
                    potions++;
                    Console.WriteLine($"Victoire ! Tu gagnes une potion. Potions restantes : {potions}");
                    vieMaxHeros += rand.Next(6, 11); 
                    attaqueHeros += rand.Next(1, 3);
                    defenseHeros += 1;

                    heros.Vie = Math.Min(heros.Vie + 20, vieMaxHeros);
                    heros.VieMax = vieMaxHeros;
                    heros.Attaque = attaqueHeros;
                    heros.Defense = defenseHeros;

                    if (niveau < 10)
                    {
                        Console.WriteLine("Souhaites-tu continuer vers la prochaine arène ? (o/n)");
                        string suite = Console.ReadLine();
                        if (suite.ToLower() != "o")
                        {
                            Console.WriteLine("Tu quittes l’arène en champion… mais pas encore le maître suprême !");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Félicitations ! Tu as vaincu tous les ennemis de l'arène !");
                        Console.WriteLine("Tu es le champion suprême !");
                        return;
                    }
                    break; // Sortie de la boucle du combat
                }

                // Attaque de l'ennemi
                bool ennemiCritique = rand.Next(1, 15) == 1;
                int degatsennemi = ennemi.Attaque - heros.Defense + rand.Next(-2, 3);
                degatsennemi = Math.Max(0, degatsennemi);
                if (ennemiCritique)
                {
                    degatsennemi *= 2;
                    Console.WriteLine("Coup critique du ennemi !");
                }
                heros.Vie -= degatsennemi;
                Console.WriteLine($"{ennemi.Nom} attaque ! {heros.Nom} perd {degatsennemi} points de vie. ({Math.Max(0, heros.Vie)} restants)");

                if (heros.Vie <= 0)
                {
                    Console.WriteLine($"\n{heros.Nom} a été vaincu ! {ennemi.Nom} gagne le combat !");
                    return;
                }
                tour++;
            }
        }
    }
}
