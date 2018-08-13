namespace battleships_state_tracker
{
	using System;
	using System.Collections.Generic;

	using Autofac;

	using battleships_state_tracker.Domain;
	using battleships_state_tracker.Interfaces;
	using battleships_state_tracker.IoC;

	using log4net;

	public class Program
	{
		private static IContainer container;

		private static IBoard board;

		private static IPlayer player;

		private static ILog logger;

		public static void Main(string[] args)
		{
			container = new AppRegistration().Register();
			logger = container.Resolve<ILog>();
			board = container.Resolve<IBoard>();
			player = container.Resolve<IPlayer>();

			Console.Title = "FlareHR Battleships!";
			Console.WriteLine("Welcome to FlareHR BattleShip Player Tracker!\r\n\r\n");
			Console.WriteLine("What is your name?");
			var name = Console.ReadLine();
			Console.WriteLine();

			player.SetShipsPositions();

			Console.WriteLine($"Welcome {name} here is your board with battleships in place\r\n\r\n");

			while (player.getHitCount() < 17)
			{
				if (player.GameComplete())
				{
					break;
				}

				board.CreateBoard(player.GetGrid());
				player.AskCoordinates();
			}

			Console.WriteLine($"Congratulations, {name} ! You Win!\r\n");
			Console.WriteLine($"You missed: {player.getMissCount()} time(s)\r\n");

			if (player.GameComplete())
			{
				Console.WriteLine("You SUNK all the ships. Well done.\r\n");
			}

			Console.WriteLine("Thanks for playing FlareHR Battleships. Press enter to quit.");
			Console.ReadLine();
		}
	}
}
