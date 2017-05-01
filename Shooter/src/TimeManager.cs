using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class TimeManager
	{
		private static TimeManager _instance;
		private List<Phase> _phases;
		public TimeManager ()
		{
			if (_instance == null) {
				_phases =  new List<Phase>();
				GeneratePhase ();
				_instance = this;
			} else 
			{
				throw new Exception ("cannot have more than one instance of Time Manager");
			}
		}

		private void GeneratePhase () 
		{
			_phases.Add (new StandardPhase (50, @"C:\Users\andrew\Documents\Projects\CustomProgram\Shooter\Phases\phase1.csv"));
			_phases.Add (new StandardPhase (50, @"C:\Users\andrew\Documents\Projects\CustomProgram\Shooter\Phases\phase1.csv"));
			_phases.Add (new StandardPhase (50, @"C:\Users\andrew\Documents\Projects\CustomProgram\Shooter\Phases\phase1.csv"));
			_phases.Add (new StandardPhase (150, @"C:\Users\andrew\Documents\Projects\CustomProgram\Shooter\Phases\phase2.csv"));
			_phases.Add (new StandardPhase (50, @"C:\Users\andrew\Documents\Projects\CustomProgram\Shooter\Phases\phase2.csv"));
			_phases.Add (new StandardPhase (50, @"C:\Users\andrew\Documents\Projects\CustomProgram\Shooter\Phases\phase2.csv"));
			_phases.Add (new BossOnePhase (300));
		}

		public static TimeManager Instance {
			get { return _instance; }
		}

		public void TimeRun ()
		{
			/*
			 * if List has an item
			 * run update
			 * if it returns true then the phase has executed and needs to be removed
			 */
			if (_phases.Count != 0) 
			{
				if (_phases [0].Update ()) 
				{
					_phases.Remove (_phases [0]);
				}
			}

			/*
			_counter++;

			//start phase one
			if (_counter == 50 || _counter == 100 || _counter == 150) {
				Factory.Instance.PhaseOne ();
			} else if (_counter == 300 || _counter == 350 || _counter == 400) {
				Factory.Instance.PhaseTwo ();
			} else if (_counter == 800) 
			{
				Factory.Instance.BuildBossOne ();
			}

			*/
		}
	}
}
