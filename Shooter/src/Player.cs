using System;
using SwinGameSDK;
namespace MyGame
{
	public class Player : Ship
	{
		
		private Weapon _weapon;
		private float _speed;

		public Player (int hp, Bitmap sprite, float x, float y, Weapon gun) : base(hp, sprite, x, y, 0, 0)
		{
			_weapon = gun;
			_speed = 5;
		}

		public override void HasCollided ()
		{
			RemoveHp ();
			if (HP < 1) 
			{
				throw new NotImplementedException ();
			}
		}

		public Weapon Weapon 
		{
			get { return _weapon; }
		}

		public float Speed 
		{
			get { return _speed; }
			set { _speed = value; }
		}






	}
}
