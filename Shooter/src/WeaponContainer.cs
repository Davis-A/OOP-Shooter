using System;
using SwinGameSDK;
namespace MyGame
{
	/*
	 * Item container is a container to store a weapon and display it on screen
	 * An example is after a boss dies it can drop its weapon and allow the player to pick it up
	*/
	public class WeaponContainer : UpdateableObject
	{
		private Weapon _weapon;
		private int _lifespan;
		private int _height;
		private int _width;

		public WeaponContainer (Weapon weapon, float x, float y, float deltaX, float deltaY) : base (x, y, deltaX, deltaY, CreateCollisionBox(x, y, 75, 75))
		{
			_weapon = weapon;
			_lifespan = 600;
			_width = 75;
			_height = 75;
		}

		public override void Update ()
		{
			base.Update ();
			_lifespan--;
		}

		public override void Render ()
		{
			SwinGame.FillRectangle (SwinGame.ColorTeal (), X, Y, _width, _height);
			SwinGame.DrawText (_weapon.Name, SwinGame.ColorBlack(), X, Y + _height /2);
			if (GameMain.DEBUG) 
			{
				SwinGame.DrawRectangle (SwinGame.ColorWhite (), CollisionBox.X, CollisionBox.Y, CollisionBox.Height, CollisionBox.Width);
			}
		}

		public override void HasCollided ()
		{
			throw new NotImplementedException ();
		}

		public int Lifespan 
		{
			get { return _lifespan; }
		}

		public Weapon Weapon 
		{
			get { return _weapon; }
		}
	}
}
