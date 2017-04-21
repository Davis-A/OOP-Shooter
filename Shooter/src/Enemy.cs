using System;
using SwinGameSDK;
namespace MyGame
{
	public class Enemy : Ship
	{
		public Enemy (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base(hp, sprite, x, y, deltaX, deltaY)
		{
		}

		public override void HasCollided ()
		{
			//remove health, check is health is >0, destroy if it is zero
			RemoveHp ();
			if (HP < 1) 
			{
				MemoryManager.Instance.DespawnEnemy (this);
			}


		}
	}
}
