using System;

namespace TicTacToe
{
    class Program
    {
        private static string A = "1";
        private static string B = "2";
        private static string C = "3";
        private static string D = "4";
        private static string E = "5";
        private static string F = "6";
        private static string G = "7";
        private static string H = "8";
        private static string I = "9";
        private static string Player1Text = "O";
        private static string Player2Text = "X";
        static void Main(string[] args)
        {

            string curPlayer = Player1Text;
            bool inputCorrect = true;

            print();

            while(!checkWinner() && !finishAll()) {

                string input = Console.ReadLine();

                inputCorrect = true;

                if ((input == "1") && (A == "1"))
                {
                    A = curPlayer;
                }
                else if ((input == "2") && (B == "2"))
                {
                    B = curPlayer;
                }
                else if ((input == "3") && (C == "3"))
                {
                    C = curPlayer;
                }
                else if ((input == "4") && (D == "4"))
                {
                    D = curPlayer;
                }
                else if ((input == "5") && (E == "5"))
                {
                    E = curPlayer;
                }
                else if ((input == "6") && (F == "6"))
                {
                    F = curPlayer;
                }
                else if ((input == "7") && (G == "7"))
                {
                    G = curPlayer;
                }
                else if ((input == "8") && (H == "8"))
                {
                    H = curPlayer;
                }
                else if ((input == "9") && (I == "9"))
                {
                    I = curPlayer;
                } else {
                    inputCorrect = false;
                    Console.WriteLine("Invalid input");
                }

                if (inputCorrect) {
                    //next player's turn
                    if (curPlayer == Player1Text)
                    {
                        curPlayer = Player2Text;
                    } 
                    else 
                    {
                        curPlayer = Player1Text;
                    }
                }

                print();
            }

        }
        private static void print() 
        {
            Console.WriteLine("");
            Console.WriteLine(A + "|" + B + "|" + C);
            Console.WriteLine(D + "|" + E + "|" + F);
            Console.WriteLine(G + "|" + H + "|" + I);
            Console.WriteLine("");
        }

        private static bool checkWinner()
        {
            // A B C
            // D E F
            // G H I
            return (checkLine(A, B, C) || checkLine(D, E, F) || checkLine(G, H, I) ||
                    checkLine(A, D, G) || checkLine(B, E, H) || checkLine(C, F, I) ||
                    checkLine(A, E, I) || checkLine(C, E, G));
        }

        private static bool checkLine(string val1, string val2, string val3)
        {
            bool won = (((val1 == Player1Text) || (val1 == Player2Text)) &&
                ((val2 == Player1Text) || (val2 == Player2Text)) &&
                ((val3 == Player1Text) || (val3 == Player2Text)) &&
                (val1 == val2) && (val2 == val3));

            if (won)
            {
                if (val1 == Player1Text)
                {
                    Console.WriteLine("Winner Player 1");
                }
                else 
                {
                    Console.WriteLine("Winner Player 2");
                }
            }
            return won;
        }
        private static bool finishAll() 
        {
            if ((A != "1") && (B != "2") && (C != "3") &&
                (D != "4") && (E != "5") && (F != "6") &&
                (G != "7") && (H != "8") && (I != "9"))
            {
                Console.WriteLine("Nobody won");
                return true;
            } 
            else 
            {
                return false;
            }
        }
    }
}

