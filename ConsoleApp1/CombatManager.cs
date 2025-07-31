using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class CombatManager
    {

        public static bool LancerCombat(Personnage heros, ref int potions)
        {
            Random rand = new Random();

            for (int niveau = 1; niveau <= 10; niveau++)
            {
                int tour = 1;
                Console.WriteLine($"\nArène {niveau}/10");

                Personnage ennemi = GenerateurEnnemi.Creer(niveau, "");

                GenerateurEnnemi.EntreesEnnemis[niveau - 1]();

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
                        int penetrationHeros = rand.Next(1, 4);
                        int degatsHeros = heros.Attaque - Math.Max(0, ennemi.Defense - penetrationHeros) + rand.Next(-2, 3);
                        degatsHeros = Math.Max(1, degatsHeros);
                        if (coupCritique)
                        {
                            degatsHeros *= 2;
                            Console.WriteLine("Coup critique !");
                        }
                        ennemi.Vie -= degatsHeros;
                        Console.WriteLine($"{heros.Nom} attaque ! {ennemi.Nom} perd {degatsHeros} points de vie. ({Math.Max(0, ennemi.Vie)} restants)");
                    }
                    else if (choix == "2")
                    {
                        if (potions > 0)
                        {
                            int soin = rand.Next(25, 35);
                            heros.Vie = Math.Min(heros.Vie + soin, heros.VieMax);
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
                        return false;
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

                        GenerateurHeros.EvolutionHeros(heros);

                        if (niveau < 10)
                        {
                            Console.WriteLine("Souhaites-tu continuer vers la prochaine arène ? (o/n)");
                            string suite = Console.ReadLine();
                            if (suite.ToLower() != "o")
                            {
                                Console.WriteLine("Tu quittes l’arène en champion… mais pas encore le maître suprême !");
                                return false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Félicitations ! Tu as vaincu tous les ennemis de l'arène !");
                            Console.WriteLine("Tu es le champion suprême !");
                            return true;
                        }
                        break; // Sortie de la boucle du combat
                    }

                    // Attaque de l'ennemi
                    bool ennemiCritique = rand.Next(1, 15) == 1;
                    int penetrationEnnemi = rand.Next(0, 3);
                    int degatsennemi = ennemi.Attaque - Math.Max(0, heros.Defense - penetrationEnnemi) + rand.Next(-2, 3);
                    degatsennemi = Math.Max(1, degatsennemi);
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
                        return false;
                    }
                    tour++;
                }
            }
            return true;
        }
    }
}
