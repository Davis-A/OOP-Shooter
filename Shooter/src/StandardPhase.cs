using System;
using System.Collections.Generic;
using System.IO;

namespace MyGame
{
	public class StandardPhase : Phase
	{

			/*
			 * A standardPhase spawns drones.  
			 * Drones have an x,y starting position
			 * Drones have a list of Deltamovements (struct intx,inty)
			 * Their details are stored in a csv file which is passed to this objects constructor
			 * Format for the CSV file where each line represents one drone.  
			 * There is no limit to how many lines and thus how many drone per phase
			 * The format for each drone line is
			 * initial X position, initial Y position, deltaX1, deltaY1, deltaX2, deltaY2
			 * The amount of delta movements is unlimited and all will be read from a line
			 */

		private StreamReader _reader;


		public StandardPhase (int timer, string instructionFile) : base(timer)
		{
			_reader = new StreamReader ( instructionFile);

		}



		protected override void StartPhase () 
		{



			List<DeltaMovement> dxdylist = new List<DeltaMovement> ();
			DeltaMovement dxdy;
			//

			int[] enemyData =_reader.ReadCSVInt ();
			while (enemyData != null) 
			{
				dxdylist = new List<DeltaMovement> ();

				for (int i = 2; i < enemyData.Length - 1; i = i + 2) 
				{
					dxdy.deltaX = enemyData [i];
					dxdy.deltaY = enemyData [i + 1];
					dxdylist.Add (dxdy);
				}

				Factory.Instance.BuildDrone (1, enemyData [0], enemyData [1], dxdylist);
				enemyData = _reader.ReadCSVInt ();
			}

		}
	}
}
