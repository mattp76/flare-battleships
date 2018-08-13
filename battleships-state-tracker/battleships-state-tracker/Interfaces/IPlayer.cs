namespace battleships_state_tracker.Interfaces
{
	public interface IPlayer
	{
		int GetHitCount();

		int GetMissCount();

		void AskCoordinates();

		char[,] GetGrid();

		void SetGrid(int q, int w);

		void SetShipsPositions();

		bool GameComplete();
	}
}
