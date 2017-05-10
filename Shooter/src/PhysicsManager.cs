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


		public void CollisionHandler ()
		{

			/*
			 * Iterate over enemy list
			 * check if they collide with bullets
			 * If collision detected bullet handles its own collision immediately
			 * Enemy is set to check handle collision at end of loop
			 * Enemy and player checked for collision
			 * if collision detected, player handles own collision immediately
			 * If enemy bullet collision detected, enemy handles collision at end of loop
			 */
			bool removeEnemy;
			for (int l = MemoryManager.Instance.Enemies.Count - 1; l >= 0; l--)
			{
				removeEnemy = false;
				for (int i = MemoryManager.Instance.Bullets.Count - 1; i>= 0; i--) 
				{
					if (SwinGame.RectanglesIntersect (MemoryManager.Instance.Enemies[l].CollisionBox, MemoryManager.Instance.Bullets[i].CollisionBox)) 
					{
						//Console.WriteLine ("bullet enemy collision detected");
						MemoryManager.Instance.Bullets [i].HasCollided ();
						removeEnemy = true;
					}
				
				}
				if (SwinGame.RectanglesIntersect (MemoryManager.Instance.Enemies [l].CollisionBox, MemoryManager.Instance.Player.CollisionBox)) {
					//Console.WriteLine ("player enemy collision detected");
					MemoryManager.Instance.Player.HasCollided ();
				}


				if (removeEnemy) {
					MemoryManager.Instance.Enemies [l].HasCollided ();
				}

			}
		}


		public static PhysicsManager Instance 
		{
			get { return _instance; }
		}
	}
}
