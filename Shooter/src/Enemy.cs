using System;
using SwinGameSDK;
namespace MyGame
{
	public class Enemy : Ship
	{

		public Enemy (int hp, Bitmap sprite, float x, float y, float deltaX, float deltaY) : base (hp,sprite,x,y, deltaX, deltaY)
		{
		}
	}
}
