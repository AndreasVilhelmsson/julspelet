using Xunit;
using JulensKodAventyr.Logic;
using JulensKodAventyr.Data;

public class CommandHandlerTests
{
	[Fact]
	public void ProcessCommand_Help_ReturnsCommandList()
	{
		var gameState = new GameState();
		var commandHandler = new CommandHandler(gameState);

		string response = commandHandler.ProcessCommand("hjälp");

		Assert.Contains("gå till", response);
		Assert.Contains("plocka upp", response);
	}

	[Fact]
	public void ProcessCommand_InvalidCommand_ReturnsErrorMessage()
	{
		var gameState = new GameState();
		var commandHandler = new CommandHandler(gameState);

		string response = commandHandler.ProcessCommand("hoppa");

		Assert.Contains("Ogiltigt kommando", response);
	}
}
