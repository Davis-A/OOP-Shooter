using System;
using SwinGameSDK;
namespace MyGame
{
	public class Player : Ship
	{
		
		private Weapon _weapon;
		private float _speed;

		public Player (int hp, Bitmap sprite, float x, float y, Weapon gun) : base(hp, sprite, x, y, 0, 0)
		{
			_weapon = gun;
			_speed = 5;
		}

		public void ProcessInput () 
		{

			//reset player movement delta each cycle.  Based on keyinput adjust delta.  Up and down will result in a net 0 change
			DeltaX = 0;
			DeltaY = 0;

			if (SwinGame.KeyDown (KeyCode.DKey) && (X < (SwinGame.ScreenWidth () - 50))) {
				DeltaX += _speed;
			}

			if (SwinGame.KeyDown (KeyCode.AKey) && (X > 0)) {
				DeltaX -= _speed;
			}

			if (SwinGame.KeyDown (KeyCode.SKey) && (Y < (SwinGame.ScreenHeight () - 40))) {
				DeltaY += _speed;
			}

			if (SwinGame.KeyDown (KeyCode.WKey) && (Y > 0)) {
				DeltaY -= _speed;
			}

			//TODO Need to handle shooting.  Should i give weapon access to the world so it can get the bullet list?



		}

		public override void Update ()
		{
			X += DeltaX;
			Y += DeltaY;
		}

		public Weapon Weapon 
		{
			get { return _weapon; }
		}






	}
}
