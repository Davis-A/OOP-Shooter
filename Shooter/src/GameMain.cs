using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
		public static bool DEBUG = true;
		public static void Main()
        {
			GameManager game = new GameManager ();
			//Open the game window
			SwinGame.OpenGraphicsWindow("GameMain", 800, 600);  //does this below in GameManager.Init() ?
			//game.Init ();

			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) 
			{
				//Fetch the next batch of UI interaction
				game.HandleInput ();
				game.Update ();
				game.Render ();

				  //does this go in GraphicsManager.Render?
				//Draw onto the screen
				 //Does this go in GraphicsManger.Render()?
			}
			SwinGame.ReleaseAllBitmaps ();
        }
    }
}