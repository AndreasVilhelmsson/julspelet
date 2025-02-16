using System.Collections.Generic;

namespace JulensKodAventyr.Data
{
	public class Room
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public List<Item> Items { get; private set; }

		public Room(string name, string description)
		{
			Name = name;
			Description = description;
			Items = new List<Item>();
		}
	}
}
