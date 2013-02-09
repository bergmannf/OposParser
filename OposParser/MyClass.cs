/*
 * Created by SharpDevelop.
 * User: admgertrudbergmann
 * Date: 08.06.2012
 * Time: 16:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace OposParser
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class MyClass
	{
        private string _DoSomething;
        private string DoSomething
        {
            get
            {
                return _DoSomething;
            }
            set
            {
                _DoSomething = value;
            }
        }
	}
}