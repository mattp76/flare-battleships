namespace battleships_state_tracker.Domain
{
	using System;
	using battleships_state_tracker.Interfaces;

	using log4net;

	public class Board : IBoard
	{
		private ILog logger;

		public Board(ILog logger)
		{
			this.logger = logger;
		}

		public void CreateBoard(char[,] board)
		{
			try
			{
				int row;

				Console.WriteLine("  ¦ 0 1 2 3 4 5 6 7 8 9");
				Console.WriteLine("--+--------------------");
				for (row = 0; row <= 9; row++)
				{
					Console.Write(row + " ¦ ");
					int column;
					for (column = 0; column <= 9; column++)
					{
						Console.Write(board[column, row] + " ");
					}

					Console.WriteLine();
				}

				Console.WriteLine("\n");
			}
			catch
			{
				this.logger.Info("Error: Building the board");
			}
		}
	}
}
