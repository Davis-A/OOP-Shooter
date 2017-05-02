using System;
namespace MyGame
{
	public abstract class Phase
	{
		private int _timer;

		public Phase (int timer)
		{
			_timer = timer;


		}

		public bool Update ()
		{
			DecrementTimer ();
			if (Timer < 0) {
				StartPhase ();
				return true;
			}
			return false;
		}

		protected abstract void StartPhase ();
	

		public int Timer 
		{
			get { return _timer; }
		}

		protected void DecrementTimer () 
		{
			_timer--;
		}
	}

}
