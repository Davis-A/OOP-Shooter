using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class GraphicsManager
	{
		private static GraphicsManager _instance;
		private Bitmap _background;

		public GraphicsManager ()
		{
			if (_instance == null) 
			{
				_background = SwinGame.LoadBitmap (@"background.jpg");
				_instance = this;
			} 
			else 
			{
				throw new Exception ("cannot have more than one instance of GraphicsManager");
			}
		}


		public void Render () 
		{
			

			//Clear the screen and 
			SwinGame.ClearScreen (Color.Black);
			SwinGame.DrawBitmap (_background, 0, 0);

			foreach (Renderable r in MemoryManager.Instance.Renderable) 
			{
				r.Render ();
			}

			MemoryManager.Instance.Player.Render ();



			 //Old implementation:
			/*
			 * Comments on polymorphism:  
			 * While enemies, bullets and Player are all Moveable objects which have a Draw() method.  
			 * Due to how the memory manager groups them in different lists.
			 * I could have created a property in MemoryManager to concatenate all the lists of objects that can be drawn
			 * I decided against this as the cost of concatonating the list and potentailly checking for differences between it
			 * and the individual lists (or contatonating it again) each loop would be expensive.
			 */

			/*
			foreach (Enemy e in MemoryManager.Instance.Enemies) 
			{
				e.Render ();
			}

			foreach (Bullet b in MemoryManager.Instance.Bullets) {
				b.Render ();
			}

			*/


			//draw the framerate
			SwinGame.DrawFramerate (0, 0);
			//draw the screen
			SwinGame.RefreshScreen (60);


		}


		public static GraphicsManager Instance {
			get { return _instance; }
		}

	}
}
