using System;
using SwinGameSDK;
namespace MyGame
{
	public class BossOne : Enemy
	{
		public BossOne (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base (hp, sprite, x, y, deltaX, deltaY)
		{
		}

		public override void Update ()
		{
			
			int speed = 2;
			Double tx = MemoryManager.Instance.Player.X - X;
			Double ty = MemoryManager.Instance.Player.Y - Y;
			Double dist = Math.Sqrt (tx * tx + ty * ty);
			Double rad = Math.Atan2 (ty, tx);
			Double angle = rad / Math.PI * 180;


			DeltaX = (float)(tx / dist) * speed;
			DeltaY = (float)(ty / dist) * speed;
			//Console.WriteLine ("DeltaX: {0} DeltaY: {1}", DeltaX, DeltaY);
			base.Update ();
		}




	}
}
