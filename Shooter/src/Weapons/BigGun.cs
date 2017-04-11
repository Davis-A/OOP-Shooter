using System;
using SwinGameSDK;
namespace MyGame
{
	public class BigGun : Weapon
	{
		public BigGun () : base(SwinGame.ColorRed(), 50, 10)
		{
		}

		public override void Shoot (float x, float y)
		{
			float deltaX = Speed;
			float deltaY = 0;
			Factory.Instance.BuildBullet (x, y, deltaX, deltaY, Radius, CLR);
		}
	}
}
