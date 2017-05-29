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
			 * nested iteration over bullet list
			 * if bullet allignment is Player, check bullet collision against enemy
			 * if bullet allignment is Enemy, check bullet collision against player
			 * If collision detected bullet handles its own collision immediately
			 * if bullet player collision is detected it handles own collision immediately
			 * Enemy is set to check handle collision at end of loop
			 * Enemy and player checked for collision
			 * if collision detected, player handles own collision immediately
			 * If enemy bullet collision detected, enemy handles collision at end of loop
			 */
			bool enemyCollided;
			bool bulletCollided;
			for (int l = MemoryManager.Instance.Enemies.Count - 1; l >= 0; l--)
			{
				enemyCollided = false;
				for (int i = MemoryManager.Instance.Bullets.Count - 1; i>= 0; i--) 
				{
					bulletCollided = false;
					if (MemoryManager.Instance.Bullets [i].Alignment == Alignment.Player) 
					{
						if (SwinGame.RectanglesIntersect (MemoryManager.Instance.Enemies [l].CollisionBox, MemoryManager.Instance.Bullets [i].CollisionBox))
						{
							bulletCollided = true;
							enemyCollided = true;
							MemoryManager.Instance.Player.Score = MemoryManager.Instance.Player.Score + 5;
						}
					}

					if (MemoryManager.Instance.Bullets [i].Alignment == Alignment.Enemy) 
					{
						if (SwinGame.RectanglesIntersect (MemoryManager.Instance.Bullets [i].CollisionBox, MemoryManager.Instance.Player.CollisionBox)) 
						{
							bulletCollided = true;

							MemoryManager.Instance.Player.HasCollided ();
						}
					}

					if (bulletCollided) 
					{
						MemoryManager.Instance.Bullets [i].HasCollided ();
					}
				}
				if (SwinGame.RectanglesIntersect (MemoryManager.Instance.Enemies [l].CollisionBox, MemoryManager.Instance.Player.CollisionBox)) {
					//Console.WriteLine ("player enemy collision detected");
					MemoryManager.Instance.Player.HasCollided ();
				}


				if (enemyCollided) {
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
