using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {



        public static void Main()
        {

			/*
			 * setup Mytesting
			 */
			List<GameObject> AllObjects = new List<GameObject> ();
			//create an enemy ship
			//AllObjects.Add (new Enemy (1, @"sprites\enemy.png", 800f, 300f, -2f));
			//Player p1 = new Player (2, @"sprites\F5S4-small.png", 50f, 50f, new BigGun());

			//Rectangle myRectangle = new Rectangle ();
			//myRectangle.
			//SwinGame.RectanglesIntersect(



			//--------------------------------------------







			//--------------------------------------------

			/*
			* end setup
			*/




            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
			//sSwinGame.ShowSwinGameSplashScreen();

			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) 
			{
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);


				foreach (GameObject go in AllObjects) 
				{
					go.Update ();
					go.Render ();
				}

				p1.Update ();
				p1.Render ();

				if (SwinGame.MouseClicked (MouseButton.LeftButton))
				{
					AllObjects.Add (p1.Shoot ());
				}

				SwinGame.DrawFramerate (0, 0);



				//Draw onto the screen

				SwinGame.RefreshScreen (60);

			}
			SwinGame.ReleaseAllBitmaps ();
        }
    }
}