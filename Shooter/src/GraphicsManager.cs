using System;
namespace MyGame
{
	public class GraphicsManager
	{
		private static GraphicsManager _instance;

		public GraphicsManager ()
		{
			if (_instance != null) 
			{
				_instance = this;
			} 
			else 
			{
				throw new Exception ("cannot have more than one instance of GraphicsManager");
			}
		}
		public static GraphicsManager Instance 
		{
			get { return _instance; }
		}
	}
}
