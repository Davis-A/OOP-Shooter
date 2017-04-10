using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class GameManager
	{
		//singletons
		private Factory _factory;
		private TimeManager _timeManager;
		private PhysicsManager _physicsManager;
		private GraphicsManager _graphicsManager;

		//gameobject lists
		private List<Bullet> _bullets;
		private List<Enemy> _enemies;
		private Player _player;




		public GameManager ()
		{
			//spawn singletons
			_factory = new Factory (this);
			_timeManager = new TimeManager ();
			_physicsManager = new PhysicsManager ();
			_graphicsManager = new GraphicsManager ();

			//create enemy and bullet lists
			_enemies = new List<Enemy> ();
			_bullets = new List<Bullet> ();

			//create player
			_player = new Player (2, SwinGame.LoadBitmap (@"sprites\F5S4-small.png"), 50f, 50f, new BigGun());
		}


		//primary functions

		public void Init () 
		{
			//do something?  maybe open the window?

			//temporary commands
			Factory.Instance.BuildEnemy (5, SwinGame.ScreenWidth() + 50, 200, -5, 0);


		}

		public void HandleInput () 
		{
			SwinGame.ProcessEvents ();

			//handle player input
			_player.DeltaX = 0;
			_player.DeltaY = 0;

			if (SwinGame.KeyDown (KeyCode.DKey) && (_player.X < (SwinGame.ScreenWidth () - 50))) 
			{
				_player.DeltaX += _player.Speed;
			}

			if (SwinGame.KeyDown (KeyCode.AKey) && (_player.X > 0)) 
			{
				_player.DeltaX -= _player.Speed;
			}

			if (SwinGame.KeyDown (KeyCode.SKey) && (_player.Y < (SwinGame.ScreenHeight () - 40))) 
			{
				_player.DeltaY += _player.Speed;
			}

			if (SwinGame.KeyDown (KeyCode.WKey) && (_player.Y > 0)) 
			{
				_player.DeltaY -= _player.Speed;
			}

			//shoot

			if (SwinGame.KeyTyped (KeyCode.SpaceKey) || SwinGame.MouseClicked (MouseButton.LeftButton) )
			{
				_bullets.Add(_player.Weapon.SpawnBullet (_player.X, _player.Y));
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
		}

		public void Update () 
		{
			//update player
			_player.Update ();
			//update enemies
			foreach (Enemy e in _enemies) 
			{
				e.Update ();
			}
			//update bullets

			foreach (Bullet b in _bullets) 
			{
				b.Update ();
			}

			PhysicsManager.Instance.CollisionHandler (_player, _enemies, _bullets);
			DespawnDeadEnemies ();


			//outside area despawn
			DespawnBulletsOutOfBounds ();
			DeSpawnEnemiesOutOfBounds ();




		}

		private void DespawnDeadEnemies () 
		{
			for (int i = _enemies.Count - 1; i >= 0; i--) 
			{
				if (_enemies [i].HP <= 0) 
				{
					_enemies.Remove (_enemies [i]);
				}
			}
		}


		private void DeSpawnEnemiesOutOfBounds () 
		{
			for (int i = _enemies.Count - 1; i >= 0; i--)
			{
				//Console.WriteLine ("X: {0}, Y:{1} ",_enemies[i].X, _enemies[i].Y);
				if ((_enemies [i].X < -SwinGame.ScreenWidth ()) || (_enemies [i].X > SwinGame.ScreenWidth () *2) || (_enemies [i].Y < -SwinGame.ScreenHeight ()) || (_enemies [i].Y > SwinGame.ScreenHeight () * 2))
				{
					//Console.WriteLine ("Enemy out of bounds");
					_enemies.Remove (_enemies [i]);
				}
			}

		}

		private void DespawnBulletsOutOfBounds()
		{
			for (int i = _bullets.Count - 1; i >= 0; i--) 
			{//to far left, too far right, too far up, too far below
				if (((_bullets [i].X + _bullets[i].Radius) < 0)  || ((_bullets [i].X - _bullets [i].Radius) > SwinGame.ScreenWidth ()) || (_bullets [i].Y + _bullets [i].Radius < 0) || ((_bullets [i].Y - _bullets [i].Radius) > SwinGame.ScreenHeight ())) 
				{
					//Console.WriteLine ("Bullet out of range");
					_bullets.Remove (_bullets [i]);
				}
			}
		}


		public void Render () 
		{
			GraphicsManager.Instance.Render (_player, _enemies, _bullets);
		}






		//accessors

		//using a method.  I don't what anything other than the world being able to do things with the enemy list.  When it comes to rendering i will have GameManager create a list of every Game object 
		public void AddEnemy (Enemy e)
		{
			_enemies.Add (e);
		}

		public List<GameObject> GetAllGameObjects
		{
			get 
			{
				List<GameObject> allGameobjects = new List<GameObject> ();
				allGameobjects.AddRange (_bullets);
				allGameobjects.AddRange (_enemies);
				allGameobjects.Add (_player);
				return allGameobjects;
			}
		}





	}
}
