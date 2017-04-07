using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class GraphicsManager
	{
		private static GraphicsManager _instance;

		public GraphicsManager ()
		{
			if (_instance == null) 
			{
				_instance = this;
			} 
			else 
			{
				throw new Exception ("cannot have more than one instance of GraphicsManager");
			}
		}
		public static GraphicsManager Instance 
		{
			get { return _instance; }
		}

		public void Render (Player player, List<Enemy> enemies, List<Bullet> bullets) 
		{
			//Clear the screen and 
			SwinGame.ClearScreen (Color.White);

			foreach (Enemy e in enemies) 
			{
				e.Render ();
			}

			foreach (Bullet b in bullets) {
				b.Render ();
			}

			player.Render ();

			//draw the framerate
			SwinGame.DrawFramerate (0, 0);
			//draw the screen
			SwinGame.RefreshScreen (60);
		}
	}
}
