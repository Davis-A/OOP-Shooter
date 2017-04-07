using System;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Ship : GameObject
	{
		private int _hp;
		private Bitmap _sprite;
		private Rectangle _boundingBox;

		public Ship (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base (x, y, deltaX, deltaY)
		{
			_hp = hp;
			_sprite = sprite; //SwinGame.LoadBitmap (bmpPath);
			_boundingBox = new Rectangle ();
			_boundingBox.Height = sprite.Height;
			_boundingBox.Width = sprite.Width;
		}

		public override void Render ()
		{
			SwinGame.DrawBitmap (Sprite, X, Y);
			if (GameMain.DEBUG)
			{
				SwinGame.DrawRectangle (SwinGame.ColorBlack (), X, Y, _boundingBox.Width, _boundingBox.Height);
			}
		}


		public Bitmap Sprite 
		{
			get { return _sprite; }
		}

		//temp methods to stop crashing

		public void Freebmp () 
		{
			SwinGame.FreeBitmap (_sprite);
		}


	}
}
