
using BlazorBattleship.Shared;

namespace BlazorBattleship.GameClassLib
{
    class CompOpponent
    {
        private List<(int, int)> previousShots = new List<(int, int)>(); // Stores previous shots
        private bool[,] board = new bool[10, 10]; // 10x10 board of ship locations
        public int life; // Number of ship sections remaining
        
        public CompOpponent(int shipNum)
        {
            //string playerName = "Opponent";
            Ship[] ships = new Ship[shipNum];
            this.CreateShips(ships, shipNum);
            life = (shipNum * (shipNum + 1)) / 2;
        }

        struct Ship
        {
            public int x, y, length;
            public bool vertical;
        }

        private void CreateShips(Ship[] ships, int shipNum)
        {
            return;
        }

        public void TakeTurn(Player opponent)
        {
            return;
        }
        
        bool CheckShot(Player opponent, (int, int) shotCoordinate)
        {
            return false;
        }
    }
}