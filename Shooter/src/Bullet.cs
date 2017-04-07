using System;
using SwinGameSDK;
namespace MyGame
{
	public class Bullet : GameObject
	{

		private int _radius;
		private Color _clr;

		public Bullet (float x, float y, float deltaX, float deltaY, int radius, Color clr) : base (x, y, deltaX, deltaY)
		{
			_radius = radius;
			_clr = clr;
		}

		//temporary constructor
		public Bullet (float x, float y, float deltaX, int radius, Color clr ) : base (x,y,deltaX,0)
		{
			_radius = radius;
			_clr = clr;
		}

		public override void Render ()
		{
			SwinGame.FillCircle (_clr, X, Y, _radius);
		}

		public override void Update ()
		{
			X = X + DeltaX;
			Y = Y + DeltaY;
		}
	}
}
