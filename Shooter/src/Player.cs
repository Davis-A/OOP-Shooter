using System;
using SwinGameSDK;
namespace MyGame
{
	public class Player : Ship
	{
		private Weapon _weapon;
		public Player (int hp, Bitmap sprite, float x, float y, Weapon gun) : base(hp, sprite, x, y, 0, 0)
		{
			_weapon = gun;
		}

		public Bullet Shoot () 
		{
			return _weapon.SpawnBullet (X, Y);
		}

		public void ProcessInput () 
		{
			
		}

		public override void Update ()
		{
			if (SwinGame.KeyDown (KeyCode.DKey) && (X < (SwinGame.ScreenWidth () - 50)))
			{
				X = X + 5f; 
			}

			if (SwinGame.KeyDown (KeyCode.AKey) && (X > 0)) {
				X = X - 5f;
			}

			if (SwinGame.KeyDown (KeyCode.SKey) && (Y < (SwinGame.ScreenHeight () - 40))) {
				Y = Y + 5f;
			}

			if (SwinGame.KeyDown (KeyCode.WKey) && (Y > 0)) {
				Y = Y - 5f;
			}
		}






	}
}
