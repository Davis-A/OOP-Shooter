using System;
using SwinGameSDK;
namespace MyGame
{
	public class BossTwo : Enemy
	{
		private Weapon _weapon;
		private int _shootcounter;

		public BossTwo (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base (hp, sprite, x, y, deltaX, deltaY)
		{
			_weapon = new PeaShooter ();
			_shootcounter = 60;
		}

		public override void Update ()
		{
			Shoot ();
			if (Y < 1) 
			{
				DeltaY = 5;
			}

			if (Y > (SwinGame.ScreenHeight () - Sprite.Height)) 
			{
				DeltaY = -5;
			}

			base.Update ();
		}


		public override void HasCollided ()
		{
			base.HasCollided ();

			if (HP < 1) 
			{
				Factory.Instance.BuildWeaponContainer (_weapon, X, Y, 0, 0);
			}
		}

		private void Shoot () 
		{
			
			_shootcounter--;
			if (_shootcounter == 0) 
			{
				_shootcounter = 60;
				_weapon.Shoot (X, Y, Alignment.Enemy); 
			}
		}
	}
}
