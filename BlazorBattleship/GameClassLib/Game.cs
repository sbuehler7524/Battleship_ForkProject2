namespace BlazorBattleship.GameClassLib
{
    class Game
    {
        // The Start method initializes the game and manages the game loop.
        public void Start()
        {
            // Display a welcome message to the players.
            Console.WriteLine("Welcome to Battleship!");
            // Prompt the user to choose the number of ships.
            Console.WriteLine("Choose the number of ships you want to play with: ");
            // Read the user's input and convert it to an integer representing the number of ships.
            int shipNum = Convert.ToInt32(Console.ReadLine());
            // Check if player is playing against a computer
            bool playVsComp = false;
            // Create two Player instances with the specified number of ships and assign names.
            var player1 = new Player(shipNum, "Player 1");
            var player2;
            if (!playVsComp) // If human opponent
            {
                player2 = new Player(shipNum, "Player 2"); // Assign other player
            }
            else // Else, comp opponent
            {
                player2 = new CompOpponent(shipNum); // Assign computer opponent
            }
            
            // Start the main game loop.
            while (true)
            {
                // Player 1 takes a turn attacking Player 2.
                player1.TakeTurn(player2);
                // Check if Player 2 has no ships (life) remaining.
                if (player2.life == 0)
                {
                    Console.WriteLine("Player 1 wins!");
                    break; // Exit the game loop.
                }
                player2.TakeTurn(player1);
                // Check if Player 1 has no ships (life) remaining.
                if (player1.life == 0)
                {
                    Console.WriteLine("Player 2 wins!");
                    break;
                }
            }
        }
    }
}
