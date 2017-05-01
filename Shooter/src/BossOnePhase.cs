using System;
namespace MyGame
{
	public class BossOnePhase : Phase
	{
		public BossOnePhase (int timer) : base(timer)
		{
		}

		protected override void StartPhase ()
		{
			Factory.Instance.BuildBossOne ();
		}

	}
}
