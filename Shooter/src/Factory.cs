using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Factory
	{
		private static Factory _instance;
		private Bitmap _dronebitmap;

		public Factory ()
		{
			if (_instance == null) {
				//load enemy bitmap
				_dronebitmap = SwinGame.LoadBitmap (@"sprites\enemy.png");
				_instance = this;
			} else {
				throw new Exception ("cannot have more than one instance of factory");
			}
		}

		public void BuildBossOne () 
		{
			MemoryManager.Instance.AddEnemy( new BossOne (5, SwinGame.LoadBitmap(@"sprites\BossOne.png"), SwinGame.ScreenWidth(), SwinGame.ScreenHeight()/2, 0, 0));
		}

		public void BuildEnemy (int hp, float x, float y, List<DeltaMovement> deltaMovement)
		{
			//(int hp, string bmpPath, float x, float y, float deltaX)
			MemoryManager.Instance.AddEnemy (new Drone (hp, _dronebitmap, x, y, deltaMovement));
		}

		public Player BuildPlayer () 
		{
			return new Player (1, SwinGame.LoadBitmap (@"sprites\F5S4-small.png"), 50f, 50f, new BigGun ());
		}

		public void BuildBullet (float x, float y, float deltaX, float deltaY, int radius, Color clr)
		{
			//(float x, float y, float deltaX, float deltaY, int radius, Color clr)
			MemoryManager.Instance.AddBullet(new Bullet (x, y, deltaX, deltaY, radius, clr));
		}

		public static Factory Instance {
			get { return _instance; }
		}


	}
}
