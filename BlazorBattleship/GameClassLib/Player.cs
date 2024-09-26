namespace BlazorBattleship.GameClassLib
{
    class Player
    {
        private List<(int, int)> previousShots = new List<(int, int)>(); //Stores a list of previous shots, so that the player cannot shoot at the same coordinate twice
        private bool[,] board = new bool[10, 10]; // 10x10 board to store the ship locations
        public int life; // Number of ship sections remaining
        public Player(int shipNum, string name) //Player constructor that takes the number of ships and the player name as arguments
        {
            string playerName = name; //Player name
            Ship[] ships = new Ship[shipNum]; //List of ships
            this.CreateShips(ships, shipNum); //Creates the ship objects and places them on the board
            life = (shipNum * (shipNum + 1)) / 2; //Life is derived from the number of ships
        }
        struct Ship
        {
            public int x; // The x-coordinate of the ship.
            public int y; // The y-coordinate of the ship.
            public int length; // The length of the ship.
            public bool vertical; // Orientation of the ship; true if vertical
        }

        // Method to create and place ships on the board.
        private void CreateShips(Ship[] ships, int shipNum)
        {
            for (int i = 0; i < shipNum; i++)
            {
                // Prompt the player to enter the starting x-coordinate of the ship.
                Console.WriteLine("Enter the x coordinate of ship " + (i + 1) + ": ");
                int x = Convert.ToInt32(Console.ReadLine());
                // Prompt the player to enter the starting y-coordinate of the ship.
                Console.WriteLine("Enter the y coordinate of ship " + (i + 1) + ": ");
                int y = Convert.ToInt32(Console.ReadLine());

                int length = i + 1;  // Determine the length of the ship based on its index (lengths start from 1).

                Console.WriteLine("Enter the orientation of ship " + (i + 1) + " (vertical/horizontal): "); // Prompt the player to enter the orientation of the ship.
                string? orientation = Console.ReadLine();
                
                // Set the ship's orientation based on player input.
                if (orientation == "vertical")
                {
                    ships[i].vertical = true;
                }
                else
                {
                    ships[i].vertical = false;
                }

                //Placing ships on the board
                if (ships[i].vertical)
                {
                    for (int j = 0; j < length; j++)
                    {
                        board[x, y + j] = true;//Board spaces are set to true, to indicate that a ship is present
                    }
                }
                else
                {
                    for (int j = 0; j < length; j++)
                    {
                        board[x + j, y] = true;
                    }
                }
            }
        }

        
        // Method for the player to take a turn by shooting at the opponent's board.
        public void TakeTurn(Player opponent)
        {
            // Prompt the player to enter the x-coordinate of their shot.
            Console.WriteLine("Enter the x coordinate of your shot: ");
            int shotX = Convert.ToInt32(Console.ReadLine());
            
            // Prompt the player to enter the y-coordinate of their shot.
            Console.WriteLine("Enter the y coordinate of your shot: ");
            int shotY = Convert.ToInt32(Console.ReadLine());
            
            // Create a tuple to represent the shot coordinates.
            (int, int) shotCoordinate = (shotX, shotY);
            this.CheckShot(opponent, shotCoordinate);

            // Check if the player has already shot at this coordinate.
            if (previousShots.Contains(shotCoordinate))
            {
                // Inform the player and allow them to take the turn again
                Console.WriteLine("You have already shot at this coordinate. Please try again.");
                this.TakeTurn(opponent); // Recursively call TakeTurn to retry.
            }
            else
            {
                // Add the shot to the list of previous shots.
                previousShots.Add(shotCoordinate);

                // Check if the shot is a hit or miss.
                CheckShot(opponent, shotCoordinate);
            }
        }


        // Method to check if a shot hits an opponent's ship.
        bool CheckShot(Player opponent, (int, int) shotCoordinate)
        {
            if (opponent.board[shotCoordinate.Item1, shotCoordinate.Item2])
            {
                // Check if the shot hits a ship on the opponent's board.
                Console.WriteLine("Hit!");
                opponent.board[shotCoordinate.Item1, shotCoordinate.Item2] = false; //Board space is set to false, to indicate that the ship section has been hit (Shouldn't be needed, but just in case the  player can somehow shoot at the same coordinate twice)
                opponent.life--;//Life is deducted from the opponent
                return true;
            }
            else
            {
                Console.WriteLine("Miss!");
                return false;
            }
        }
    }
}
