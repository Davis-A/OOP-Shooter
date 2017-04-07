using System;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Weapon
	{
		private Color _colour;
		private int _radius;
		private float _speed;


		public Weapon (Color color, int radius, int speed)
		{
			_colour = color;
			_radius = radius;
			_speed = speed;
		}

		public abstract Bullet SpawnBullet (float x, float y);


		public Color CLR 
		{
			get { return _colour; }
		}

		public int Radius 
		{
			get { return _radius; }
		}

		public float Speed 
		{
			get { return _speed; }
		}



	}
}
