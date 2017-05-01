using System;
using System.IO;


namespace MyGame
{
	public static class ExtensionMethods
	{
		public static int [] ReadCSVInt (this StreamReader reader)
		{
			//read CSV line, split by ',' convert to int[]
			//return Array.ConvertAll (reader.ReadLine().Split (','), int.Parse);

			string LineString = reader.ReadLine ();
			if (LineString != null) 
			{
				return Array.ConvertAll (LineString.Split (','), int.Parse);
			}
			else return null;

		}


	}
}
