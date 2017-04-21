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

			//delete bullets that have collided

			for (int l = MemoryManager.Instance.Enemies.Count - 1; l >= 0; l--)
			{
				for (int i = MemoryManager.Instance.Bullets.Count - 1; i>= 0; i--) 
				{
					if (SwinGame.RectanglesIntersect (MemoryManager.Instance.Enemies[l].CollisionBox, MemoryManager.Instance.Bullets[i].CollisionBox)) {
						//Console.WriteLine ("bullet enemy collision detected");
						MemoryManager.Instance.Bullets [i].HasCollided ();
						MemoryManager.Instance.Enemies [l].HasCollided ();
					}
				}
			}


			foreach (Enemy e in MemoryManager.Instance.Enemies) {
				if (SwinGame.RectanglesIntersect (e.CollisionBox, MemoryManager.Instance.Player.CollisionBox)) {
					//Console.WriteLine ("player enemy collision detected");
					MemoryManager.Instance.Player.RemoveHp ();
				}
			}
		}


		public static PhysicsManager Instance 
		{
			get { return _instance; }
		}
	}
}
