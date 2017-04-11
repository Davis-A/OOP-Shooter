using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyGame
{
	[TestFixture ()]
	public class TestGameObject
	{
		private Bullet _bullet;

		[SetUp]
		public void GameObjectSetup ()
		{
			
		}

		[Test]
		public void TestMovementWhenDeltaZero () 
		{
			_bullet = new Bullet (0, 0, 0, 0, 50, SwinGameSDK.Color.Red);
			//loop a few times, it shouldn't have moved
			for (int i = 0; i < 3; i++) 
			{
				_bullet.Update ();
			}
			Assert.AreEqual (_bullet.X, 0);
			Assert.AreEqual (_bullet.Y, 0);
		}

		[Test]
		public void TestMovementDelta ()
		{
			_bullet = new Bullet (0, 0, 1, 3, 50, SwinGameSDK.Color.Red);
			//loop a few times, it shouldn't have moved
			for (int i = 0; i < 3; i++) {
				_bullet.Update ();
			}
			Assert.AreEqual (_bullet.X, 3);
			Assert.AreEqual (_bullet.Y, 9);
		}


		/*
		 * Test that Drone changes its delta movement every 100 ticks
		 */
		[Test]
		public void TestDeltaMovementChange ()
		{
			List<DeltaMovement> dxdyList = new List<DeltaMovement> ();
			DeltaMovement dxdy;
			dxdy.deltaX = 0;
			dxdy.deltaY = 0;
			dxdyList.Add (dxdy);
			dxdy.deltaX = 1;
			dxdy.deltaY = 2;
			dxdyList.Add (dxdy);


			Drone _drone = new Drone (1, SwinGameSDK.SwinGame.LoadBitmap (@"sprites\enemy.png"), 0, 0, dxdyList);

			for (int i = 0; i < 100; i++) 
			{
				_drone.Update ();
			}

			Assert.AreEqual (_drone.DeltaX, 1);
			Assert.AreEqual (_drone.DeltaY, 2);
		}


		/*
		 * Test that drone remains on it's current delta input if lifetime reaches 100 and there are no remaining changes in the list
		 */
		[Test]
		public void TestDeltaMovementExceedingAvailable ()
		{
			List<DeltaMovement> dxdyList = new List<DeltaMovement> ();
			DeltaMovement dxdy;
			dxdy.deltaX = 0;
			dxdy.deltaY = 0;
			dxdyList.Add (dxdy);
			dxdy.deltaX = 1;
			dxdy.deltaY = 2;
			dxdyList.Add (dxdy);


			Drone _drone = new Drone (1, SwinGameSDK.SwinGame.LoadBitmap (@"sprites\enemy.png"), 0, 0, dxdyList);

			for (int i = 0; i < 100; i++) {
				_drone.Update ();
			}
			//test that they changed

			for (int i = 0; i < 200; i++) 
			{
				_drone.Update ();
			}
			//test they haven't changed
			Assert.AreEqual (_drone.DeltaX, 1);
			Assert.AreEqual (_drone.DeltaY, 2);


		}


	}
}
