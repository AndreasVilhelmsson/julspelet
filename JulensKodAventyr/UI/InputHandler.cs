using System;

namespace JulensKodAventyr.UI
{
	public static class InputHandler
	{
		public static string GetInput()
		{
			Console.Write("> ");
			return Console.ReadLine()?.Trim().ToLower();
		}
	}
}

