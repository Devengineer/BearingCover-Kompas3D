using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bearingCover;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BearingCoverTests
{
	[TestClass]
	public class BearingCoverModelTests
	{
		// Верные установки
		int holesNumber = 6;
		int coverThickness = 34;
		int frontProjection = 10;
		int borderThickness = 18;
		int rearProjection = 6;
		int centralHoleDepth = 20;
		int posteriorWallThickness = 14;
		int outDiameterCentralHole = 400;
		int holesDistance = 450;
		int inDiameterCentralHole = 372;
		int bearingCoverDiameter = 490;
		int holesDiameter = 22;
		int distanceAroundHoles = 36;
		int color = -7303024;
		int angleCut = 0;

		/// <summary>
		/// Проверка конструктора
		/// </summary>
		[TestMethod]
		public void TestModelConstructorSuccess()
		{
			// Действие
			BearingCoverModel model = new BearingCoverModel();

			// Проверка
			Assert.AreEqual(holesNumber, model.HolesNumber);
			Assert.AreEqual(coverThickness, model.CoverThickness);
			Assert.AreEqual(frontProjection, model.FrontProjection);
			Assert.AreEqual(borderThickness, model.BorderThickness);
			Assert.AreEqual(rearProjection, model.RearProjection);
			Assert.AreEqual(centralHoleDepth, model.CentralHoleDepth);
			Assert.AreEqual(posteriorWallThickness, model.PosteriorWallThickness);
			Assert.AreEqual(outDiameterCentralHole, model.OutDiameterCentralHole);
			Assert.AreEqual(holesDistance, model.HolesDistance);
			Assert.AreEqual(inDiameterCentralHole, model.InDiameterCentralHole);
			Assert.AreEqual(bearingCoverDiameter, model.BearingCoverDiameter);
			Assert.AreEqual(holesDiameter, model.HolesDiameter);
			Assert.AreEqual(distanceAroundHoles, model.DistanceAroundHoles);
			Assert.AreEqual(color, model.Color);
			Assert.AreEqual(angleCut, model.AngleCut);
		}

		/// <summary>
		/// Проверка конструктора c ошибкой
		/// </summary>
		[TestMethod]
		public void TestModelConstructorFail()
		{
			// Действие
			BearingCoverModel model = new BearingCoverModel(5, coverThickness,
				frontProjection, borderThickness, rearProjection, centralHoleDepth,
				posteriorWallThickness, outDiameterCentralHole, holesDistance,
				inDiameterCentralHole, bearingCoverDiameter, holesDiameter, distanceAroundHoles,
				color, angleCut);

			// Проверка
			Assert.AreNotEqual(holesNumber, model.HolesNumber);
			Assert.AreEqual(coverThickness, model.CoverThickness);
			Assert.AreEqual(frontProjection, model.FrontProjection);
			Assert.AreEqual(borderThickness, model.BorderThickness);
			Assert.AreEqual(rearProjection, model.RearProjection);
			Assert.AreEqual(centralHoleDepth, model.CentralHoleDepth);
			Assert.AreEqual(posteriorWallThickness, model.PosteriorWallThickness);
			Assert.AreEqual(outDiameterCentralHole, model.OutDiameterCentralHole);
			Assert.AreEqual(holesDistance, model.HolesDistance);
			Assert.AreEqual(inDiameterCentralHole, model.InDiameterCentralHole);
			Assert.AreEqual(bearingCoverDiameter, model.BearingCoverDiameter);
			Assert.AreEqual(holesDiameter, model.HolesDiameter);
			Assert.AreEqual(distanceAroundHoles, model.DistanceAroundHoles);
			Assert.AreEqual(color, model.Color);
			Assert.AreEqual(angleCut, model.AngleCut);
		}

		/// <summary>
		/// Проверка сравнения моделей
		/// </summary>
		[TestMethod]
		public void TestModelEqualSuccess()
		{
			BearingCoverModel modelFirst = new BearingCoverModel();
			BearingCoverModel modelSecond = new BearingCoverModel();

			// Проверка
			if (modelFirst == modelSecond)
			{
				Assert.AreEqual(modelFirst.HolesNumber, modelSecond.HolesNumber);
				Assert.AreEqual(modelFirst.CoverThickness, modelSecond.CoverThickness);
				Assert.AreEqual(modelFirst.FrontProjection, modelSecond.FrontProjection);
				Assert.AreEqual(modelFirst.BorderThickness, modelSecond.BorderThickness);
				Assert.AreEqual(modelFirst.RearProjection, modelSecond.RearProjection);
				Assert.AreEqual(modelFirst.CentralHoleDepth, modelSecond.CentralHoleDepth);
				Assert.AreEqual(modelFirst.PosteriorWallThickness,
					modelSecond.PosteriorWallThickness);
				Assert.AreEqual(modelFirst.OutDiameterCentralHole,
					modelSecond.OutDiameterCentralHole);
				Assert.AreEqual(modelFirst.HolesDistance, modelSecond.HolesDistance);
				Assert.AreEqual(modelFirst.InDiameterCentralHole,
					modelSecond.InDiameterCentralHole);
				Assert.AreEqual(modelFirst.BearingCoverDiameter, modelSecond.BearingCoverDiameter);
				Assert.AreEqual(modelFirst.HolesDiameter, modelSecond.HolesDiameter);
				Assert.AreEqual(modelFirst.DistanceAroundHoles, modelSecond.DistanceAroundHoles);
				Assert.AreEqual(modelFirst.Color, modelSecond.Color);
				Assert.AreEqual(modelFirst.AngleCut, modelSecond.AngleCut);
			}
		}

		/// <summary>
		/// Проверка сравнения моделей с ошибкой
		/// </summary>
		[TestMethod]
		public void TestModelEqualFail()
		{
			BearingCoverModel modelFirst = new BearingCoverModel();
			BearingCoverModel modelSecond = new BearingCoverModel(5, coverThickness,
				frontProjection, borderThickness, rearProjection, centralHoleDepth,
				posteriorWallThickness, outDiameterCentralHole, holesDistance,
				inDiameterCentralHole, bearingCoverDiameter, holesDiameter, distanceAroundHoles,
				color, angleCut);

			// Проверка
			if (modelFirst == modelSecond)
			{
				Assert.AreEqual(modelFirst.HolesNumber, modelSecond.HolesNumber);
				Assert.AreEqual(modelFirst.CoverThickness, modelSecond.CoverThickness);
				Assert.AreEqual(modelFirst.FrontProjection, modelSecond.FrontProjection);
				Assert.AreEqual(modelFirst.BorderThickness, modelSecond.BorderThickness);
				Assert.AreEqual(modelFirst.RearProjection, modelSecond.RearProjection);
				Assert.AreEqual(modelFirst.CentralHoleDepth, modelSecond.CentralHoleDepth);
				Assert.AreEqual(modelFirst.PosteriorWallThickness,
					modelSecond.PosteriorWallThickness);
				Assert.AreEqual(modelFirst.OutDiameterCentralHole,
					modelSecond.OutDiameterCentralHole);
				Assert.AreEqual(modelFirst.HolesDistance, modelSecond.HolesDistance);
				Assert.AreEqual(modelFirst.InDiameterCentralHole,
					modelSecond.InDiameterCentralHole);
				Assert.AreEqual(modelFirst.BearingCoverDiameter, modelSecond.BearingCoverDiameter);
				Assert.AreEqual(modelFirst.HolesDiameter, modelSecond.HolesDiameter);
				Assert.AreEqual(modelFirst.DistanceAroundHoles, modelSecond.DistanceAroundHoles);
				Assert.AreEqual(modelFirst.Color, modelSecond.Color);
				Assert.AreEqual(modelFirst.AngleCut, modelSecond.AngleCut);
			}
			else
			{
				Assert.AreNotEqual(modelFirst.HolesNumber, modelSecond.HolesNumber);
			}
		}

		/// <summary>
		/// Тест проверки параметров
		/// </summary>
		[TestMethod]
		public void TestCheckParams()
		{
			// Действие
			BearingCoverModel model = new BearingCoverModel();
			
			// Проверка
			Assert.IsTrue(model.CheckParams());
		}

		/// <summary>
		/// Тест проверки H параметров
		/// </summary>
		[TestMethod]
		public void TestCheckHParams()
		{
			// Действие
			BearingCoverModel model = new BearingCoverModel(holesNumber, coverThickness,
				frontProjection, borderThickness, rearProjection, centralHoleDepth,
				posteriorWallThickness, outDiameterCentralHole, holesDistance,
				inDiameterCentralHole, bearingCoverDiameter, holesDiameter, distanceAroundHoles,
				color, angleCut);

			// Проверка
			Assert.IsTrue(model.CheckH());
		}
	}
}
