﻿using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class TimeManager
	{
		private static TimeManager _instance;
		private List<Phase> _phases;
		private TimeManager ()
		{
			_phases = new List<Phase> ();
			ResetTimeManager ();
		}

		private void GeneratePhase ()
		{
			_phases.Add (new StandardPhase (50, @"Resources\Phases\phase1.csv"));
			_phases.Add (new StandardPhase (50, @"Resources\Phases\phase1.csv"));
			_phases.Add (new StandardPhase (50, @"Resources\Phases\phase1.csv"));
			_phases.Add (new StandardPhase (150, @"Resources\Phases\phase2.csv"));
			_phases.Add (new StandardPhase (50, @"Resources\Phases\phase2.csv"));
			_phases.Add (new StandardPhase (50, @"Resources\Phases\phase2.csv"));
			_phases.Add (new BossOnePhase (200));
			_phases.Add (new waitPhase ());
			_phases.Add (new StandardPhase (50, @"Resources\Phases\phase3.csv"));
			_phases.Add (new StandardPhase (25, @"Resources\Phases\phase3.csv"));
			_phases.Add (new StandardPhase (25, @"Resources\Phases\phase3.csv"));
			_phases.Add (new StandardPhase (25, @"Resources\Phases\phase3.csv"));
			_phases.Add (new BossTwoPhase (200));
		}



		public void ResetTimeManager () 
		{
			_phases.Clear ();
			GeneratePhase ();
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
				if (_phases [0].Tick ()) 
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

		public static TimeManager Instance 
		{
			get 
			{
				if (_instance == null) {
					_instance = new TimeManager ();
				}
				return _instance;
			}
		}
	}
}
