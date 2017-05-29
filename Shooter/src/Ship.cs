using System;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Ship : MoveableObject
	{
		private int _hp;
		private Bitmap _sprite;

		//public Ship (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base ()
		public Ship (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base (x, y, deltaX, deltaY, CreateCollisionBox(x,y,sprite.Height,sprite.Width))
		{
			_hp = hp;
			_sprite = sprite;
		}

		public override void Render ()
		{
			SwinGame.DrawBitmap (Sprite, X, Y);


			if (GameMain.DEBUG)
			{
				SwinGame.DrawRectangle (SwinGame.ColorWhite (), CollisionBox.X, CollisionBox.Y, CollisionBox.Width, CollisionBox.Height);
			}
		}

		public Bitmap Sprite 
		{
			get { return _sprite; }
		}



		public void RemoveHp (int remove) 
		{
			_hp = _hp - remove;
		}


		public void RemoveHp () 
		{
			RemoveHp (1);
		}

		public void AddHp (int add) 
		{
			_hp = _hp + add;
		}

		public void AddHp () 
		{
			AddHp (1);
		}



		public int HP 
		{
			get { return _hp; }
		}


	}
}
