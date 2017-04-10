using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class PhysicsManager
	{	//physics manager is the game manager
		private static PhysicsManager _instance;


		public PhysicsManager ()
		{
			if (_instance == null) 
			{
				// NORMAL CONSTRUCTOR
				// Set up singleton
				_instance = this;
			} 
			else 
			{
				throw new Exception ("cannot have more than one instance of Physics Manager");
			}
		}


		public void CollisionHandler (Player player, List<Enemy> enemies, List<Bullet> bullets) 
		{
			//SwinGame.RectanglesIntersect ();

			//check bullet intersects enemy
			//TODO make bullet enemy collision despawn them both.
			//TODO make Player enemy collision remove 1hp.  When enemy hp reaches zero despawn?

			foreach (Enemy e in enemies) 
			{
				foreach (Bullet b in bullets) 
				{
					if (SwinGame.RectanglesIntersect (e.CollisionBox, b.CollisionBox))
					{
						Console.WriteLine ("bullet enemy collision detected");
					}
				}

				//Check enemy intersects player
				if (SwinGame.RectanglesIntersect (e.CollisionBox, player.CollisionBox)) 
				{
					Console.WriteLine ("player enemy collision detected");
				}

			}





		}


		public static PhysicsManager Instance 
		{
			get { return _instance; }
		}
	}
}
