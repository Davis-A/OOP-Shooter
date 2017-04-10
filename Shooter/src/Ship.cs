using System;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Ship : GameObject
	{
		private int _hp;
		private Bitmap _sprite;
		private Rectangle _collisionBox;

		public Ship (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base (x, y, deltaX, deltaY)
		{
			_hp = hp;
			_sprite = sprite;
			_collisionBox = new Rectangle ();
			_collisionBox.Height = sprite.Height;
			_collisionBox.Width = sprite.Width;
			_collisionBox.X = x;
			_collisionBox.Y = y;
		}

		public override void Render ()
		{
			SwinGame.DrawBitmap (Sprite, X, Y);


			if (GameMain.DEBUG)
			{
				SwinGame.DrawRectangle (SwinGame.ColorBlack (), _collisionBox.X, _collisionBox.Y, _collisionBox.Width, _collisionBox.Height);
			}
		}

		public override void Update ()
		{
			base.Update ();
			_collisionBox.X = X;
			_collisionBox.Y = Y;
			//Console.WriteLine ("Ship: Height: {0} Width: {1}", _collisionBox.Height, _collisionBox.Width);
		}


		public Bitmap Sprite 
		{
			get { return _sprite; }
		}

		//temp methods to stop crashing

		public void RemoveHp () 
		{
			_hp = _hp - 1;
		}

		public void Freebmp () 
		{
			SwinGame.FreeBitmap (_sprite);
		}

		public Rectangle CollisionBox 
		{
			get { return _collisionBox; }
		}

		public int HP 
		{
			get { return _hp; }
		}


	}
}
