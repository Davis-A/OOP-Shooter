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
			_player = new Player (2, SwinGame.LoadBitmap (@"sprites\F5S4-small.png"), 50f, 50f, new BigGun ());
		}


		//primary functions

		public void Init () 
		{
			//do something?  maybe open the window?
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