/*

class Program
{
    static string[] pos = new string[10] { "0", "1", "2","3","4","5","6","7","8","9" }; // Array that contains board positions, 0 isnt used --------------------------------

    static void DrawBoard() // Draw board method ==========================================
    {
        Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[1], pos[2], pos[3]);
        Console.WriteLine("-------------------");
        Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[4], pos[5], pos[6]);
        Console.WriteLine("-------------------");
        Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[7], pos[8], pos[9]);
    }

    static void Main(string[] args) // Main ==============================================
    {
        string player1 = "", player2 = "";
        int choice = 0, turn = 1, score1 = 0, score2 = 0;
        bool winFlag = false, playing = true, correctInput = false;

        Console.WriteLine("Hello! This is Tic Tac Toe. If you don't know the rules then stop being an idiot.");
        Console.WriteLine("What is the name of player 1?");
        player1 = Console.ReadLine();
        Console.WriteLine("Very good. What is the name of player 2?");
        player2 = Console.ReadLine();
        Console.WriteLine("Okay good. {0} is O and {1} is X." , player1, player2);
        Console.WriteLine("{0} goes first." , player1);
        Console.ReadLine();
        Console.Clear();

        while (playing == true)
        {
            while (winFlag == false) // Game loop ------------------------------------------------------
            {
                DrawBoard();
                Console.WriteLine("");

                Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                if (turn == 1)
                {
                    Console.WriteLine("{0}'s (O) turn", player1);
                }
                if (turn == 2)
                {
                    Console.WriteLine("{0}'s (X) turn", player2);
                }

                while (correctInput == false)
                {
                    Console.WriteLine("Which position would you like to take?");
                    choice = int.Parse(Console.ReadLine());
                    if (choice > 0 && choice < 10)
                    {
                        correctInput = true;
                    }
                    else
                    {
                        continue;
                    }
                }

                correctInput = false; // Reset -------

                if (turn == 1)
                {
                    if (pos[choice] == "X") // Checks to see if spot is taken already --------------------
                    {
                        Console.WriteLine("You can't steal positions asshole! ");
                        Console.Write("Try again.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        pos[choice] = "O";
                    }
                }
                if (turn == 2)
                {
                    if (pos[choice] == "O") // Checks to see if spot is taken already -------------------
                    {
                        Console.WriteLine("You can't steal positions asshole! ");
                        Console.Write("Try again.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        pos[choice] = "X";
                    }
                }

                winFlag = CheckWin();

                if (winFlag == false)
                {
                    if (turn == 1)
                    {
                        turn = 2;
                    }
                    else if (turn == 2)
                    {
                        turn = 1;
                    }
                    Console.Clear();
                }
            }

            Console.Clear();

            DrawBoard();

            for (int i = 1; i < 10; i++) // Resets board ------------------------
            {
                pos[i] = i.ToString();
            }

            if (winFlag == false) // No one won ---------------------------
            {
                Console.WriteLine("It's a draw!");
                Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                Console.WriteLine("");
                Console.WriteLine("What would you like to do now?");
                Console.WriteLine("1. Play again");
                Console.WriteLine("2. Leave");
                Console.WriteLine("");

                while (correctInput == false)
                {
                    Console.WriteLine("Enter your option: ");
                    choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 3)
                    {
                        correctInput = true;
                    }
                }

                correctInput = false; // Reset -------------

                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!");
                        Console.ReadLine();
                        playing = false;
                        break;
                }
            }

            if (winFlag == true) // Someone won -----------------------------
            {
                if(turn == 1)
                {
                    score1++;
                    Console.WriteLine("{0} wins!" , player1);
                    Console.WriteLine("What would you like to do now?");
                    Console.WriteLine("1. Play again");
                    Console.WriteLine("2. Leave");

                    while (correctInput == false)
                    {
                        Console.WriteLine("Enter your option: ");
                        choice = int.Parse(Console.ReadLine());

                        if (choice > 0 && choice < 3)
                        {
                            correctInput = true;
                        }
                    }

                    correctInput = false; // Reset --------------

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            winFlag = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                            playing = false;
                            break;
                    }
                }

                if (turn == 2)
                {
                    score2++;
                    Console.WriteLine("{0} wins!" , player2);
                    Console.WriteLine("What would you like to do now?");
                    Console.WriteLine("1. Play again");
                    Console.WriteLine("2. Leave");

                    while (correctInput == false)
                    {
                        Console.WriteLine("Enter your option: ");
                        choice = int.Parse(Console.ReadLine());

                        if (choice > 0 && choice < 3)
                        {
                            correctInput = true;
                        }
                    }

                    correctInput = false; // Reset -----------------

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            winFlag = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                            playing = false;
                            break;
                    }
                }
            }
        }
    }

    static bool CheckWin() // Win checker method ================================================
    {
        if (pos[1] == "O" && pos[2] == "O" && pos[3] == "O") // Horizontal ----------------------------------------
        {
            return true;
        }
        else if (pos[4] == "O" && pos[5] == "O" && pos[6] == "O")
        {
            return true;
        }
        else if(pos[7] == "O" && pos[8] == "O" && pos[9] == "O")
        {
            return true;
        }

        else if(pos[1] == "O" && pos[5] == "O" && pos[9] == "O") // Diagonal -----------------------------------------
        {
            return true;
        }
        else if(pos[7] == "O" && pos[5] == "O" && pos[3] == "O")
        {
            return true;
        }

        else if(pos[1] == "O" && pos[4] == "O" && pos[7] == "O")// Coloumns ------------------------------------------
        {
            return true;
        }
        else if(pos[2] == "O" && pos[5] == "O" && pos[8] == "O")
        {
            return true;
        }
        else if(pos[3] == "O" && pos[6] == "O" && pos[9] == "O")
        {
            return true;
        }

        if (pos[1] == "X" && pos[2] == "X" && pos[3] == "X") // Horizontal ----------------------------------------
        {
            return true;
        }
        else if (pos[4] == "X" && pos[5] == "X" && pos[6] == "X")
        {
            return true;
        }
        else if (pos[7] == "X" && pos[8] == "X" && pos[9] == "X")
        {
            return true;
        }

        else if (pos[1] == "X" && pos[5] == "X" && pos[9] == "X") // Diagonal -----------------------------------------
        {
            return true;
        }
        else if (pos[7] == "X" && pos[5] == "X" && pos[3] == "X")
        {
            return true;
        }

        else if (pos[1] == "X" && pos[4] == "X" && pos[7] == "X") // Coloumns ------------------------------------------
        {
            return true;
        }
        else if (pos[2] == "X" && pos[5] == "X" && pos[8] == "X")
        {
            return true;
        }
        else if (pos[3] == "X" && pos[6] == "X" && pos[9] == "X")
        {
            return true;
        }
        else // No winner ----------------------------------------------
        {
            return false;
        }
    }
}
 */