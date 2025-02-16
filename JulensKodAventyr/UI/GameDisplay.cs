using System;

namespace JulensKodAventyr.UI
{
	public static class GameDisplay
	{
		public static void ShowMessage(string message)
		{
			Console.WriteLine(message);
		}

		public static void ShowRoom(string roomName, string description)
		{
			Console.WriteLine($"📍 Du är i {roomName}");
			Console.WriteLine(description);
		}
	}
}
