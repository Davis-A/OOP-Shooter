using System;
using SwinGameSDK;
namespace MyGame

{
	public class PeaShooter : Weapon
	{
		public PeaShooter () : base (SwinGame.ColorBlue(), 20, 10, "Pea Shooter")
		{
		}

		public override void Shoot (float x, float y, Alignment align) 
		{
			float targetX;
			float targetY;

			if (align == Alignment.Enemy) 
			{
				targetX = MemoryManager.Instance.Player.X;
				targetY = MemoryManager.Instance.Player.Y;

			} else 
			{
				targetX = SwinGame.MouseX ();
				targetY = SwinGame.MouseY ();
			}

			Double tx = targetX - x;
			Double ty = targetY - y;
			Double dist = Math.Sqrt (tx * tx + ty * ty);
			Double rad = Math.Atan2 (ty, tx);
			Double angle = rad / Math.PI * 180;


			Double deltaX = (tx / dist) * Speed;
			Double deltaY = (ty / dist) * Speed;
			Factory.Instance.BuildBullet (x, y, (float)deltaX, (float)deltaY, Radius, CLR, align);
		}
	}
}
