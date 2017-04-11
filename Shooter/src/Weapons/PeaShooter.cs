using System;
using SwinGameSDK;
namespace MyGame

{
	public class PeaShooter : Weapon
	{
		public PeaShooter () : base (SwinGame.ColorBlue(), 20, 10)
		{
		}

		public override void Shoot (float x, float y) 
		{

			Double tx = SwinGame.MouseX() - x;
			Double ty = SwinGame.MouseY () - y;
			Double dist = Math.Sqrt (tx * tx + ty * ty);
			Double rad = Math.Atan2 (ty, tx);
			Double angle = rad / Math.PI * 180;


			Double deltaX = (tx / dist) * Speed;
			Double deltaY = (ty / dist) * Speed;
			Factory.Instance.BuildBullet (x, y, (float)deltaX, (float)deltaY, Radius, CLR);
		}
	}
}
