namespace battleships_state_tracker.Domain
{
	public class Ship
	{
		public ShipType Name { get; set; }
		public ShipOrientation Orientation { get; set; }
		public int ExtentUnits { get; set; } // The number of fields the ship occupies
		public int Position_Row { get; set; } // The (zero-based) row index where the ship starts out
		public int Position_Col { get; set; } // The (zero-based) column index where the ship starts out
	}
}
