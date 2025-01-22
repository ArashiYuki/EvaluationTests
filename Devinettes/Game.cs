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
			ComputerValue = random.Next(100);

			while (!IsCompleted)
			{
				Console.WriteLine("Enter a number between 0 and 100");
				string playerValueString = Console.ReadLine();

				if (IsPlayerValueANumber(playerValueString))
				{
					int playerValue = ConvertPlayerValueToInt(playerValueString);

					if (PlayerValueIsComputerValue(playerValue))
						IsCompleted = true;
					else if (PlayerValueIsSuperiorToComputerValue(playerValue))
						Console.WriteLine("Smaller");
					else
						Console.WriteLine("Bigger");
				}
			}

			Console.WriteLine("Success"); ;
		}

		public bool IsPlayerValueANumber(string playerValue)
		{
			if (!int.TryParse(playerValue, out _))
				throw new Exception("Your value must be a number");
			return true;
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
