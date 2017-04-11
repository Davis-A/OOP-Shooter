using System;
using SwinGameSDK;
namespace MyGame
{
	public class Enemy : Ship
	{
		private int _lifetime;
		

		public Enemy (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base (hp,sprite,x,y, deltaX, deltaY)
		{
			_lifetime = 0;
		}

		public override void Update ()
		{
			_lifetime++;
			if (_lifetime == 100) 
			{
				//set next delta
				DeltaX = 0;
				DeltaY = 0;
			}
			base.Update ();
		}


	}
}
