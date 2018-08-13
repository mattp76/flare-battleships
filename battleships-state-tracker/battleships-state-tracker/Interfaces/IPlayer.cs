namespace battleships_state_tracker.Interfaces
{
	public interface IPlayer
	{
		int getHitCount();

		int getMissCount();

		void AskCoordinates();

		char[,] GetGrid();

		void SetGrid(int q, int w);

		void SetShipsPositions();

		bool GameComplete();
	}
}
