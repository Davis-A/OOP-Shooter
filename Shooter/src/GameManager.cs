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
		private Player _p1;




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
			Player p1 = new Player (2, SwinGame.LoadBitmap (@"sprites\F5S4-small.png"), 50f, 50f, new PeaShooter ());
		}

		public void HandleInput () 
		{
			//get the player to handle it's own input handle the players input
		}

		public void AddEnemy (Enemy e)
		{
			_enemies.Add (e);
		}





	}
}
