using BlazorBattleship.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
namespace BlazorBattleship.Hubs
{
    public class ChatHub : Hub
    {
        //private static int[] roomCounts = { 0, 0, 0, 0, 0 };
        // list to store players in each room
        private static List<List<string>> playersInRooms = new List<List<string>>();

        // send number of ships to be placed to all users
        public async Task SendShipNum(int room, int shipLimit)
        {
            await Clients.Group($"Room {room}").SendAsync("ReceiveShipNum", shipLimit);
        }

        // send ready message to other users
        public async Task SendReadyMessage(int room, int shipLimit)
        {
            await Clients.OthersInGroup($"Room {room}").SendAsync("ReceiveReadyMessage");
        }

        // get current status of rooms and send to all users
        public async Task GetRooms()
        {
            // ensure room number = 5
            while (playersInRooms.Count != 5)
            {
                playersInRooms.Add(new List<string>());
            }
            // send users in all rooms to all users
            await Clients.All.SendAsync("ReceiveRooms", playersInRooms);
        }

        // given user joins selected room
        public async Task JoinRoom(string user, int room)
        {
            // ensure 5 rooms are available
            while (playersInRooms.Count != 5)
            {
                playersInRooms.Add(new List<string>());
            }

            // check if the room is full and that user is not already in room
            if (playersInRooms[room - 1].Count < 2 && playersInRooms[room - 1].Contains(user) == false)
            {
                playersInRooms[room - 1].Add(user); // add the user to the room
            }

            // add the connection to the signalr group corresponding to the room
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Room {room}");

            // display the updated room status to all users
            await Clients.All.SendAsync("ReceiveRooms", playersInRooms);
        }

        // remove player from room
        public async Task LeaveRoom(string user, int room)
        {
            playersInRooms[room - 1].Remove(user);
            // remove the connection from the SignalR group corresponding to the room
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Room {room}");
            // display updated room status to all users
            await Clients.All.SendAsync("ReceiveRooms", playersInRooms);
            // notify players in room that user has left room
            await Clients.Group($"Room {room}").SendAsync("PlayerLeft", user);
        }

        // send coords of player shot to opponent in same room
        public async Task SendCoordinates(string user, int room, int x, int y)
        {
            await Clients.OthersInGroup($"Room {room}").SendAsync("ReceiveCoordinates", user, x, y);
        }

        // send result hit/miss to the opponent in the specified room
        public async Task SendHitMiss(int room, bool wasHit)//, bool wasSunk)
        {
            await Clients.OthersInGroup($"Room {room}").SendAsync("ShotResponse", wasHit);//, wasSunk);
        }

        // send chat message to all users
        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", userName,  message);
        }
        public async Task SendGameOver(int room)
        {
        // Notify all clients in the room that the game is over
            await Clients.OthersInGroup($"Room {room}").SendAsync("ReceiveGameOverWin");
        }

    }
}
