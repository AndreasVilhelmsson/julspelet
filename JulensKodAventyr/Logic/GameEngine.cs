using JulensKodAventyr.Logic;
using JulensKodAventyr.UI;
using JulensKodAventyr.Data;
using System;

namespace JulensKodAventyr.Logic
{
	public class GameEngine
	{
		private GameState _gameState;
		private CommandHandler _commandHandler;

		public GameEngine()
		{
			_gameState = new GameState();
			_commandHandler = new CommandHandler(_gameState);
		}

		public void Start()
		{
			MainMenu.Show(); // Startar menyn
			Console.WriteLine("Skriv 'hjälp' för att se kommandon.");

			RunGameLoop();
		}

		private void RunGameLoop()
		{
			while (true)
			{
				string input = InputHandler.GetInput();

				if (input == "avsluta") break;

				string response = _commandHandler.ProcessCommand(input);
				GameDisplay.ShowMessage(response);
			}

			Console.WriteLine("🎅 God Jul och tack för att du spelade! 🎅");
		}
	}
}
