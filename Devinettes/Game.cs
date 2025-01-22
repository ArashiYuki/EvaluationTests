using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devinettes
{
	public class Game
	{
		public int ComputerValue { get; set; }
		public bool IsCompleted { get; set; } = false;
		
		public void RunGame()
		{
			Random random = new Random();
			ComputerValue = random.Next(1, 100);

			while (!IsCompleted)
			{
				string playerValueString = GetPlayerValue();

				if (IsPlayerValueANumber(playerValueString))
				{
					int playerValue = ConvertPlayerValueToInt(playerValueString);
					if (!IsPlayerValueBetween1And100(playerValue))
						Console.WriteLine("Value must be between 1 and 100");
					else if (PlayerValueIsComputerValue(playerValue))
						IsCompleted = true;
					else if (PlayerValueIsSuperiorToComputerValue(playerValue))
						Console.WriteLine("Smaller");
					else
						Console.WriteLine("Bigger");
				}
			}

			Console.WriteLine("Success"); ;
		}

		public string GetPlayerValue()
		{
			Console.WriteLine("Enter a number between 1 and 100");
			string playerValue = Console.ReadLine();
			return playerValue;
		}

		public bool IsPlayerValueANumber(string playerValue)
		{
			if (!int.TryParse(playerValue, out _))
				throw new Exception("Your value must be a number");
			return true;
		}

		public bool IsPlayerValueBetween1And100(int playerValue)
		{
			return playerValue >= 1 && playerValue <= 100;
		}

		public int ConvertPlayerValueToInt(string playerValue)
		{
			return Convert.ToInt32(playerValue);
		}

		public bool PlayerValueIsComputerValue(int playerValue)
		{
			return playerValue == ComputerValue;
		}

		public bool PlayerValueIsSuperiorToComputerValue(int playerValue)
		{
			return playerValue > ComputerValue;
		}
	}
}
