using System;

namespace JulensKodAventyr.UI
{
	public class MainMenu
	{
		public static void Show()
		{
			Console.Clear();
			Console.WriteLine("🎄 Välkommen till Julens Kodäventyr! 🎄");
			Console.WriteLine("1. Starta spelet");
			Console.WriteLine("2. Avsluta");
			Console.Write("Välj ett alternativ: ");

			string input = Console.ReadLine();
			if (input == "1")
			{
				Console.Clear();
			}
			else
			{
				Environment.Exit(0);
			}
		}
	}
}
