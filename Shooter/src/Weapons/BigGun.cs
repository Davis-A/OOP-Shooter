using System;
using SwinGameSDK;
namespace MyGame
{
	public class BigGun : Weapon
	{
		public BigGun () : base(SwinGame.ColorRed(), 50, 10)
		{
		}

		public override Bullet SpawnBullet (float x, float y)
		{
			return new Bullet (x, y, Speed, 0, Radius, CLR);
		}
	}
}
