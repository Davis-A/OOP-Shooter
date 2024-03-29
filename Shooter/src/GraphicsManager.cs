﻿using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class GraphicsManager
	{
		private static GraphicsManager _instance;
		private Bitmap _background;

		private GraphicsManager ()
		{
			_background = SwinGame.LoadBitmap (@"background.jpg");
		}


		public void Render () 
		{
			

			//Clear the screen and 
			SwinGame.ClearScreen (Color.Black);
			SwinGame.DrawBitmap (_background, 0, 0);

			foreach (Renderable r in MemoryManager.Instance.Updateables) 
			{
				r.Render ();
			}

			RenderHUD ();
			//Player is always rendered again to ensure it is on top of all other renderable items
			MemoryManager.Instance.Player.Render ();
			//draw the framerate
			SwinGame.DrawFramerate (0, 0);
			//draw the screen
			SwinGame.RefreshScreen (60);


		}

		private void RenderHUD () 
		{
			//hud box
			SwinGame.FillRectangle (Color.Grey, 0, SwinGame.ScreenHeight () * 0.95f, SwinGame.ScreenWidth (), SwinGame.ScreenHeight () * 0.1f);
			RenderPlayerLives ();
			SwinGame.DrawText ("Score: " + MemoryManager.Instance.Player.Score, Color.White, SwinGame.ScreenWidth () * 0.8f, SwinGame.ScreenHeight () * .98f);
		}

		private void RenderPlayerLives ()
		{
			float offset = 0;
			int i = 1;

			while (i <= MemoryManager.Instance.Player.HP && i <=10) 
			{
				i++;
				SwinGame.FillTriangle (SwinGame.ColorGreen (), 30 + offset, SwinGame.ScreenHeight () - 25, 20 + offset, SwinGame.ScreenHeight () - 5, 40 + offset, SwinGame.ScreenHeight () - 5);
				offset = offset + 22;
			}
		}


		public static GraphicsManager Instance 
		{
			get 
			{
				if (_instance == null) 
				{
					_instance = new GraphicsManager ();
				}
				return _instance;
			}
		}

	}
}
