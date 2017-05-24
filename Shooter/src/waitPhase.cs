using System;
namespace MyGame
{

	/// <summary>
	/// Wait phase exists to prevent new phases from starting by checking if enemy list is empty.  
	/// For example not wanting to start a new spawn of drones during a boss fight.
	/// </summary>
	public class waitPhase : Phase
	{
		public waitPhase () : base(120)
		{
		}

		public override bool Tick ()
		{
			if (MemoryManager.Instance.Enemies.Count == 0) 
			{
				return base.Tick ();
			}
			return false;
		}

		protected override void StartPhase () 
		{
			//does nothing
		}
	}
	}
