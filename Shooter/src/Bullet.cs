using System;
using SwinGameSDK;
namespace MyGame
{
	public class Bullet : UpdateableObject
	{

		private int _radius;
		private Color _clr;
		private Alignment _alignment;

		public Bullet (float x, float y, float deltaX, float deltaY, int radius, Color clr, Alignment align) : base (x, y, deltaX, deltaY, CreateCollisionBox(x-radius, y-radius,radius*2,radius*2))
		{
			_radius = radius;
			_clr = clr;
			_alignment = align;
		}

		public override void HasCollided ()
		{
			MemoryManager.Instance.DespawnBullet (this);
		}

		public override void Render ()
		{
			SwinGame.FillCircle (_clr, X, Y, _radius);

			if (GameMain.DEBUG) 
			{
				SwinGame.DrawRectangle (SwinGame.ColorBlack (), CollisionBox.X, CollisionBox.Y, CollisionBox.Height, CollisionBox.Width);
			}
		}

		public int Radius 
		{
			get { return _radius; }
		}

		public Alignment Alignment 
		{
			get { return _alignment; }
		}

	}
}
