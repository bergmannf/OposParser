using System;
using System.Threading;
using System.Windows;

using OposParser;

namespace OposStarter
{
	public class Program
	{
		public static Thread uiThread;
		
		public static void Main()
		{
			Starter.OposParser();
		}
	}
}