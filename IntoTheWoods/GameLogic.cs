using System;
using System.Collections.Generic;
using System.Text;

namespace IntoTheWoods
{
    class GameLogic
    {
        public Player player;
        public MagicalCreature theWitch;
        public static List<MagicalCreature> ListOfCreatures = new List<MagicalCreature>();
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("******************************");
            Console.WriteLine("******************************");
            Console.WriteLine("**        '                 **");
            Console.WriteLine("**        WELCOME TO  '     **");
            Console.WriteLine("**      INTO THE WOODS    ' **");
            Console.WriteLine("**  '                '      **");
            Console.WriteLine("**        '    *            **");
            Console.WriteLine("**     '      ***       '   **");
            Console.WriteLine("** '       ' *****  '       **");
            Console.WriteLine("**          *******         **");
            Console.WriteLine("**     '   *********  '     **");
            Console.WriteLine("**  '         ***         ' **");
            Console.WriteLine("**                          **");
            Console.WriteLine("******************************");
            Console.WriteLine("******************************");

            Console.Write("\nEnter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            Console.Clear();
            Console.WriteLine($"Oh mighty {playerName}!");
            Console.WriteLine("The Witch has cast a spell over The Woods which have turned all the magical creatures crazy.");
            Console.WriteLine("The animals in The Woods are in danger and only you can save them.");
            Console.WriteLine("In order to do that, you must defeat The Witch. We dont have much time, Please hurry!");
            Console.WriteLine();
            Console.WriteLine("[PLAY]");

            Console.ReadLine();
            AddMagicalCreatures();
            Menu();
        }

        public void Menu()
        {
            try
            {
                bool keepPlaying = true;

                while (keepPlaying)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Console.WriteLine("[MENU]");
                    Console.WriteLine("1. Walk Into The Woods");
                    Console.WriteLine("2. Player details");
                    Console.WriteLine("3. Go to Shop");
                    Console.WriteLine("4. Exit game");
                    Console.Write("> ");
                    string input = Console.ReadLine();
                    //int input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case "1":
                            WalkingInTheWoods();
                            break;
                        case "2":
                            player.PlayerDetails();
                            Console.ReadLine();
                            break;
                        case "3":
                            break;
                        case "4":
                            Console.WriteLine("Oh, Leaving so soon?");
                            Console.WriteLine("The Woods will miss you <3");
                            keepPlaying = false;
                            break;
                        default:
                            Console.WriteLine("Wrong input, please try again!");
                            break;
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        public void WalkingInTheWoods() 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            if(player.Level == 10) 
            {
                FightTheWitch();
            }

            Random random = new Random();
            int rand = random.Next(0, 10); 

            if (rand == 1)
            {
                Console.WriteLine("You are walking into the dark woods where the trees are so high, they cover the sky. All you see is a mist in front of you.");
                Console.WriteLine("[Press enter to continue]");
                Console.ReadLine();
                Menu();
            }
            else
            {
                var creature = GetCreature();
                Console.WriteLine($"Oh no! A magical creature appeared, it's {creature.Name}!");
                Console.ReadLine();
                FightMagicalCreature(creature);
            }
        }
        public void FightMagicalCreature(MagicalCreature creature)
        {
            bool fightMode = true;
            while (fightMode)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                string attack = creature.GetRandomAttack();
                Console.WriteLine($"{creature.Name} {attack}");
                Console.Write($"Dealing {creature.Strength} damage.");
                player.Hp -= creature.Strength;
                Console.ReadLine();
                Console.WriteLine($"You hit {creature.Name} with your slingshot!");
                Console.Write($"Dealing {player.Strength} damage.");
                creature.Hp -= player.Strength;
                Console.ReadLine();

                if (player.Hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou are defeated and failed to complete your mission. The animals will hate you for all eternity!");
                    Console.WriteLine("GAME OVER");
                    Environment.Exit(0);
                }
                if (creature.Hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    player.Level += 1;
                    Console.WriteLine($"You have defeated {creature.Name}! You gained {creature.Exp} experience points.");
                    player.Exp += creature.Exp;
                    Console.WriteLine($"You've reached level {player.Level}. You have now {player.Exp} exp and {player.Hp} hp");

                    foreach (var item in ListOfCreatures)
                    {
                        if(creature == item)
                        {
                            ListOfCreatures.Remove(creature);
                            break;
                        }
                    }
                    Console.ReadLine();
                    Menu();
                }
                Console.WriteLine($"\n{player.Name}: {player.Hp} hp");
                Console.WriteLine($"{creature.Name}: {creature.Hp} hp");
                Console.ReadLine();
            }
        }

