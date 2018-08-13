namespace battleships_state_tracker.Domain
{
	using System.Collections.Generic;

	public class ShipDetail { 
		public ShipType Name { get; set; }
		public int HitCounter { get; set; }
		public List<string> Positions { get; set; }
	}
}
