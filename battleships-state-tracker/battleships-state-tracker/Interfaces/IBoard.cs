namespace battleships_state_tracker.Interfaces
{
	using System.Collections.Generic;

	using battleships_state_tracker.Domain;

	public interface IBoard
	{
		void CreateBoard(char[,] Board);

		//void PrintBoard(int[,] arrBoardFields, List<Ship> lstShips);
	}
}
