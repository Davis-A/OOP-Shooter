using System;
using SwinGameSDK;
namespace MyGame
{
	public class Enemy : Ship
	{

		public Enemy (int hp, Bitmap sprite, float x, float y, float deltaX) : base (hp,sprite,x,y, deltaX, 0)
		{
		}

		public override void Update ()
		{
			X = X + DeltaX;
		}
	}
}
