using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class MemoryManager
	{
		public static MemoryManager _instance;

		//gameobject lists
		private List<Bullet> _bullets;
		private List<Drone> _enemies;
		private Player _player;
		public BossOne _boss1;

		public MemoryManager ()
		{
			if (_instance == null) 
			{
				//create enemy and bullet lists
				_enemies = new List<Drone> ();
				_bullets = new List<Bullet> ();

				//create player
				_player = new Player (2, SwinGame.LoadBitmap (@"sprites\F5S4-small.png"), 50f, 50f, new BigGun ());
				_instance = this;
			}
			else 
			{
				throw new Exception ("cannot have more than one instance of Time Manager");
			}
		}

		public static MemoryManager Instance 
		{
			get { return _instance; }
		}

		public List<Bullet> Bullets 
		{
			get { return _bullets; }
		}


		public void AddBullet (Bullet b)
		{
			_bullets.Add (b);
		}

		public void DespawnBullet (Bullet b) 
		{
			_bullets.Remove (b);
		}

		public List<Drone> Enemies 
		{
			get { return _enemies; }
		}

		public void DespawnEnemy (Drone e) 
		{
			_enemies.Remove (e);
		}

		//using a method.  I don't what anything other than the world being able to do things with the enemy list.  When it comes to rendering i will have GameManager create a list of every Game object 
		public void AddEnemy (Drone e)
		{
			_enemies.Add (e);
		}

		public Player Player 
		{
			get { return _player; }
		}

	}
}
