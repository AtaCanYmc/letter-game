using System;
using System.Threading; //(Thread function active)

namespace homework
{
    class MainClass
    {
        public static void Main(string[] args)
        {
           
                //Variables

                Console.CursorVisible = false; //Make cursor invisible [V1]

                //Random (example:57)[V2]
                Random rastgele = new Random(); int random;

                //Player-1 and Player-2's Loto Sheet [V3]
                char[,] all_P_bags = new char[2, 8];

                //"Same letter" controller (example:64)[V3.2]
                bool control1 = true; bool control2 = true;

                //Player1 AND Player2's $ [V3.3]
                int P1_Money = 0; int P2_Money = 0;

                //Bag-1 AND Bag-2 [V4]
                char[,] all_G_bags = { { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }, { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' } };
                char transporter; // (transport a letter to bag2 from bag1)

                //"Çinko" control (example:303)[V5]
                bool p1_çinko = true; bool p2_çinko = true; int p1_do1 = 0; int p1_do2 = 0; int p2_do1 = 0; int p2_do2 = 0;

                //Winner control (example:355)[V6]
                int p1_win = 0; int p2_win = 0;

                //Random animation (example:214)[V7]
                int randomMinute;
                int randomLetter;
                int roundCounter = 0;
                string space_43 = "                                           "; //For erase something(43br)

                //Button reader (example:193)[V8]
                ConsoleKeyInfo Button;

            //Play again (example:445)[V9]
            bool again = false;


            //------------------------------------------------------------------------------------------

            do //(for "play again")
            {
                //İNTRO

                //Create Random Loto for players[İO1]
                for (int d = 0; d < all_P_bags.GetLength(0); d++)
                {

                    for (int a = 0; a < (all_P_bags.GetLength(1)); a++)
                    {
                        if (a < 4)
                        {
                            // (if player have 2 same letter controller will do re-assign)[İO1.2]
                            do
                            {
                                random = rastgele.Next(0, 14);
                                all_P_bags[d, a] = all_G_bags[0, random]; //Assign

                                control1 = true;
                                for (int inner_Control = 0; inner_Control < 4; inner_Control++)
                                {
                                    if ((all_P_bags[d, inner_Control] == all_P_bags[d, a]) && (a != inner_Control))
                                    { control1 = false; }
                                }
                            } while (control1 == false);
                        }

                        else
                        {
                            // (if player have 2 same letter controller will do re-assign)[İO1.3]
                            do
                            {
                                random = rastgele.Next(14, 26);
                                all_P_bags[d, a] = all_G_bags[0, random]; //Assign

                                control2 = true;
                                for (int inner_Control = 4; inner_Control < 8; inner_Control++)
                                {
                                    if ((all_P_bags[d, inner_Control] == all_P_bags[d, a]) && (a != inner_Control))
                                    { control2 = false; }
                                }

                            } while (control2 == false);
                        }
                    }
                }

                //------------------------------------------------------------------------------------------

                //Output of the sheets[İO2]

                //Player-1 Loto Sheet[İO2.1]
                Console.SetCursorPosition(1, 4);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(@"Player-1
 -----------------
 | | | | / | | | |
 -----------------");

                //Player-2 Loto Sheet[İO2.2]
                Console.SetCursorPosition(1, 9);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(@"Player-2
 -----------------
 | | | | / | | | |
 -----------------");

                //------------------------------------------------------------------------------------------

                //Game
                while (true)
                {
                    // Bag-1 Output[G1]
                    Console.SetCursorPosition(3, 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Bag-1: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    for (int b = 0; b < all_G_bags.GetLength(1); b++)
                    {
                        if (all_G_bags[0, b] != '0') //Control for is letter in the bag-1?
                        { Console.Write(all_G_bags[0, b] + " "); }
                        else
                        { Console.Write("_ "); }
                    }
                    Console.ResetColor();

                    // Bag-2 Output[G1.2]
                    Console.SetCursorPosition(3, 2);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Bag-2: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    for (int c = 0; c < all_G_bags.GetLength(1); c++)
                    {
                        if (all_G_bags[1, c] != '0') //Control for is letter in the bag-1?
                        { Console.Write(all_G_bags[1, c] + " "); }
                    }
                    Console.ResetColor();

                    //Writing the letters[G2]
                    for (int e = 0; e < all_P_bags.GetLength(0); e++)
                    {
                        for (int c = 0; c < all_P_bags.GetLength(1); c++)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            for (int control = 0; control < all_G_bags.GetLength(1); control++) // (if player has the letter it turns red else it turns green)
                            {
                                if (all_G_bags[1, control] == all_P_bags[e, c])
                                { Console.ForegroundColor = ConsoleColor.Red; }
                            }

                            if (e == 0) // (Controlling for the player 1 or 2)
                                Console.SetCursorPosition((2 + 2 * c), 6);
                            else if (e == 1)
                                Console.SetCursorPosition((2 + 2 * c), 11);

                            Console.Write(all_P_bags[e, c]);
                            Console.ResetColor();
                        }
                    }

                    //Writing user interface frame[G3]
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.SetCursorPosition(37, 4);
                    Console.Write("Player-1: " + P1_Money + "$    Player-2: " + P2_Money + "$");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(25, 5);
                    Console.Write("--------------------------------------------------");
                    for (int f = 0; f < 3; f++)
                    {
                        Console.SetCursorPosition(25, 6 + f);
                        Console.Write("|>>>");
                        Console.SetCursorPosition(74, 6 + f);
                        Console.Write("|");
                    }
                    Console.SetCursorPosition(25, 9);
                    Console.Write("--------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.SetCursorPosition(25, 10);
                    Console.Write("Please press enter for next letter or esc for exit");
                    Console.ResetColor();

                    //Controlling the button[G4]
                    if (Console.KeyAvailable)
                    {
                        Button = Console.ReadKey(true);

                        if (Button.Key == ConsoleKey.Enter) //For next draw
                        {
                            //Animation and randomization

                            // Randomization[1]
                            randomMinute = rastgele.Next(10, 51);
                            do //(Control for the letter and if letter = '0' re-assign)
                            {
                                randomLetter = rastgele.Next(0, 26);
                            } while (all_G_bags[0, randomLetter] == '0');

                            // Bag transfer[2]
                            transporter = all_G_bags[0, randomLetter];
                            all_G_bags[0, randomLetter] = '0';
                            all_G_bags[1, roundCounter] = transporter;

                            //Animation[3]
                            Console.SetCursorPosition(25, 12); //Writing the frame
                            Thread.Sleep(100); Console.Write("--------------------------------------------------");
                            Console.SetCursorPosition(26, 13);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("[?][?][?][?][?][?][?][?][?][?][?][?][?][?][?][?]");
                            Console.ResetColor();
                            for (int f = 0; f < 3; f++)
                            {
                                Thread.Sleep(100);
                                Console.SetCursorPosition(25, 13 + f);
                                Console.Write("|");
                                Console.SetCursorPosition(74, 13 + f);
                                Console.Write("|");
                            }
                            Console.SetCursorPosition(25, 16);
                            Thread.Sleep(100); Console.Write("--------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            for (int animationTime = 0; animationTime < randomMinute; animationTime++) //Moving sytsem
                            {
                                if (animationTime == 16) //(İf cursor at the end of the frame it'll go to the start)
                                { randomMinute = randomMinute - 16; animationTime = 0; }

                                Thread.Sleep(50);
                                Console.SetCursorPosition(27 + (3 * animationTime), 14);
                                Console.Write("^");
                                Console.SetCursorPosition(27 + (3 * animationTime), 15);
                                Console.Write("|");
                                Thread.Sleep(150);
                                Console.SetCursorPosition(27 + (3 * animationTime), 14);
                                Console.Write(" ");
                                Console.SetCursorPosition(27 + (3 * animationTime), 15);
                                Console.Write(" ");

                                if (animationTime + 1 == randomMinute) //(End of the timer (show the letter))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(27 + (3 * animationTime), 13);
                                    Console.Write(transporter);
                                    Console.SetCursorPosition(27, 15);
                                    Console.Write((roundCounter + 1) + ". letter is " + transporter);
                                    Console.ResetColor();
                                }
                            }
                            Console.ResetColor();

                            //Erase and Counter++[4]
                            Thread.Sleep(2000); //(Wait for players(they need to see))
                            for (int erase = 0; erase < 5; erase++)
                            {
                                Thread.Sleep(100);
                                Console.SetCursorPosition(25, 12 + erase);
                                Console.Write(space_43 + "       ");
                            }
                            roundCounter++;
                        }
                        if (Button.Key == ConsoleKey.Escape) //For exit
                        {
                            Console.SetCursorPosition(26, 7);
                            Console.Write(space_43);
                            Console.SetCursorPosition(26, 7);
                            Console.Write(">>> Do you want to exit? (press enter for exit)");
                            while (true)
                            {
                                if (Console.KeyAvailable)
                                {
                                    Button = Console.ReadKey(true);
                                    if (Button.Key == ConsoleKey.Enter)
                                    {
                                        for (int endscene = 0; endscene < 20; endscene++) //(Erase the terminal)
                                        {
                                            Thread.Sleep(100);
                                            Console.SetCursorPosition(0, 0 + endscene);
                                            Console.Write(space_43 + "                                     ");
                                        }
                                        Environment.Exit(exitCode: 666);//EXİT
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(30, 7);
                                        Console.Write(space_43);
                                        break;
                                    }
                                }
                            }
                        }

                    }

                    //Control for "çinko"[G4]
                    if (p1_çinko == true)//(For player-1)
                    {
                        for (int p1_çinko_control = 0; p1_çinko_control < 4; p1_çinko_control++)
                        {
                            for (int inner_p1_çinko_control = 0; inner_p1_çinko_control < all_G_bags.GetLength(1); inner_p1_çinko_control++)
                            {
                                if (all_G_bags[1, inner_p1_çinko_control] == all_P_bags[0, p1_çinko_control])
                                { p1_do1++; }
                                if (all_G_bags[1, inner_p1_çinko_control] == all_P_bags[0, 7 - p1_çinko_control])
                                { p1_do2++; }
                            }
                        }
                        if (p1_do1 == 4 || p1_do2 == 4)
                        {
                            p1_çinko = false;
                            P1_Money = P1_Money + 10;
                            Console.SetCursorPosition(26, 7);
                            Console.Write(">>> Player-1 makes '1.Cinko'");
                            Thread.Sleep(750);
                            Console.SetCursorPosition(26, 7);
                            Console.Write(space_43);
                        }
                        else
                        { p1_do1 = 0; p1_do2 = 0; }
                    }
                    if (p2_çinko == true)//(For player-2)
                    {
                        for (int p2_çinko_control = 0; p2_çinko_control < 4; p2_çinko_control++)
                        {
                            for (int inner_p2_çinko_control = 0; inner_p2_çinko_control < all_G_bags.GetLength(1); inner_p2_çinko_control++)
                            {
                                if (all_G_bags[1, inner_p2_çinko_control] == all_P_bags[1, p2_çinko_control])
                                { p2_do1++; }
                                if (all_G_bags[1, inner_p2_çinko_control] == all_P_bags[1, 7 - p2_çinko_control])
                                { p2_do2++; }
                            }
                        }
                        if (p2_do1 == 4 || p2_do2 == 4)
                        {
                            p2_çinko = false;
                            P2_Money = P2_Money + 10;
                            Console.SetCursorPosition(26, 7);
                            Console.Write(">>> Player-2 makes '1.Cinko'");
                            Thread.Sleep(750);
                            Console.SetCursorPosition(26, 7);
                            Console.Write(space_43);
                        }
                        else
                        { p2_do1 = 0; p2_do2 = 0; }
                    }

                    //Control for "Winner"[G5]
                    for (int winnerControl = 0; winnerControl < all_P_bags.GetLength(1); winnerControl++) //For Player-1
                    {
                        for (int inner_winnerControl = 0; inner_winnerControl < all_G_bags.GetLength(1); inner_winnerControl++)
                        {
                            if (all_P_bags[0, winnerControl] == all_G_bags[1, inner_winnerControl])
                            { p1_win++; }
                        }
                    }
                    if (p1_win != 8)
                    { p1_win = 0; }

                    for (int winnerControl = 0; winnerControl < all_P_bags.GetLength(1); winnerControl++) //For Player-2
                    {
                        for (int inner_winnerControl = 0; inner_winnerControl < all_G_bags.GetLength(1); inner_winnerControl++)
                        {
                            if (all_P_bags[1, winnerControl] == all_G_bags[1, inner_winnerControl])
                            { p2_win++; }
                        }
                    }
                    if (p2_win != 8)
                    { p2_win = 0; }

                    if (p1_win == 8 && p2_win != 8)
                    { P1_Money = P1_Money + 30; break; }
                    else if (p2_win == 8 && p1_win != 8)
                    { P2_Money = P2_Money + 30; break; }
                    else if (p2_win == 8 && p1_win == 8)
                    { P2_Money = P2_Money + 30; P1_Money = P1_Money + 30; break; }

                }

                //----------------------------------------------------------------------------------------------------------------------

                //Outro
                for (int endscene = 0; endscene < 20; endscene++) //(Erase the terminal)[OU1]
                {
                    Thread.Sleep(100);
                    Console.SetCursorPosition(0, 0 + endscene);
                    Console.Write(space_43 + "                                     ");
                }

                //Write the score table[OU2]
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, 0);
                Console.Write("-----------------------------------");
                Console.SetCursorPosition(0, 1);
                Console.Write("|Player-1: " + P1_Money + "$    Player-2: " + P2_Money + "$ |");
                Console.SetCursorPosition(0, 2);
                Console.Write("-----------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, 3);
                Console.Write("-PRESS THE 'R' BUTTON FOR PLAY AGAIN-");

                //Write the winner[OU3]
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, 6);
                if (p1_win == 8)
                { Console.WriteLine(@"
___  _    ____ _   _ ____ ____    ____ _  _ ____    _ _ _ _ _  _ 
|__] |    |__|  \_/  |___ |__/ __ |  | |\ | |___    | | | | |\ | 
|    |___ |  |   |   |___ |  \    |__| | \| |___    |_|_| | | \| 
                                                                 "); }

                if (p2_win == 8)
                {
                    Console.WriteLine(@"
___  _    ____ _   _ ____ ____    ___ _ _ _ ____    _ _ _ _ _  _ 
|__] |    |__|  \_/  |___ |__/ __  |  | | | |  |    | | | | |\ | 
|    |___ |  |   |   |___ |  \     |  |_|_| |__|    |_|_| | | \| 
                                                                 ");
                }

                if (p2_win == 8 && p1_win == 8)
                {
                    Console.WriteLine(@"
___ _ ____ 
 |  | |___ 
 |  | |___ 
           ");

                }
                Console.ResetColor();

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        Button = Console.ReadKey(true);

                        if (Button.Key == ConsoleKey.R)
                        {
                            //RE-ASSİGN
                            roundCounter = 0;
                            p1_win = 0; p2_win = 0;
                            p1_çinko = true; p2_çinko = true; p1_do1 = 0; p1_do2 = 0; p2_do1 = 0; p2_do2 = 0;
                            P1_Money = 0; P2_Money = 0;
                            all_G_bags = new char[,] { { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }, { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' } };
                            control1 = true; control2 = true;

                            for (int endscene = 0; endscene < 20; endscene++) //(Erase the terminal)
                            {
                                Thread.Sleep(100);
                                Console.SetCursorPosition(0, 0 + endscene);
                                Console.Write(space_43 + "                                     ");
                            }
                            again = true; break;//Play again
                        }
                        else
                        {
                            again = false; break;//EXİT
                        }
                    }
                }

            } while (again == true);

        }
    }
}
