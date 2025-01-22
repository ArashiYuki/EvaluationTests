namespace Devinettes.UnitTests
{
	[TestClass]
	public sealed class GameTests
	{
		private Game _game;

		[TestInitialize]
		public void Init()
		{
			_game = new Game();
			_game.ComputerValue = 51;
		}

		[TestMethod]
		[DataRow("1")]
		[DataRow("150")]
		[DataRow("13")]
		public void IsPlayerValueANumber_WithStringValue_ReturnsTrue(string value)
		{
			var result = _game.IsPlayerValueANumber(value);

			Assert.IsTrue(result);
		}

		[TestMethod]
		[DataRow("un")]
		[DataRow("a")]
		[DataRow("#")]
		public void IsPlayerValueANumber_WithStringValue_ThrowsException(string value)
		{
			Assert.ThrowsException<Exception>(() => _game.IsPlayerValueANumber(value));
		}

		[TestMethod]
		[DataRow("1", 1)]
		[DataRow("7", 7)]
		public void ConvertPlayerValueToInt_WithStringValue_ReturnsInt(string value, int expectedResult)
		{
			var result = _game.ConvertPlayerValueToInt(value);

			Assert.AreEqual(expectedResult, result);
		}

		[TestMethod]
		public void PlayerValueIsComputerValue_WithRightValue_ReturnsTrue()
		{
			var result = _game.PlayerValueIsComputerValue(51);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void PlayerValueIsComputerValue_WithWrongValue_ReturnsFalse()
		{
			var result = _game.PlayerValueIsComputerValue(52);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void PlayerValueIsSuperiorToComputerValue_WithBiggerValue_ReturnsTrue()
		{
			var result = _game.PlayerValueIsSuperiorToComputerValue(52);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void PlayerValueIsComputerValue_WithSmallerValue_ReturnsFalse()
		{
			var result = _game.PlayerValueIsSuperiorToComputerValue(49);

			Assert.IsFalse(result);
		}
	}
}
