using System;
using SwinGameSDK;
namespace MyGame
{


	public abstract class GameObject
	{
		public static Rectangle CreateCollisionBox (float x, float y, int height, int width)
		{
			Rectangle collisionBox = new Rectangle();
			collisionBox.X = x;
			collisionBox.Y = y;
			collisionBox.Height = height;
			collisionBox.Width = width;
			return collisionBox;
		}

		private float _x;
		private float _y;
		private float _deltaX;
		private float _deltaY;
		private Rectangle _collisionBox;

		public GameObject (float x,float y,float deltaX,float deltaY, Rectangle collisionBox)
		{
			_x = x;
			_y = y;
			_deltaX = deltaX;
			_deltaY = deltaY;
			_collisionBox = collisionBox;
		}
		public virtual void Update () 
		{
			X += DeltaX;
			Y += DeltaY;
			_collisionBox.X += DeltaX;
			_collisionBox.Y += DeltaY;
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

		public Rectangle CollisionBox 
		{
			get { return _collisionBox; }
		}
	}
}
