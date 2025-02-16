using Xunit;
using JulensKodAventyr.Data;

public class GameStateTests
{
	[Theory]
	[InlineData("vardagsrum", "🏠 Du gick till vardagsrum.")]
	[InlineData("sovrum", "🏠 Du gick till sovrum.")]
	[InlineData("kök", "🏠 Du gick till kök.")]
	public void MoveToRoom_ShouldUpdateRoom_WhenValid(string roomName, string expectedMessage)
	{
		var gameState = new GameState();
		string result = gameState.MoveToRoom(roomName);

		Assert.Contains(expectedMessage, result);
	}

	[Theory]
	[InlineData("badrum")]
	[InlineData("garage")]
	[InlineData("trädgård")]
	public void MoveToRoom_ShouldFail_WhenInvalidRoom(string invalidRoom)
	{
		var gameState = new GameState();
		string result = gameState.MoveToRoom(invalidRoom);

		Assert.Contains("🚪 Det rummet finns inte!", result);
	}

	[Fact]
	public void PickUpItem_ShouldSucceed_WhenItemExists()
	{
		var gameState = new GameState();
		string result = gameState.PickUpItem("ljus");

		Assert.Contains("✅ Du plockade upp", result);
		Assert.Empty(gameState.Rooms["vardagsrum"].Items);
	}

	[Fact]
	public void PickUpItem_ShouldFail_WhenItemNotFound()
	{
		var gameState = new GameState();
		string result = gameState.PickUpItem("bok");

		Assert.Contains("❌ Det finns inget att plocka upp här!", result);
	}

	[Theory]
	[InlineData("ljus", "✅ Du plockade upp ljus!", "vardagsrum")]
	[InlineData("pepparkaka", "✅ Du plockade upp pepparkaka!", "kök")]
	public void PickUpItem_ShouldRemove_WhenValid(string itemName, string expectedMessage, string roomName)
	{
		var gameState = new GameState();

		// Flytta spelaren till rätt rum innan testet körs
		if (gameState.Player.CurrentRoom.Name.ToLower() != roomName.ToLower())
		{
			gameState.MoveToRoom(roomName);
		}

		string result = gameState.PickUpItem(itemName);

		Assert.Contains(expectedMessage, result);
	}


	[Theory]
	[InlineData("tomte")]
	[InlineData("bok")]
	[InlineData("choklad")]
	public void PickUpItem_ShouldFail_WhenInvalid(string invalidItem)
	{
		var gameState = new GameState();
		string result = gameState.PickUpItem(invalidItem);

		Assert.Contains("❌ Det finns inget att plocka upp här!", result);
	}
}
