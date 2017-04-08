using System;
using SwinGameSDK;
namespace MyGame
{
	public abstract class GameObject
	{
		private float _x;
		private float _y;
		private float _deltaX;
		private float _deltaY;

		public GameObject (float x,float y,float deltaX,float deltaY)
		{
			_x = x;
			_y = y;
			_deltaX = deltaX;
			_deltaY = deltaY;
		}
		public virtual void Update () 
		{
			X += DeltaX;
			Y += DeltaY;
		}
		public abstract void Render ();

		public float X 
		{
			get { return _x; }
			set { _x = value; }
		}


		public float Y 
		{
			get { return _y; }
			set { _y = value; }
		}

		public float DeltaX 
		{
			get { return _deltaX; }
			set { _deltaX = value; }
		}

		public float DeltaY 
		{
			get { return _deltaY; }
			set { _deltaY = value; }
		}
	}
}
