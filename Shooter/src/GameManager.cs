using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class GameManager
	{
		public GameManager ()
		{
		}

		public void HandleInput () 
		{
			SwinGame.ProcessEvents ();

			//handle player input
			MemoryManager.Instance.Player.DeltaX = 0;
			MemoryManager.Instance.Player.DeltaY = 0;

			if (SwinGame.KeyDown (KeyCode.DKey) && (MemoryManager.Instance.Player.X < (SwinGame.ScreenWidth () - 50))) 
			{
				MemoryManager.Instance.Player.DeltaX += MemoryManager.Instance.Player.Speed;
			}

			if (SwinGame.KeyDown (KeyCode.AKey) && (MemoryManager.Instance.Player.X > 0)) 
			{
				MemoryManager.Instance.Player.DeltaX -= MemoryManager.Instance.Player.Speed;
			}

			if (SwinGame.KeyDown (KeyCode.SKey) && (MemoryManager.Instance.Player.Y < (SwinGame.ScreenHeight () - 40))) 
			{
				MemoryManager.Instance.Player.DeltaY += MemoryManager.Instance.Player.Speed;
			}

			if (SwinGame.KeyDown (KeyCode.WKey) && (MemoryManager.Instance.Player.Y > 0)) 
			{
				MemoryManager.Instance.Player.DeltaY -= MemoryManager.Instance.Player.Speed;
			}

			//shoot

			if (SwinGame.KeyTyped (KeyCode.SpaceKey) || SwinGame.MouseClicked (MouseButton.LeftButton) )
			{
				MemoryManager.Instance.Player.Weapon.Shoot (MemoryManager.Instance.Player.X, MemoryManager.Instance.Player.Y, Alignment.Player);
				MemoryManager.Instance.Player.Score--;
			}

			//Pause game

			if (SwinGame.KeyTyped (KeyCode.PKey)) 
			{
				SwinGame.ProcessEvents ();
				while (!SwinGame.KeyTyped (KeyCode.PKey)) 
				{
					SwinGame.ProcessEvents ();
				}
			}

			//reset game:
			if (SwinGame.KeyTyped (KeyCode.NKey)) 
			{
				ResetGame ();	
			}

			//bonus lives cheat
			if (SwinGame.KeyTyped (KeyCode.RightCtrlKey)) 
			{
				MemoryManager.Instance.Player.AddHp ();
			}


		}

		public void Update () 
		{
			TimeManager.Instance.TimeRun ();
			//update player
			MemoryManager.Instance.Player.Update ();
			//update enemies
			foreach (Enemy e in MemoryManager.Instance.Enemies) 
			{
				e.Update ();
			}
			//update bullets

			foreach (Bullet b in MemoryManager.Instance.Bullets) 
			{
				b.Update ();
			}

			PhysicsManager.Instance.CollisionHandler ();


			//outside area despawn
			IsBulletsOutOfBounds ();
			IsEnemyOutOfBounds ();
			CheckPlayerIsAlive ();
		}

		private void CheckPlayerIsAlive () 
		{
			if (MemoryManager.Instance.Player.HP < 0) 
			{
				ResetGame ();
			}

		}

		private void ResetGame () 
		{
			TimeManager.Instance.ResetTimeManager ();
			MemoryManager.Instance.ResetMemoryManager ();
		}


		private void IsEnemyOutOfBounds () 
		{
			for (int i = MemoryManager.Instance.Enemies.Count - 1; i >= 0; i--)
			{
				//Console.WriteLine ("X: {0}, Y:{1} ",_enemies[i].X, _enemies[i].Y);
				if ((MemoryManager.Instance.Enemies [i].X < -SwinGame.ScreenWidth ()) || (MemoryManager.Instance.Enemies [i].X > SwinGame.ScreenWidth () *2) || (MemoryManager.Instance.Enemies [i].Y < -SwinGame.ScreenHeight ()) || (MemoryManager.Instance.Enemies [i].Y > SwinGame.ScreenHeight () * 2))
				{
					//Console.WriteLine ("Enemy out of bounds");
					MemoryManager.Instance.DespawnEnemy(MemoryManager.Instance.Enemies[i]);
				}
			}

		}

		private void IsBulletsOutOfBounds()
		{
			for (int i = MemoryManager.Instance.Bullets.Count - 1; i >= 0; i--) 
			{//to far left, too far right, too far up, too far below
				if (((MemoryManager.Instance.Bullets [i].X + MemoryManager.Instance.Bullets[i].Radius) < 0)  || ((MemoryManager.Instance.Bullets [i].X - MemoryManager.Instance.Bullets [i].Radius) > SwinGame.ScreenWidth ()) || (MemoryManager.Instance.Bullets [i].Y + MemoryManager.Instance.Bullets [i].Radius < 0) || ((MemoryManager.Instance.Bullets [i].Y - MemoryManager.Instance.Bullets [i].Radius) > SwinGame.ScreenHeight ())) 
				{
					//Console.WriteLine ("Bullet out of range");
					MemoryManager.Instance.DespawnBullet (MemoryManager.Instance.Bullets [i]);
				}
			}
		}


		public void Render () 
		{
			GraphicsManager.Instance.Render ();
		}

	}
}
