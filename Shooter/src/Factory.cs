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

		public void BuildBossTwo () 
		{
			MemoryManager.Instance.AddEnemy (new BossTwo (5, SwinGame.LoadBitmap (@"sprites\BossTwo.png"), SwinGame.ScreenWidth () - 200, SwinGame.ScreenHeight () + 200, 0, -5));
		}

		public void BuildDrone (int hp, float x, float y, List<DeltaMovement> deltaMovement)
		{
			//(int hp, string bmpPath, float x, float y, float deltaX)
			MemoryManager.Instance.AddEnemy (new Drone (hp, _dronebitmap, x, y, deltaMovement));
		}

		public Player BuildPlayer () 
		{
			//MemoryManager.Instance.AddPlayer (new Player (5, SwinGame.LoadBitmap (@"sprites\F5S4-small.png"), 50f, 50f, new BigGun ()));
			return new Player (5, SwinGame.LoadBitmap (@"sprites\F5S4-small.png"), 50f, 50f, new BigGun ());
		}

		public void BuildBullet (float x, float y, float deltaX, float deltaY, int radius, Color clr, Alignment align)
		{
			//(float x, float y, float deltaX, float deltaY, int radius, Color clr)
			MemoryManager.Instance.AddBullet(new Bullet (x, y, deltaX, deltaY, radius, clr, align));
		}

		public void BuildWeaponContainer (Weapon w, float x, float y, float deltaX, float deltaY) 
		{
			MemoryManager.Instance.AddWeaponContainer (new WeaponContainer (w, x, y, deltaY, deltaY));
		}

		public static Factory Instance 
		{
			get 
			{
				if (_instance == null) 
				{
					_instance = new Factory ();
				}	
				return _instance; 
			}
		}


	}
}
