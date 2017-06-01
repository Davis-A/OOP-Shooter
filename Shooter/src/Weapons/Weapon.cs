using System;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Weapon
	{
		private Color _colour;
		private int _radius;
		private float _speed;
		private string _name;


		public Weapon (Color color, int radius, int speed, string name)
		{
			_colour = color;
			_radius = radius;
			_speed = speed;
			_name = name;
		}

		public abstract void Shoot (float x, float y, Alignment align);


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

		public string Name 
		{
			get { return _name; }
		}



	}
}
