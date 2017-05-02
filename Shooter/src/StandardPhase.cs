using System;
using System.Collections.Generic;
using System.IO;

namespace MyGame
{
	public class StandardPhase : Phase
	{
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

				Factory.Instance.BuildEnemy (1, enemyData [0], enemyData [1], dxdylist);
				enemyData = _reader.ReadCSVInt ();
			}

		}
	}
}
