using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Drone : Enemy
	{
		private int _lifetime;
		private List<DeltaMovement> _deltaList;

		public Drone (int hp, Bitmap sprite, float x, float y, List<DeltaMovement> deltaList) : base (hp, sprite, x, y, deltaList[0].deltaX, deltaList [0].deltaY)
		{
			_lifetime = 0;
			_deltaList = deltaList;
			_deltaList.RemoveAt (0);

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
