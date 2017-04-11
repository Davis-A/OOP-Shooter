using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Factory
	{
		private GameManager _world;
		private static Factory _instance;
		private Bitmap _enemybitmap; 

		public Factory (GameManager world)
		{
			if (_instance == null) 
			{
				//load enemy bitmap
				_enemybitmap = SwinGame.LoadBitmap (@"sprites\enemy.png");
				_world = world;
				_instance = this;
			} 
			else 
			{
				throw new Exception ("cannot have more than one instance of factory");
			}
		}

		//toDelete
		public void BuildEnemy (int hp, float x, float y, float deltaX, float deltaY)
		{
			//(int hp, string bmpPath, float x, float y, float deltaX)
			_world.AddEnemy (new Enemy (hp, _enemybitmap, x, y, deltaX, deltaY));
		}

		public void BuildEnemy (int hp, float x, float y, List<DeltaMovement> deltaMovement) 
		{
			//(int hp, string bmpPath, float x, float y, float deltaX)
			_world.AddEnemy (new Enemy (hp, _enemybitmap, x, y, deltaMovement));
		}

		public void BuildBullet (float x, float y, float deltaX, float deltaY, int radius, Color clr) 
		{
			//(float x, float y, float deltaX, float deltaY, int radius, Color clr)
			_world.AddBullet (new Bullet (x, y, deltaX, deltaY, radius,clr));
		}

		public static Factory Instance 
		{
			get { return _instance; }
		}

		public void PhaseOne ()
		{
			List<DeltaMovement> dxdylist = new List<DeltaMovement> ();
			DeltaMovement dxdy;
			dxdy.deltaX = -5;
			dxdy.deltaY = 0;
			dxdylist.Add (dxdy);
			dxdy.deltaX = -3;
			dxdy.deltaY = -5;
			dxdylist.Add (dxdy);
			dxdy.deltaX = -5;
			dxdy.deltaY = 3;
			dxdylist.Add (dxdy);
			Factory.Instance.BuildEnemy (1, SwinGame.ScreenWidth () + 50, 200, dxdylist);


			dxdylist = new List<DeltaMovement> ();
			dxdy.deltaX = -5;
			dxdy.deltaY = 0;
			dxdylist.Add (dxdy);
			dxdy.deltaX = -3;
			dxdy.deltaY = 5;
			dxdylist.Add (dxdy);
			dxdy.deltaX = -5;
			dxdy.deltaY = -3;
			dxdylist.Add (dxdy);
			Factory.Instance.BuildEnemy (1, SwinGame.ScreenWidth () + 50, 250, dxdylist);
		}

	}
}
