using System.Collections.Generic;

namespace JulensKodAventyr.Data
{
	public class GameState
	{
		public Player Player { get; private set; }
		public Dictionary<string, Room> Rooms { get; private set; }

		public GameState()
		{
			Player = new Player("Spelare");
			Rooms = new Dictionary<string, Room>
			{
				{ "vardagsrum", new Room("Vardagsrum", "Ett mysigt rum med en julgran.") },
				{ "sovrum", new Room("Sovrum", "Ett varmt sovrum med en stor säng.") },
				{ "kök", new Room("Kök", "Ett kök fyllt med pepparkakor och julmust.") }
			};

			// Lägg till föremål i rummen
			Rooms["vardagsrum"].Items.Add(new Item("ljus", "Ett vackert doftljus."));
			Rooms["kök"].Items.Add(new Item("pepparkaka", "En väldoftande pepparkaka."));

			Player.CurrentRoom = Rooms["vardagsrum"]; // Starta i vardagsrummet
		}

		public string MoveToRoom(string roomName)
		{
			if (Rooms.ContainsKey(roomName))
			{
				Player.CurrentRoom = Rooms[roomName];
				return $"🏠 Du gick till {roomName}. {Player.CurrentRoom.Description}";
			}
			return "🚪 Det rummet finns inte!";
		}

		public string PickUpItem(string itemName)
		{
			Item item = Player.CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());

			if (item != null)
			{
				Player.Inventory.Add(item);
				Player.CurrentRoom.Items.Remove(item);
				return $"✅ Du plockade upp {item.Name}!";
			}
			return "❌ Det finns inget att plocka upp här!";
		}

		public string LookAround()
		{
			return $"📍 Du är i {Player.CurrentRoom.Name}. {Player.CurrentRoom.Description}";
		}
	}
}
