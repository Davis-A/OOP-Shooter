using System;
using SwinGameSDK;
namespace MyGame
{
	public class Bullet : GameObject
	{

		private int _radius;
		private Color _clr;
		private Rectangle _collisionBox;

		public Bullet (float x, float y, float deltaX, float deltaY, int radius, Color clr) : base (x, y, deltaX, deltaY)
		{
			_radius = radius;
			_clr = clr;

			_collisionBox = new Rectangle ();
			_collisionBox.Height = radius * 2;
			_collisionBox.Width = radius * 2;
			_collisionBox.X = x - radius;
			_collisionBox.Y = y - radius;
		}

		public override void Render ()
		{
			SwinGame.FillCircle (_clr, X, Y, _radius);
			//Console.WriteLine ("Bullet: Height: {0} Width: {1}", _collisionBox.Height, _collisionBox.Width);

			if (GameMain.DEBUG) 
			{
				SwinGame.DrawRectangle (SwinGame.ColorBlack (), _collisionBox.X, _collisionBox.Y, _collisionBox.Height, _collisionBox.Width);
			}
		}

		public override void Update ()
		{
			base.Update ();
			_collisionBox.X = X - _radius;
			_collisionBox.Y = Y - _radius;
		}

		public Rectangle CollisionBox 
		{
			get { return _collisionBox; }
		}

		public int Radius 
		{
			get { return _radius; }
		}

	}
}
