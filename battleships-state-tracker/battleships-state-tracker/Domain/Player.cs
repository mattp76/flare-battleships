namespace battleships_state_tracker.Domain
{
	using System;
	using System.Collections.Generic;

	using battleships_state_tracker.Interfaces;

	using log4net;

	public class Player : IPlayer
	{
		private ILog logger;

		public Player(ILog logger)
		{
			this.logger = logger;
		}

		private readonly char[,] grid = new char[10, 10];

		private int hitCount;

		private int missCount;

		private int x;

		private int y;

		List<Ship> ships = new List<Ship>();
		List<ShipDetail> shipDetails = new List<ShipDetail>();

		public int getHitCount()
		{
			return this.hitCount;
		}

		public int getMissCount()
		{
			return this.missCount;
		}

		public void AskCoordinates()
		{
			Console.WriteLine("Enter X");
			var line = Console.ReadLine();


			if (this.GameComplete())
			{
				Console.WriteLine("You have SUNK all ships and completed the game");
			}

			if (int.TryParse(line, out var value))
			{
				this.x = value;
			}
			else
			{
				Console.WriteLine("Not an integer!");
			}

			Console.WriteLine("Enter Y");
			line = Console.ReadLine();
			if (int.TryParse(line, out value))
			{
				this.y = value;
			}
			else
			{
				Console.WriteLine("Not an integer!");
			}

			try
			{
				if (this.grid[this.x, this.y].Equals('S'))
				{
					this.grid[this.x, this.y] = 'H';
					Console.Clear();
					Console.WriteLine("Hit!\r\n");
					this.hitCount += 1;
					var position = string.Format("{0}||{1}", this.x, this.y);

					foreach (var sd in this.shipDetails)
					{
						if (sd.HitCounter <= 0)
						{
							continue;
						}

						foreach (var pos in sd.Positions)
						{
							if (pos != position)
							{
								continue;
							}

							sd.HitCounter = sd.HitCounter - 1;
							this.SunkCheck(sd);
						}
					}
				}
				else
				{
					this.grid[this.x, this.y] = 'M';
					Console.Clear();
					Console.WriteLine("Miss!\r\n");
					this.missCount += 1;
				}
			}
			catch
			{
				Console.Clear();
				Console.WriteLine("Error: Please enter numbers between 0 and 9. (Inclusive)");
			}
		}

		private void SunkCheck(ShipDetail sd)
		{
			if (sd.HitCounter == 0)
			{
				Console.WriteLine($"Congratulation - You SUNK a {sd.Name.ToString()} !!!!! \r\n");
			}
		}

		public bool GameComplete()
		{
			foreach (var d in this.shipDetails)
			{
				if (d.HitCounter > 0)
				{
					return false;
				}
			}

			return true;
		}


		public char[,] GetGrid()
		{
			return this.grid;
		}

		public void SetGrid(int q, int w)
		{
			this.grid[q, w] = 'S';
		}

		public void SetShipsPositions()
		{
			var s = new Ship
			{
				Name = ShipType.BATTLESHIP,
				Orientation = ShipOrientation.Horizontal,
				ExtentUnits = 5,
				Position_Row = 1,
				Position_Col = 1
			};
			this.ships.Add(s);

			s = new Ship
			{
				Name = ShipType.CRUISER,
				Orientation = ShipOrientation.Horizontal,
				ExtentUnits = 4,
				Position_Row = 4,
				Position_Col = 2
			};
			this.ships.Add(s);

			s = new Ship
			{
				Name = ShipType.SUBMARINE,
				Orientation = ShipOrientation.Vertical,
				ExtentUnits = 4,
				Position_Row = 2,
				Position_Col = 7
			};
			this.ships.Add(s);

			s = new Ship
			{
				Name = ShipType.ROWINGBOAT,
				Orientation = ShipOrientation.Vertical,
				ExtentUnits = 2,
				Position_Row = 7,
				Position_Col = 1
			};

			this.ships.Add(s);
			var positions = new List<string>();

			foreach (var ship in this.ships)
			{
				for (var i = 0; i < ship.ExtentUnits; i++)
				{
					if (ship.Orientation == ShipOrientation.Horizontal)
					{
						var position = string.Format("{0}||{1}", ship.Position_Col.ToString(), ship.Position_Row.ToString());
						positions.Add(position);
						this.SetGrid(ship.Position_Col, ship.Position_Row);
						ship.Position_Col++;
					}
					else
					{
						var position = string.Format("{0}||{1}", ship.Position_Col.ToString(), ship.Position_Row.ToString());
						positions.Add(position);
						this.SetGrid(ship.Position_Col, ship.Position_Row);
						ship.Position_Row++;
					}
				}

				this.shipDetails.Add(new ShipDetail() { HitCounter = ship.ExtentUnits, Name = ship.Name, Positions = positions });

				positions = new List<string>();
			}
		}
	}
}
