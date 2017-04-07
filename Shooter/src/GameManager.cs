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
			Player p1 = new Player (2, SwinGame.LoadBitmap (@"sprites\F5S4-small.png"), 50f, 50f, new PeaShooter ());
		}


		//primary functions

		public void Init () 
		{
			//do something?  maybe open the window?
		}

		public void HandleInput () 
		{
			//get the player to handle it's own input handle the players input
		}

		public void Update () 
		{
			//call all gameobjects to update




		}



		public void Render () 
		{

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
