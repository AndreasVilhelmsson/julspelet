using JulensKodAventyr.Data;
using System.Collections.Generic;

namespace JulensKodAventyr.Logic
{
	public class CommandHandler
	{
		private GameState _gameState;

		public CommandHandler(GameState gameState)
		{
			_gameState = gameState;
		}

		public string ProcessCommand(string input)
		{
			if (input == "hjälp")
				return "Kommandon: gå till vardagsrum eller sovrum, plocka upp [föremål], titta, hjälp, avsluta";
			if (input.StartsWith("gå till "))
				return _gameState.MoveToRoom(input.Substring(8));
			if (input.StartsWith("plocka upp "))
				return _gameState.PickUpItem(input.Substring(11));
			if (input == "titta")
				return _gameState.LookAround();

			return "🤔 Ogiltigt kommando. Skriv 'hjälp' för kommandon.";
		}
	}
}
