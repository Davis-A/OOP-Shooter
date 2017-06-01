using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class PhysicsManager
	{	//physics manager is the game manager
		private static PhysicsManager _instance;


		private PhysicsManager ()
		{
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

			PlayerWeaponContainerCollisionCheck ();

		}

		public void PlayerWeaponContainerCollisionCheck () 
		{
			//check if player collides with a weapon container
			foreach (WeaponContainer wc in MemoryManager.Instance.WeaponContainers) 
			{
				if (SwinGame.RectanglesIntersect (MemoryManager.Instance.Player.CollisionBox, wc.CollisionBox)) 
				{
					MemoryManager.Instance.Player.Weapon = wc.Weapon;
				}
			}
		}


		public static PhysicsManager Instance 
		{
			get 
			{
				if (_instance == null) 
				{
					_instance = new PhysicsManager ();
				}
				return _instance; 
			}
		}
	}
}
