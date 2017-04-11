using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class TimeManager
	{
		private static TimeManager _instance;
		private int _counter;
		public TimeManager ()
		{
			if (_instance == null) {
				_counter = 0;
				_instance = this;
			} else {
				throw new Exception ("cannot have more than one instance of Time Manager");
			}
		}

		public static TimeManager Instance {
			get { return _instance; }
		}

		public void TimeRun ()
		{
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


		}
	}
}
