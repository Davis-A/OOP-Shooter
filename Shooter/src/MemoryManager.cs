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
		private List<UpdateableObject> _updateables;
		private List<WeaponContainer> _weaponContainers;


		private MemoryManager ()
		{
			ResetMemoryManager ();
		}

		public void ResetMemoryManager ()
		{
			_enemies = new List<Enemy> ();
			_bullets = new List<Bullet> ();
			_updateables = new List<UpdateableObject> ();
			_weaponContainers = new List<WeaponContainer> ();
			//create player
			AddPlayer (Factory.Instance.BuildPlayer ());
		}


		public static MemoryManager Instance {
			get {
				if (_instance == null) {
					_instance = new MemoryManager ();
				}
				return _instance;
			}
		}

		public List<Bullet> Bullets {
			get { return _bullets; }
		}


		public void AddBullet (Bullet b)
		{
			_bullets.Add (b);
			_updateables.Add (b);
		}

		public void DespawnBullet (Bullet b)
		{
			_bullets.Remove (b);
			_updateables.Remove (b);
		}

		public List<Enemy> Enemies {
			get { return _enemies; }
		}

		public void DespawnEnemy (Enemy e)
		{
			_enemies.Remove (e);
			_updateables.Remove (e);
		}

		//using a method.  I don't what anything other than the world being able to do things with the enemy list.  When it comes to rendering i will have GameManager create a list of every Game object 
		public void AddEnemy (Enemy e)
		{
			_enemies.Add (e);
			_updateables.Add (e);
		}

		public void AddPlayer (Player p)
		{
			_player = p;
			_updateables.Add (p);
		}

		public void AddWeaponContainer (WeaponContainer wc)
		{
			_weaponContainers.Add (wc);
			_updateables.Add (wc);
		}

		public void DespawnWeaponContainer (WeaponContainer wc) 
		{
			_weaponContainers.Remove (wc);
			_updateables.Remove (wc);
		}

		public List<WeaponContainer> WeaponContainers 
		{
			get { return _weaponContainers; }
		}


		public Player Player 
		{
			get { return _player; }
		}

		public List<UpdateableObject> Updateables 
		{
			get { return _updateables; }
		}


	}
}
