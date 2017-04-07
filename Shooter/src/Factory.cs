using System;
using SwinGameSDK;
namespace MyGame
{
	public class Factory
	{
		private GameManager _world;
		private static Factory _instance;
		private Bitmap _enemybitmap; 

		public Factory (GameManager world)
		{
			if (_instance == null) 
			{
				//load enemy bitmap
				_enemybitmap = SwinGame.LoadBitmap (@"sprites\enemy.png");
				_world = world;
				_instance = this;
			} 
			else 
			{
				throw new Exception ("cannot have more than one instance of factory");
			}
		}

		public void BuildEnemy (int hp, float x, float y, float deltaX, float deltaY) 
		{
			//(int hp, string bmpPath, float x, float y, float deltaX)
			_world.AddEnemy (new Enemy (hp, _enemybitmap, x, y, deltaX, deltaY));
		}

		public static Factory Instance 
		{
			get { return _instance; }
		}
	}
}
