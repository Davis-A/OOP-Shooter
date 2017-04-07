using System;
namespace MyGame
{
	public class TimeManager
	{
		private static TimeManager _instance;
		public TimeManager ()
		{
			if (_instance == null) 
			{
				_instance = this;
			} 
			else 
			{
				throw new Exception ("cannot have more than one instance of Time Manager");
			}
		}

		public static TimeManager Instance 
		{
			get { return _instance; }
		}
	}
}