        public void FightTheWitch()
        {
            bool fightMode = true;
            Console.WriteLine($"Oh no! {theWitch.Name} has appeared and is looking furious!");
            Console.ReadLine();
            
            while (fightMode)
            {
                Console.Clear();
                string attack = theWitch.GetRandomAttack();
                Console.WriteLine($"{theWitch.Name} {attack}");
                Console.Write($"Dealing {theWitch.Strength} damage.");
                player.Hp -= theWitch.Strength;
                Console.ReadLine();
                Console.WriteLine($"You hit {theWitch.Name} with your slingshot!");
                Console.Write($"Dealing {theWitch.Strength} damage.");
                theWitch.Hp -= player.Strength;
                Console.ReadLine();

                if (player.Hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou are defeated and failed to complete your mission. \nThe animals in The Woods will hate you for all eternity!");
                    Console.WriteLine("GAME OVER");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                if (theWitch.Hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nOur Saviour, you have defeated The Witch and saved The Woods!");
                    Console.WriteLine("The animals are forever greatful for your heroic act and shows you \ntheir gratitude by giving you the honorable title Protector of The Woods.");
                    Console.WriteLine($"Farewell oh mighty {player.Name}, the Protector of The Woods.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                Console.WriteLine($"\n{player.Name}: {player.Hp} hp");
                Console.WriteLine($"{theWitch.Name}: {theWitch.Hp} hp");
                Console.ReadLine();
            }
        }

        public MagicalCreature GetCreature()
        {
            Console.WriteLine("Element i listan " + ListOfCreatures.Count);
            Random random = new Random();
            int i = random.Next(ListOfCreatures.Count);

            if (ListOfCreatures[i] == null)
            {
                GetCreature();
            }

            return ListOfCreatures[i];
        }

        public void AddMagicalCreatures()
        {
            ListOfCreatures.Add(new MagicalCreature("Cinderella", 20, 5, "throws ashes in your eyes.", "takes help from fairy godmother and try to turn you into a pumpkin!"));
            ListOfCreatures.Add(new MagicalCreature("Prince Charming", 20, 5, "weakens you with his charm.", " "));
            ListOfCreatures.Add(new MagicalCreature("Rapunzel", 30, 8, "hits you with a frying pan!", "strangle you with her hair!"));
            ListOfCreatures.Add(new MagicalCreature("Ariel", 20, 5, "distracts you and hits you with her fin!", "stabs you in your feets with a fork."));
            ListOfCreatures.Add(new MagicalCreature("Belle", 20, 5, "throws books at you!", "calls for The Beast who jumps on you and bites you in the arm!"));
            
            ListOfCreatures.Add(new MagicalCreature("The Big Bad Wolf", 30, 8, "he huffs and he puffs and he blows you over with a BANG!", "he scratches you with his claws."));
            ListOfCreatures.Add(new MagicalCreature("Elsa", 30, 8, "throws snowballs at you", "hits you with an ice blast! "));
            ListOfCreatures.Add(new MagicalCreature("Snow white", 40, 10, "makes you eat poison apple.", "calls for the 7 dwarfs who hits you with sledgehammers!"));
            ListOfCreatures.Add(new MagicalCreature("Maleficent", 40, 10, "pokes you with her horns!", "casts a curse of pain on you!"));
            theWitch = new MagicalCreature("The Witch", 100, 15, "uses telekinesis and hits you with her broom. ", "throws witchcraft towards you.");
        } 
    }
}
