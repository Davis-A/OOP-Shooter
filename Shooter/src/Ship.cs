using System;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Ship : GameObject
	{
		private int _hp;
		private Bitmap _sprite;

		public Ship (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base (x, y, deltaX, deltaY)
		{
			_hp = hp;
			_sprite = sprite; //SwinGame.LoadBitmap (bmpPath);
		}

		public override void Render ()
		{
			SwinGame.DrawBitmap (Sprite, X, Y);
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
