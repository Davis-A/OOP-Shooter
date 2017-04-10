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
			//TODO make this despawn the bullet and enemy.

			foreach (Enemy e in enemies) 
			{
				foreach (Bullet b in bullets) 
				{
					if (SwinGame.RectanglesIntersect (e.CollisionBox, b.CollisionBox))
					{
						Console.WriteLine ("bullet enemy collision detected");
					}
				}

				if (SwinGame.RectanglesIntersect (e.CollisionBox, player.CollisionBox)) 
				{
					Console.WriteLine ("player enemy collision detected");
				}

			}

			//Check enemy intersects player



		}


		public static PhysicsManager Instance 
		{
			get { return _instance; }
		}
	}
}
