using System;
namespace MyGame
{
	public class BossTwoPhase : Phase
	{
		public BossTwoPhase (int timer) : base (timer)
		{
		}

		protected override void StartPhase ()
		{
			Factory.Instance.BuildBossTwo ();
		}

	}
}
