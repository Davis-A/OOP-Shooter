using System;
using SwinGameSDK;
namespace MyGame
{
	public class Bullet : GameObject
	{

		private int _radius;
		private Color _clr;

		public Bullet (float x, float y, float deltaX, float deltaY, int radius, Color clr) : base (x, y, deltaX, deltaY, CreateCollisionBox(x-radius, y-radius,radius*2,radius*2))
		{
			_radius = radius;
			_clr = clr;
		}

		public override void Render ()
		{
			SwinGame.FillCircle (_clr, X, Y, _radius);

			if (GameMain.DEBUG) 
			{
				SwinGame.DrawRectangle (SwinGame.ColorBlack (), CollisionBox.X, CollisionBox.Y, CollisionBox.Height, CollisionBox.Width);
			}
		}

		public override void Update ()
		{
			base.Update ();
			SetCollisionBoxLocation (X-Radius, Y-Radius);
		}

		public int Radius 
		{
			get { return _radius; }
		}

	}
}
