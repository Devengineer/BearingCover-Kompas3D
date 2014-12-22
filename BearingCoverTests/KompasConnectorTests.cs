using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bearingCover;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BearingCoverTests
{
	/// <summary>
	/// Тест класса KompasConnector
	/// </summary>
	[TestFixture]
	public class KompasConnectorTests
	{
		/// <summary>
		/// Тест закрытия КОМПАС-3D
		/// </summary>
		[Test]
		public void QuitKompasTest()
		{
			var kompas = new KompasConnector();
			Assert.DoesNotThrow(kompas.QuitKompas);
			//Assert.Throws(typeof(NullReferenceException), kompas.QuitKompas);
		}
	}
}
