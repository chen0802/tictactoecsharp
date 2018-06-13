using System;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        private static string [] position = new string[9];
        private static string Player1Text = "O";
        private static string Player2Text = "X";
        static void Main(string[] args)
        {

            string curPlayer = Player1Text;
            bool inputCorrect = true;
            string input;

            InitPosition(position);

            DrawBoard();

            while(!CheckWinner() && !FinishAll()) {

                do {

                    inputCorrect = true;

                    input = Console.ReadLine();

                    if ((input == "1") && (position[0] == "1"))
                    {
                        position[0] = curPlayer;
                    }
                    else if ((input == "2") && (position[1] == "2"))
                    {
                        position[1] = curPlayer;
                    }
                    else if ((input == "3") && (position[2] == "3"))
                    {
                        position[2] = curPlayer;
                    }
                    else if ((input == "4") && (position[3] == "4"))
                    {
                        position[3] = curPlayer;
                    }
                    else if ((input == "5") && (position[4] == "5"))
                    {
                        position[4] = curPlayer;
                    }
                    else if ((input == "6") && (position[5] == "6"))
                    {
                        position[5] = curPlayer;
                    }
                    else if ((input == "7") && (position[6] == "7"))
                    {
                        position[6] = curPlayer;
                    }
                    else if ((input == "8") && (position[7] == "8"))
                    {
                        position[7] = curPlayer;
                    }
                    else if ((input == "9") && (position[8] == "9"))
                    {
                        position[8] = curPlayer;
                    } else {
                        inputCorrect = false;
                        Console.WriteLine("Invalid input");
                    }
                } while (!inputCorrect);

                //next player's turn
                if (curPlayer == Player1Text)
                {
                    curPlayer = Player2Text;
                } 
                else 
                {
                    curPlayer = Player1Text;
                }

                DrawBoard();
            }
        }

        private static void InitPosition(string [] pos)
        {
            for (int i=0; i<9; i++)
            {
                pos[i] = (i+1).ToString();
            }
        }
        private static void DrawBoard() 
        {
            Console.WriteLine("");
            Console.WriteLine(position[0] + "|" + position[1] + "|" + position[2]);
            Console.WriteLine(position[3] + "|" + position[4] + "|" + position[5]);
            Console.WriteLine(position[6] + "|" + position[7] + "|" + position[8]);
            Console.WriteLine("");
        }

        private static bool CheckWinner()
        {
            return (CheckLine(position[0], position[1], position[2]) || 
                    CheckLine(position[3], position[4], position[5]) || 
                    CheckLine(position[6], position[7], position[8]) ||
                    CheckLine(position[0], position[3], position[6]) || 
                    CheckLine(position[1], position[4], position[7]) || 
                    CheckLine(position[2], position[5], position[8]) ||
                    CheckLine(position[0], position[4], position[8]) || 
                    CheckLine(position[2], position[4], position[6]));
        }

        private static bool CheckLine(string val1, string val2, string val3)
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
        private static bool FinishAll() 
        {
            if ((position[0] != "1") && (position[1] != "2") && (position[2] != "3") &&
                (position[3] != "4") && (position[4] != "5") && (position[5] != "6") &&
                (position[6] != "7") && (position[7] != "8") && (position[8] != "9"))
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