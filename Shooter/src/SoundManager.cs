using System;
namespace MyGame
{
	public class SoundManager
	{
		private static SoundManager _instance;

		private SoundManager ()
		{
			
		}

		public static SoundManager Instance 
		{
			get 
			{
				if (_instance == null) 
				{
					_instance = new SoundManager ();
				}
				return _instance;
			}
		}
	}
}
