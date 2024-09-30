**Documentation for Project 2**  
(by Abhishek Bhatt)

# **EECS 581 Project 2 Battleship**

Battleship is a 2-player game where each player can position ships of various sizes (identical to their opponent's fleet) wherever they wish on a grid-based board.  
During each round, the active player selects a grid position to fire at. If the chosen grid position aligns with an enemy ship's, that ship is damaged.  
Once every slot of a given ship has been hit, the ship will sink.  
Once all ships of a given player have been sunk, the game ends, and the player with one or more remaining ships is declared the winner.  
This game is designed to be run on either a single device or on two devices & players are expected to hand off control of the device between rounds. Players can also chat with one another and if they want to play solo, they can choose the difficulty level of the computer.

**Prerequisites:** 

* Software:  
  * .Net 6 or newer versions \- required to build and run the game.  
  * Blazor WebAssembly  
  * SignalR Server \- relies on a SignalR hub

**How to run the application:**

* Navigate to the repository  
* Use the terminal/command line to navigate to the BlazorBattleship folder.  
* Run the “dotnet restore” command to restore the required packages.  
* Build the application using the “dotnet build” command to compile the application.  
* If this is the first time running the project, run this command before the next step: “dotnet dev-certs https \--trust”.   
  * Do not use this command if this is not the first time running the application.  
  * **Note:** This command only works automatically on Windows and MacOS. This does not work on Linux.  
* Use the “dotnet run” command to run the application.  
* Copy one of localhost connections {port} into your search bar on your web browser by navigating to “https://localhost:{port}/ ”.


 **Time Estimate (person-hours)**

* Abhishek (Documentation) \= 11 hours  
* Andrew (Coding/UML Diagram/Error Fixing) \= 16.5 hours  
* Collins (Coding/Assets/Testing) \=  11 hours  
* Mikaela (Coding) \= 20 hours  
* Samuel (Coding) \= 19  hours

September 19:

* Received project from team 23\. 

September 21:

* Tested out the project given. It was done in HTML, CSS, and C\# by Team 23\. It requires Blazor, .NET 6 SDK, and SignalR server for running the game.  
* We determined that we could add sound to the given project. Andrew to add those in.  
* Still trying to figure out the roles of what each person in the team can do.   
* Samuel and Mikaela to work on levels. Samuel to work on the cheater level. Mikaela is on the easy and medium levels.   
* Abhishek to do the documentation.  
* Time Accounting:  
  * Samuel: 1 hour  
  * Andrew: 1.5 hours  
  * Abhishek: 1 hour

September 22:

* Still trying to figure out fully how the project code works.   
* Still trying to figure out how to add the audio into the game.   
* Andrew completed the UML diagram for the project.  
* Found it to be useful if we modularize the code.  
* Collins to work on testing the project.   
* Noticed issues in the project:  
  * Win state is broken.  
  * Ships can be placed on top of each other.  
  * Boards are overlapping.  
  * There are weather forecast files in there for some reason.  
  * The game doesn’t have an end state.  
  * Lack of documentation; missing a lot of details. No documentation folder either.   
* Time Accounting:  
  * Samuel: 2 hours  
  * Mikaela: 2 hours  
  * Andrew: 1.5 hours  
  * Collins: 2 hours  
  * Abhishek: 1 hour

September 23: 

* Had a meeting with the GTA to discuss the complexities of the project.  
* Time Accounting:  
  * No one worked on the project that day\!

September 24: 

* Collins fixed the overlapping issue with the game boards.   
* Andrew finished putting in the sounds for the game.  
* Samuel removed the weather forecasting files  
* Found out that there is no cap on how many ships can be placed in the game.  
* Time accounting:  
  * Collins: 4 hours  
  * Samuel: 6.5 hours  
  * Andrew 2 hours  
  * Mikaela: 4 hours

September 25:

* Placed a cap on ships put into the game. Only between 1 and 5 ships can be placed into the game.   
* Things needed next were:  
  * Setting up COM’s board of ships   
  * Enabling gameplay, starting with the Player’s turn  
  * Making COM’s gameplay functionality, with the three difficulties in mind  
  * Ensure that a win condition works.  
* ⅓ of the way done with the AI feature.   
* Found out that Player.cs and Game.cs do nothing.  
* Created a branch called refactoring.  
* Time Accounting:  
  * Abhishek: 0.5 hour  
  * Mikaela: 4 hours  
  * Samuel: 4.5 hours  
  * Andrew: 2 hours

September 26:

* Mikaela added the option for the player to choose difficulty.  
* The game end condition is working, but the UI still had to be added in.   
* Time accounting:  
  * Andrew: 2 hours  
  * Abhishek: 0.5 hour  
  * Mikaela: 2 hours

September 27:

* Andrew completed the game conditions for the game.  
* Andrew fixed the firing after game over flaw.  
* Created a single-player branch.  
* Added more sound to the project.  
* Mikaela attempted StartSingleplayer() to start the single-player game, declare the computer’s board, and place ships (according to the number of ships the player chose).  
* Time accounting:  
  * Andrew: 1.5 hours  
  * Abhishek: 1 hour  
  * Mikaela: 2 hours

September 28:

* Abhishek began documenting the code.  
* Andrew created a function that just checks if all CPU ships are sunk for the single-player branch called areAllCPUShipsSunk().  
* Mikaela worked on StartSingleplayer() and the computer’s board is set up and ready. Worked on Fire\_Singleplayer(), HitChecker(), and ComputerTurn(), with Samuel. Then she fixed the difficulty option and worked on easy and hard modes.   
* Testing out the project to find errors in it.   
* Time Accounting:   
  * Abhishek: 3 hours  
  * Samuel: 4 hours  
  * Mikaela: 5 hours  
  * Collins: 4 hours  
  * Andrew : 3.5 hours

September 29:

* Tested out medium mode.  
* Fixed comments and descriptions.  
* Collins finished medium difficult mode.  
* Got the sound to work & added in win/lose sounds.   
* Added delay to triggering sounds if the AI/players make a hit at the same time.   
* Edited deploy button.  
* Added a feature where the player cannot pick the same spot multiple times in singleplayer.  
* Fixed the “Leave Room” feature in singleplayer.
* Merged the singleplayer branch into the main branch.
* Time Accounting:  
  * Mikaela: 1 hour  
  * Abhishek: 4 hours  
  * Samuel: 1 hour  
  * Andrew: 2.5 hours  
  * Collins: 1 hour

**Code:**

* Index.razor:  
  * Provides functionality on the webpage for different game states.  
  * Inputs: Current game state, username, tiles selected by players, & ships.  
  * Outputs: Different board states, & player ships.   
  * Uses both HTML & JavaScript to do this.  
  * Functions:  
    * Private void ResetBoard(bool\[,\] board)  
      * Resets the game board by looping through all the tiles in it.  
    * Private void Reset()  
      * Resets the rest of the game.  
    * Private void SetCoordinates(int x, int y)  
      * Sets the value of the coordinates tuple for later use  
    * Private void ToggleShipOrientation()  
      * Toggle ship orientation boolean to track whether or not a placed ship is vertical or horizontal  
    * Private string GetCellClass(int x, int y)  
      * Changes the type of grid space depending on whether or not a ship is currently there.   
      * This allows for the preview to not override existing ships on the setup board.  
    * Private void ShowShipPreview(int startX, int startY, bool isHorizontal)  
      * Displays a preview of the ship placement starting at the given coordinates and in the chosen orientation.  
    * private void HideShipPreview(int startX, int startY, bool isHorizontal)  
      *  Hides the ship preview from the board clearing preview cells.  
    * private void PlaceShip(int startX, int startY, bool isHorizontal)  
      * Places a ship at given coords and updates the board and ship count.  
    * private string OpponentBoardInfo(int x, int y)  
      * Return the css class for the opponents board tiles based on the game state.  
    * private void SelectDifficulty(int difficulty)  
      * Allows the player to see the computer’s difficulty.  
    * private void StartSingleplayer()  
      * Sets up the Computer opponent's board, then declares itself as ready.  
    * private bool tryPlaceShips(int startX, int startY, int shipLength, bool isHorizontal)  
      * Check if the ship placement is valid.   
    * private async Task Fire\_Singleplayer()  
      * Allows the single-player to fire shots.  
    * private async Task\<bool\> HitChecker(bool isPlayer, int x, int y)  
      * Check if the singleplayer made a hit or not.  
    * private string GetCoordinatesText()  
      * Helper function to display the selected coordinates in the text box.  
    * protected override async Task OnInitializedAsync()  
      * Runs when the client connects by creating a new connection to the hub.  
      * hubConnection.On\<List\<List\<string\>\>\>("ReceiveRooms", (playersInRooms) \=\>  
        * when a new user has joined ANY of the rooms, update the page to show the new user in their room  
      *  hubConnection.On\<string\>("PlayerLeft", (user) \=\>  
        * When a player leaves the room.  
      *  hubConnection.On("ReceiveShipSunk", () \=\>  
        * Notifies when an opponent ship has sunk,  
      * hubConnection.On\<int\>("ReceiveShipNum", (sl) \=\>  
        * when ship number is received from opponent  
      *  hubConnection.On("ReceiveReadyMessage", () \=\>  
        *  when opponent wants to start game  
      * hubConnection.On("ReceiveGameOverWin", () \=\>  
        * when a user and message are received from the connection…  
      * hubConnection.On\<string, int, int\>("ReceiveCoordinates", async (user, x, y) \=\>  
        * When an opponent fires a shot.  
      * hubConnection.On\<bool\>("ShotResponse", async (wasHit) \=\>  
        * Handles a response from the opponent when firing.  
    * private bool AreAllShipsSunk(Ship\[\] ships)  
      * Check each ship to see if it is destroyed or not.  
    *  private async Task JoinRoom(int roomNum)  
      * Allows players to join room.  
    * private async Task LeaveRoom()  
      * Allows players to leave room.  
    *  private async Task SendShipNum()  
      * Sends number of ships to the server.  
    * private async Task SendReadyMessage()  
      * Signals server when player is ready.  
    * private async Task Fire()  
      * Sends shot coordinates to the server.  
    *  public async ValueTask DisposeAsync()  
      * Shuts down the server connection.  
* Error.cshtml  
  * Codes the outline for the development mode of the game.  
* Error.cshtml.cs  
  * Functions/Constructors:  
    * public class ErrorModel : PageModel  
      * This defines the ErrorModel class, which inherits from PageModel. The PageModel class provides the base functionality for Razor Pages.  
    *  private readonly ILogger\<ErrorModel\> \_logger;  
      * This field stores a logger instance.  
    *  public ErrorModel(ILogger\<ErrorModel\> logger)  
      * This constructor initializes the `_logger` field with the provided logger instance.  
    * public void OnGet()  
      * This method is called when the error page is accessed via a GET request. It sets the `RequestId` property to the current activity ID or the HTTP context trace identifier.  
* Counter.razor  
  * Function:  
    * private void IncrementCount()  
      * Increments a counter.  
* Battleship.razor  
  * Functions:  
    * public void setCoordinates()  
      * Sets the coordinates of the battleship.  
      *   protected override async Task OnInitializedAsync()  
        * Runs when the client connects by creating a new connection to the hub.  
      *    hubConnection.On\<string, string\>("ReceiveCoordinates", (user, coordinates) \=\>  
        * when a user and message are received from the connection…  
      * hubConnection.On\<string, string, bool\>("ReceiveFireInformation", (user, coordinates, wasHit) \=\>  
        * Receives information regarding the shot that was fired and if it hit a ship or not.   
    *  private async Task Fire()  
      * Fires a shot.  
    *  public async ValueTask DisposeAsync()  
      * Disconnects the connection.  
* ChatHub.cs  
  * Class:  
    *   public class ChatHub : Hub  
      * Allows players that joined a room to chat with one another.  
      * Sends messages to all clients in the same room.  
  * Functions:  
    *  public async Task SendShipNum(int room, int shipLimit)  
      * Send number of ships to be placed to all users.  
    *  public async Task SendReadyMessage(int room, int shipLimit)  
      * Send ready message to other users.  
    *  public async Task GetRooms()  
      * Get current status of rooms and send it to all users.  
    *  public async Task JoinRoom(string user, int room)  
      * Given user joins selected room.  
    * public async Task LeaveRoom(string user, int room)  
      * Remove the player for the room.  
    * public async Task SendCoordinates(string user, int room, int x, int y)  
      *  Send coordinates of player shots to the opponent in the same room.  
    *  public async Task SendHitMiss(int room, bool wasHit)  
      * Send the result hit/miss to the opponent in the specified room.  
    * public async Task SendMessage(string userName, string message)  
      * Send a chat message to all users.  
    *  public async Task SendGameOver(int room)  
      * Notify all clients in the room that the game is over.  
* Player.cs  
  * Class Player  
    * Manages the player’s side of the game.  
  * Functions/Structs  
    *  struct Ship  
      * Variables:   
        * public int x: The x-coordinate of the ship  
        * public int y: The y-coordinate of the ship  
        * public int length: The length of the ship  
        * public bool vertical: Orientation of the ship; true if vertical  
    * private void CreateShips(Ship\[\] ships, int shipNum)  
      * Method to create and place ships on the board.  
    * public void TakeTurn(Player opponent)  
      *  Method for the player to take a turn by shooting at the opponent's board.  
    * bool CheckShot(Player opponent, (int, int) shotCoordinate)  
      *  Method to check if a shot hits an opponent's ship.  
* Program.cs  
  * Allows the connection to the server via Microsoft.AspNet.  
* Site.css  
  * Provides the styles of the game.
