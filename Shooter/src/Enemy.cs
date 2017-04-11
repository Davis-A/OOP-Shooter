using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Enemy : Ship
	{
		private int _lifetime;
		private List<DeltaMovement> _deltaList;

		public Enemy (int hp, Bitmap sprite, float x, float y, List<DeltaMovement> deltaList) : base (hp, sprite, x, y, deltaList[0].deltaX, deltaList [0].deltaY)
		{
			_lifetime = 0;
			_deltaList = deltaList;
			_deltaList.RemoveAt (0);

		}

		//to be deleted.  This is just a simple constructor used for testing without the need for a delta movement struct.
		public Enemy (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base (hp,sprite,x,y, deltaX, deltaY)
		{
		}

		public override void Update ()
		{
			//set next delta
			_lifetime++;
			if (_lifetime == 50) 
			{
				if (_deltaList.Count > 0) 
				{
					_lifetime = 0;
					DeltaX = _deltaList [0].deltaX;
					DeltaY = _deltaList [0].deltaY;
					_deltaList.RemoveAt (0);

				}
			}
			base.Update ();
		}


	}
}
