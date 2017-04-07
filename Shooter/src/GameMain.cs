using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
		public static void Main()
        {
			

			GameManager game = new GameManager ();

			//Open the game window
			SwinGame.OpenGraphicsWindow("GameMain", 800, 600);  //does this below in GameManager.Init() ?

			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) 
			{
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();
				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);





				SwinGame.DrawFramerate (0, 0);  //does this go in GraphicsManager.Render?
				//Draw onto the screen
				SwinGame.RefreshScreen (60); //Does this go in GraphicsManger.Render()?

			}
			SwinGame.ReleaseAllBitmaps ();
        }
    }
}