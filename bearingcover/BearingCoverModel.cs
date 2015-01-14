using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace bearingCover
{
    /// <summary>
    /// Модель крышки подшипника
    /// </summary>
    public class BearingCoverModel
    {
		private List<Parameter> _parameters = new List<Parameter>();

		/// <summary>
		/// Проверка корректности параметров
		/// </summary>
		/// <returns>True, если параметры корректны</returns>
		public bool CheckParams()
		{
			try
			{
				foreach (var parameter in _parameters)
				{
					if ((parameter.Value < parameter.Min)
						|| (parameter.Value > parameter.Max))
					{
						throw new Exception(String.Format("{0} должен находиться в пределах от {1} до {2} мм", parameter.Description, parameter.Min, parameter.Max));
					}
				}
				if ((HolesNumber.Value != HolesNumber.Min) && (HolesNumber.Value != HolesNumber.Max))
				{
					throw new Exception("Число отверстий должно быть равно 4 или 6");
				}

				//if (CoverThickness.Value < CoverThickness.Min ||
				//	CoverThickness.Value > CoverThickness.Max)
				//{
				//	throw new Exception("Толщина крышки должна находиться в пределах от 16 до 34 мм");
				//}

				//if (FrontProjection.Value < FrontProjection.Min ||
				//	FrontProjection.Value > FrontProjection.Max)
				//{
				//	throw new Exception("Выступ спереди должен находиться в пределах от 5 до 10 мм");
				//}

				//if (BorderThickness.Value < BorderThickness.Min ||
				//	BorderThickness.Value > BorderThickness.Max)
				//{
				//	throw new Exception("Толщина окантовки должна находиться в пределах от 7 до 18 мм");
				//}

				//if (RearProjection.Value < RearProjection.Min ||
				//	RearProjection.Value > RearProjection.Max)
				//{
				//	throw new Exception("Выступ сзади должен находиться в пределах от 3 до 10 мм");
				//}

				//if (CentralHoleDepth.Value < CentralHoleDepth.Min ||
				//	CentralHoleDepth.Value > CentralHoleDepth.Max)
				//{
				//	throw new Exception("Глубина центрального отверстия должна находиться в пределах от 10 до 20 мм");
				//}

				//if (PosteriorWallThickness.Value < PosteriorWallThickness.Min ||
				//	PosteriorWallThickness.Value > PosteriorWallThickness.Max)
				//{
				//	throw new Exception("Толщина задней стенки должна находиться в пределах от 6 до 14 мм");
				//}

				//if (OutDiameterCentralHole.Value < OutDiameterCentralHole.Min ||
				//	OutDiameterCentralHole.Value > OutDiameterCentralHole.Max)
				//{
				//	throw new Exception("Диаметр внешней стенки центрального отверстия должен находиться в пределах от 110 до 400 мм");
				//}

				//if (HolesDistance.Value < HolesDistance.Min ||
				//	HolesDistance.Value > HolesDistance.Max)
				//{
				//	throw new Exception("Расстояние между отверстиями должно находиться в пределах от 130 до 450 мм");
				//}

				//if (InDiameterCentralHole.Value < InDiameterCentralHole.Min ||
				//	InDiameterCentralHole.Value > InDiameterCentralHole.Max)
				//{
				//	throw new Exception("Диаметр внутренней стенки центрального отверстия должен находиться в пределах от 100 до 372 мм");
				//}

				//if (BearingCoverDiameter.Value < BearingCoverDiameter.Min ||
				//	BearingCoverDiameter.Value > BearingCoverDiameter.Max)
				//{
				//	throw new Exception("Диаметр крышки подшипника должен находиться в пределах от 155 до 490 мм");
				//}

				//if (HolesDiameter.Value < HolesDiameter.Min ||
				//	HolesDiameter.Value > HolesDiameter.Max)
				//{
				//	throw new Exception("Диаметр отверстий должен находиться в пределах от 11 до 22 мм");
				//}

				//if (DistanceAroundHoles.Value < DistanceAroundHoles.Min ||
				//	DistanceAroundHoles.Value > DistanceAroundHoles.Max)
				//{
				//	throw new Exception("Диаметр вокруг отверстий должен находиться в пределах от 20 до 36 мм");
				//}

				if (DistanceAroundHoles.Value < HolesDiameter.Value)
				{
					throw new Exception("Диаметр вокруг отверстий должен быть больше диаметра отверстий");
				}

				if (DistanceAroundHoles.Value > BearingCoverDiameter.Value - HolesDistance.Value)
				{
					throw new Exception("Диаметр вокруг отверстий должен быть меньше разницы диаметров D3 и D1");
				}

				if (InDiameterCentralHole.Value > OutDiameterCentralHole.Value)
				{
					throw new Exception("Диаметр внутр. стенки центрального отверстия должен быть меньше диаметра внешн. стенки центрального отверстия");
				}

				if (OutDiameterCentralHole.Value > HolesDistance.Value)
				{
					throw new Exception("Диаметр внешн. стенки центрального отверстия должен быть меньше расстояния между отверстиями");
				}

				if (HolesDistance.Value > BearingCoverDiameter.Value)
				{
					throw new Exception("Расстояние между отверстиями должно быть меньше диаметра крышки подшипника");
				}

				//if (AngleCut.Value < AngleCut.Min ||
				//	AngleCut.Value > AngleCut.Max)
				//{
				//	throw new Exception("Угол разреза должен находиться в пределах от 0 до 359 градусов");
				//}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		/// <summary>
		/// Проверка соответствуют ли параметры толщине крышки
		/// </summary>
		/// <returns></returns>
		public bool CheckH()
		{
			try
			{
				if (CoverThickness.Value != BorderThickness.Value + FrontProjection.Value +
					RearProjection.Value)
				{
					throw new Exception("Толщина крышки должна быть равна сумме h, h1 и h2");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		/// <summary>
		/// Стандартный конструктор модели крышки подшипника
		/// </summary>
		/// <param name="HolesNumber">Число отверстий</param>
		/// <param name="CoverThickness">Толщина крышки</param>
		/// <param name="FrontProjection">Выступ спереди</param>
		/// <param name="BorderThickness">Толщина окантовки</param>
		/// <param name="RearProjection">Выступ сзади</param>
		/// <param name="CentralHoleDepth">Глубина центрального отверстия</param>
		/// <param name="PosteriorWallThickness">Толщина задней стенки</param>
		/// <param name="OutDiameterCentralHole">Диаметр внешней стенки центрального отверстия</param>
		/// <param name="HolesDistance">Расстояние между отверстиями</param>
		/// <param name="InDiameterCentralHole">Диаметр внутренней стенки центрального отверстия</param>
		/// <param name="BearingCoverDiameter">Диаметр крышки подшипника</param>
		/// <param name="HolesDiameter">Диаметр отверстий</param>
		/// <param name="DistanceAroundHoles">Диаметр вокруг отверстий</param>
		/// <param name="Color">Цвет</param>
		/// <param name="AngleCut">Угол разреза</param>
		public BearingCoverModel()
		{
			InitParams(6, 34, 10, 18, 6, 20, 14, 400, 450, 372, 490, 22, 36, 0);
			//this.HolesNumber = 6;
			//this.CoverThickness = 34;
			//this.FrontProjection = 10;
			//this.BorderThickness = 18;
			//this.RearProjection = 6;
			//this.CentralHoleDepth = 20;
			//this.PosteriorWallThickness = 14;
			//this.OutDiameterCentralHole = 400;
			//this.HolesDistance = 450;
			//this.InDiameterCentralHole = 372;
			//this.BearingCoverDiameter = 490;
			//this.HolesDiameter = 22;
			//this.DistanceAroundHoles = 36;
			this.Color = -7303024;
			//this.AngleCut = 0;
		}

		/// <summary>
		/// Конструктор модели крышки подшипника
		/// </summary>
		/// <param name="HolesNumber">Число отверстий</param>
		/// <param name="CoverThickness">Толщина крышки</param>
		/// <param name="FrontProjection">Выступ спереди</param>
		/// <param name="BorderThickness">Толщина окантовки</param>
		/// <param name="RearProjection">Выступ сзади</param>
		/// <param name="CentralHoleDepth">Глубина центрального отверстия</param>
		/// <param name="PosteriorWallThickness">Толщина задней стенки</param>
		/// <param name="OutDiameterCentralHole">Диаметр внешней стенки центрального отверстия</param>
		/// <param name="HolesDistance">Расстояние между отверстиями</param>
		/// <param name="InDiameterCentralHole">Диаметр внутренней стенки центрального отверстия</param>
		/// <param name="BearingCoverDiameter">Диаметр крышки подшипника</param>
		/// <param name="HolesDiameter">Диаметр отверстий</param>
		/// <param name="DistanceAroundHoles">Диаметр вокруг отверстий</param>
		/// <param name="Color">Цвет</param>
		/// <param name="AngleCut">Угол разреза</param>
		public BearingCoverModel(int HolesNumber, int CoverThickness, int FrontProjection,
			int BorderThickness, int RearProjection, int CentralHoleDepth,
			int PosteriorWallThickness, int OutDiameterCentralHole, int HolesDistance,
			int InDiameterCentralHole, int BearingCoverDiameter, int HolesDiameter,
			int DistanceAroundHoles, int Color, int AngleCut)
		{
			InitParams(HolesNumber, CoverThickness, FrontProjection,
				BorderThickness, RearProjection, CentralHoleDepth,
				PosteriorWallThickness, OutDiameterCentralHole, HolesDistance,
				InDiameterCentralHole, BearingCoverDiameter, HolesDiameter,
				DistanceAroundHoles, AngleCut);
			//this.HolesNumber = HolesNumber;
			//this.CoverThickness = CoverThickness;
			//this.FrontProjection = FrontProjection;
			//this.BorderThickness = BorderThickness;
			//this.RearProjection = RearProjection;
			//this.CentralHoleDepth = CentralHoleDepth;
			//this.PosteriorWallThickness = PosteriorWallThickness;
			//this.OutDiameterCentralHole = OutDiameterCentralHole;
			//this.HolesDistance = HolesDistance;
			//this.InDiameterCentralHole = InDiameterCentralHole;
			//this.BearingCoverDiameter = BearingCoverDiameter;
			//this.HolesDiameter = HolesDiameter;
			//this.DistanceAroundHoles = DistanceAroundHoles;
			this.Color = Color;
			//this.AngleCut = AngleCut;
		}

		/// <summary>
		/// Инициализация параметров
		/// </summary>
		/// <param name="holesNumber"></param>
		/// <param name="coverThickness"></param>
		/// <param name="frontProjection"></param>
		/// <param name="borderThickness"></param>
		/// <param name="rearProjection"></param>
		/// <param name="centralHoleDepth"></param>
		/// <param name="posteriorWallThickness"></param>
		/// <param name="outDiameterCentralHole"></param>
		/// <param name="holesDistance"></param>
		/// <param name="inDiameterCentralHole"></param>
		/// <param name="bearingCoverDiameter"></param>
		/// <param name="holesDiameter"></param>
		/// <param name="distanceAroundHoles"></param>
		/// <param name="angleCut"></param>
		private void InitParams(int holesNumber, int coverThickness, int frontProjection,
			int borderThickness, int rearProjection, int centralHoleDepth,
			int posteriorWallThickness, int outDiameterCentralHole, int holesDistance,
			int inDiameterCentralHole, int bearingCoverDiameter, int holesDiameter,
			int distanceAroundHoles, int angleCut)
		{
			_parameters.Add(new Parameter("holesNumber", "Число отверстий", holesNumber, 4, 6));
			_parameters.Add(new Parameter("coverThickness", "Толщина крышки", coverThickness, 16, 34));
			_parameters.Add(new Parameter("frontProjection", "Выступ спереди", frontProjection, 5, 10));
			_parameters.Add(new Parameter("borderThickness", "Толщина окантовки", borderThickness, 7, 18));
			_parameters.Add(new Parameter("rearProjection", "Выступ сзади", rearProjection, 3, 10));
			_parameters.Add(new Parameter("centralHoleDepth", "Глубина центрального отверстия", centralHoleDepth, 10, 20));
			_parameters.Add(new Parameter("posteriorWallThickness", "Толщина задней стенки", posteriorWallThickness,
				6, 14));
			_parameters.Add(new Parameter("outDiameterCentralHole", "Диаметр внешней стенки центрального отверстия", outDiameterCentralHole,
				110, 400));
			_parameters.Add(new Parameter("holesDistance", "Расстояние между отверстиями", holesDistance, 130, 450));
			_parameters.Add(new Parameter("inDiameterCentralHole", "Диаметр внутренней стенки центрального отверстия", inDiameterCentralHole,
				100, 372));
			_parameters.Add(new Parameter("bearingCoverDiameter", "Диаметр крышки подшипника", bearingCoverDiameter,
				155, 490));
			_parameters.Add(new Parameter("holesDiameter", "Диаметр отверстий", holesDiameter, 11, 22));
			_parameters.Add(new Parameter("distanceAroundHoles", "Диаметр вокруг отверстий", distanceAroundHoles,
				20, 36));
			//this.Color = -7303024;
			_parameters.Add(new Parameter("angleCut", "Угол разреза", angleCut, 0, 359));
		}

		public struct Parameter
		{
			public string Name { get; private set; }
			public string Description { get; private set; }
			public int Value { get; set; }
			public int Min { get; private set; }
			public int Max { get; private set; }

			//public Parameter(string description, int value, int min, int max)
			public Parameter(string name, string description, int value, int min, int max) : this()
			{
				Name = name;
				Description = description;
				Value = value;
				Min = min;
				Max = max;
			}
		}

		/// <summary>
		/// Число отверстий - n
		/// </summary>
		public Parameter HolesNumber
		{ 
			get
			{
				return _parameters.Find(parameter => parameter.Name == "holesNumber");
			}
		}

		/// <summary>
		/// Толщина крышки - H
		/// </summary>
		public Parameter CoverThickness
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "coverThickness");
			}
		}

		/// <summary>
		/// Выступ спереди - h
		/// </summary>
		public Parameter FrontProjection
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "frontProjection");
			}
		}

		/// <summary>
		/// Толщина окантовки - h1
		/// </summary>
		public Parameter BorderThickness
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "borderThickness");
			}
		}

		/// <summary>
		/// Выступ сзади - h2
		/// </summary>
		public Parameter RearProjection
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "rearProjection");
			}
		}

		/// <summary>
		/// Глубина центрального отверстия - l
		/// </summary>
		public Parameter CentralHoleDepth
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "centralHoleDepth");
			}
		}

		/// <summary>
		/// Толщина задней стенки - s
		/// </summary>
		public Parameter PosteriorWallThickness
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "posteriorWallThickness");
			}
		}

		/// <summary>
		/// Диаметр внешней стенки центрального отверстия - D
		/// </summary>
		public Parameter OutDiameterCentralHole
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "outDiameterCentralHole");
			}
		}

		/// <summary>
		/// Расстояние между отверстиями - D1
		/// </summary>
		public Parameter HolesDistance
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "holesDistance");
			}
		}

		/// <summary>
		/// Диаметр внутренней стенки центрального отверстия - D2
		/// </summary>
		public Parameter InDiameterCentralHole
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "inDiameterCentralHole");
			}
		}

		/// <summary>
		/// Диаметр крышки подшипника - D3
		/// </summary>
		public Parameter BearingCoverDiameter
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "bearingCoverDiameter");
			}
		}

		/// <summary>
		/// Диаметр отверрстий - d
		/// </summary>
		public Parameter HolesDiameter
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "holesDiameter");
			}
		}

		/// <summary>
		/// Диаметр вокруг отверстий - d1
		/// </summary>
		public Parameter DistanceAroundHoles
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "distanceAroundHoles");
			}
		}

		/// <summary>
		/// Цвет детали
		/// </summary>
		public int Color { get; private set; }

		/// <summary>
		/// Угол разреза
		/// </summary>
		public Parameter AngleCut
		{
			get
			{
				return _parameters.Find(parameter => parameter.Name == "angleCut");
			}
		}

        /// <summary>
        /// Оператор "равно"
        /// </summary>
        /// <param name="a">Первый операнд</param>
        /// <param name="b">Второй операнд</param>
        public static bool operator ==(BearingCoverModel a, BearingCoverModel b)
        {
            if (Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.HolesNumber.Value == b.HolesNumber.Value
                && a.CoverThickness.Value == b.CoverThickness.Value
				&& a.FrontProjection.Value == b.FrontProjection.Value
				&& a.RearProjection.Value == b.RearProjection.Value
				&& a.BorderThickness.Value == b.BorderThickness.Value
				&& a.CentralHoleDepth.Value == b.CentralHoleDepth.Value
				&& a.PosteriorWallThickness.Value == b.PosteriorWallThickness.Value
				&& a.OutDiameterCentralHole.Value == b.OutDiameterCentralHole.Value
				&& a.HolesDistance.Value == b.HolesDistance.Value
				&& a.InDiameterCentralHole.Value == b.InDiameterCentralHole.Value
				&& a.BearingCoverDiameter.Value == b.BearingCoverDiameter.Value
				&& a.DistanceAroundHoles.Value == b.DistanceAroundHoles.Value
				&& a.HolesDiameter.Value == b.HolesDiameter.Value
				&& a.Color == b.Color
				&& a.AngleCut.Value == b.AngleCut.Value;
        }

        /// <summary>
        /// Оператор "не равно"
        /// </summary>
        /// <param name="a">Первый операнд</param>
        /// <param name="b">Второй операнд</param>
        /// <returns></returns>
        public static bool operator !=(BearingCoverModel a, BearingCoverModel b)
        {
            return !(a == b);
        }
    }
}
