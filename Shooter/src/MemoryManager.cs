using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	//TODO Make adding bullets and enemies consistent with their own AddBullet() AddEnemy() methods.  Ensure these methods are the only way to add to list.
	//todo add a renderable list.  Then when AddBullet() AddEnemy() are called they are they also add the item to the renderable list.  When it's time to despawn them, have DespawnBullet() DespawnEnemy() remove them from both lists
	//This allows a single draw call to draw "renderable objects" instead of the numerous ones i have now.


	public class MemoryManager
	{
		private static MemoryManager _instance;

		//gameobject lists
		private List<Bullet> _bullets;
		private List<Enemy> _enemies;
		private Player _player;
		private List<Renderable> _renderables;


		public MemoryManager ()
		{
			if (_instance == null) 
			{
				ResetMemoryManager ();
				_instance = this;
			}
			else 
			{
				throw new Exception ("cannot have more than one instance of Time Manager");
			}
		}

		public void ResetMemoryManager () 
		{
			_enemies = new List<Enemy> ();
			_bullets = new List<Bullet> ();
			_renderables = new List<Renderable> ();
			//create player
			_player = Factory.Instance.BuildPlayer ();
		}


		public static MemoryManager Instance 
		{
			get 
			{
				if (_instance == null) 
				{
					_instance = new MemoryManager ();
				}
				return _instance;
			}
		}

		public List<Bullet> Bullets 
		{
			get { return _bullets; }
		}


		public void AddBullet (Bullet b)
		{
			_bullets.Add (b);
			_renderables.Add (b);
		}

		public void DespawnBullet (Bullet b) 
		{
			_bullets.Remove (b);
			_renderables.Remove (b);
		}

		public List<Enemy> Enemies 
		{
			get { return _enemies; }
		}

		public void DespawnEnemy (Enemy e) 
		{
			_enemies.Remove (e);
			_renderables.Remove (e);
		}

		//using a method.  I don't what anything other than the world being able to do things with the enemy list.  When it comes to rendering i will have GameManager create a list of every Game object 
		public void AddEnemy (Enemy e)
		{
			_enemies.Add (e);
			_renderables.Add (e);
		}

		public Player Player 
		{
			get { return _player; }
		}

		public List<Renderable> Renderable 
		{
			get { return _renderables; }
		}

	}
}
