using System.Collections.Generic;

namespace JulensKodAventyr.Data
{
	public class Player
	{
		public string Name { get; private set; }
		public Room CurrentRoom { get; set; }
		public List<Item> Inventory { get; private set; }

		public Player(string name)
		{
			Name = name;
			Inventory = new List<Item>();
		}
	}
}
