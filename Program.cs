using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int currentPlayer = 1; // Player 1 starts

        static void Main(string[] args)
        {
            int choice;
            bool gameEnded = false;

            do
            {
                // Draw the board
                DrawBoard();

                // Get the player's choice
                Console.WriteLine($"Player {currentPlayer}, enter your choice:");
                choice = int.Parse(Console.ReadLine());

                // Update the board
                if (choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    board[choice - 1] = currentPlayer == 1 ? 'X' : 'O';

                    // Check if the game has ended
                    gameEnded = CheckForWin() || CheckForDraw();

                    // Switch to the other player
                    currentPlayer = currentPlayer == 1 ? 2 : 1;
                }
                else
                {
                    Console.WriteLine("Invalid move! Please choose an available cell.");
                }

            } while (!gameEnded);

            // Draw the board one final time
            DrawBoard();

            // Declare the winner or a draw
            if (CheckForWin())
            {
                Console.WriteLine($"Player {currentPlayer} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

            Console.ReadLine();
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }

        static bool CheckForWin()
        {
            // Check rows, columns, and diagonals
            return (board[0] == board[1] && board[1] == board[2]) ||
                   (board[3] == board[4] && board[4] == board[5]) ||
                   (board[6] == board[7] && board[7] == board[8]) ||
                   (board[0] == board[3] && board[3] == board[6]) ||
                   (board[1] == board[4] && board[4] == board[7]) ||
                   (board[2] == board[5] && board[5] == board[8]) ||
                   (board[0] == board[4] && board[4] == board[8]) ||
                   (board[2] == board[4] && board[4] == board[6]);
        }

        static bool CheckForDraw()
        {
            // Check if the board is full
            foreach (var cell in board)
            {
                if (cell != 'X' && cell != 'O')
                    return false;
            }
            return true;
        }
    }
}

