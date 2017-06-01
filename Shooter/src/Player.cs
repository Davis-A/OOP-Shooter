using System;
using SwinGameSDK;
namespace MyGame
{
	public class Player : Ship
	{
		private Weapon _weapon;
		private float _speed;
		private bool isImmune;
		private int imunityTimer;
		private Alignment _alignment;
		private int _score;

		public Player (int hp, Bitmap sprite, float x, float y, Weapon gun) : base(hp, sprite, x, y, 0, 0)
		{
			_weapon = gun;
			_speed = 5;
			isImmune = false;
			_alignment = Alignment.Player;
			_score = 0;
		}


		public override void HasCollided ()
		{
			if (!isImmune) 
			{
				RemoveHp ();
				isImmune = true;
				imunityTimer = 120;
			}

		}

		public override void Update ()
		{
			base.Update ();
			if (isImmune) 
			{
				imunityTimer--;
				if (imunityTimer < 0) 
				{
					isImmune = false;
				}
			}
		}

		public int Score 
		{
			get { return _score; }
			set { _score = value; }
		}


		public Weapon Weapon 
		{
			get { return _weapon; }
			set { _weapon = value; }
		}

		public float Speed 
		{
			get { return _speed; }
			set { _speed = value; }
		}

		public Alignment Alignment 
		{
			get { return _alignment; }
		}
	}
}
