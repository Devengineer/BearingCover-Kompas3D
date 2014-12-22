using System;
using System.Windows.Forms;
namespace bearingCover
{
    /// <summary>
    /// Модель крышки подшипника
    /// </summary>
    public class BearingCoverModel
    {
		/// <summary>
		/// Проверка корректности параметров
		/// </summary>
		/// <returns>True, если параметры корректны</returns>
		public bool CheckParams()
		{
			try
			{
				if ((HolesNumber != 4) && (HolesNumber !=6))
				{
					throw new Exception("Число отверстий должно быть равно 4 или 6");
				}

				if (CoverThickness < 16 || CoverThickness > 34)
				{
					throw new Exception("Толщина крышки должна находиться в пределах от 16 до 34 мм");
				}

				if (FrontProjection < 5 || FrontProjection > 10)
				{
					throw new Exception("Выступ спереди должен находиться в пределах от 5 до 10 мм");
				}

				if (BorderThickness < 7 || BorderThickness > 18)
				{
					throw new Exception("Толщина окантовки должна находиться в пределах от 7 до 18 мм");
				}

				if (RearProjection < 3 || RearProjection > 10)
				{
					throw new Exception("Выступ сзади должен находиться в пределах от 3 до 10 мм");
				}

				if (CentralHoleDepth < 10 || CentralHoleDepth > 20)
				{
					throw new Exception("Глубина центрального отверстия должна находиться в пределах от 10 до 20 мм");
				}

				if (PosteriorWallThickness < 6 || PosteriorWallThickness > 14)
				{
					throw new Exception("Толщина задней стенки должна находиться в пределах от 6 до 14 мм");
				}

				if (OutDiameterCentralHole < 110 || OutDiameterCentralHole > 400)
				{
					throw new Exception("Диаметр внешней стенки центрального отверстия должен находиться в пределах от 110 до 400 мм");
				}

				if (HolesDistance < 130 || HolesDistance > 450)
				{
					throw new Exception("Расстояние между отверстиями должно находиться в пределах от 130 до 450 мм");
				}

				if (InDiameterCentralHole < 100 || InDiameterCentralHole > 372)
				{
					throw new Exception("Диаметр внутренней стенки центрального отверстия должен находиться в пределах от 100 до 372 мм");
				}

				if (BearingCoverDiameter < 155 || BearingCoverDiameter > 490)
				{
					throw new Exception("Диаметр крышки подшипника должен находиться в пределах от 155 до 490 мм");
				}

				if (HolesDiameter < 11 || HolesDiameter > 22)
				{
					throw new Exception("Диаметр отверстий должен находиться в пределах от 11 до 22 мм");
				}

				if (DistanceAroundHoles < 20 || DistanceAroundHoles > 36)
				{
					throw new Exception("Диаметр вокруг отверстий должен находиться в пределах от 20 до 36 мм");
				}

				if (DistanceAroundHoles < HolesDiameter)
				{
					throw new Exception("Диаметр вокруг отверстий должен быть больше диаметра отверстий");
				}

				if (DistanceAroundHoles > BearingCoverDiameter - HolesDistance)
				{
					throw new Exception("Диаметр вокруг отверстий должен быть меньше разницы диаметров D3 и D1");
				}

				if (InDiameterCentralHole > OutDiameterCentralHole)
				{
					throw new Exception("Диаметр внутр. стенки центрального отверстия должен быть меньше диаметра внешн. стенки центрального отверстия");
				}

				if (OutDiameterCentralHole > HolesDistance)
				{
					throw new Exception("Диаметр внешн. стенки центрального отверстия должен быть меньше расстояния между отверстиями");
				}

				if (HolesDistance > BearingCoverDiameter)
				{
					throw new Exception("Расстояние между отверстиями должно быть меньше диаметра крышки подшипника");
				}
				if (AngleCut < 0 || AngleCut > 359)
				{
					throw new Exception("Угол разреза должен находиться в пределах от 0 до 359 градусов");
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
		/// Проверка соответствуют ли параметры толщине крышки
		/// </summary>
		/// <returns></returns>
		public bool CheckH()
		{
			try
			{
				if (CoverThickness != BorderThickness + FrontProjection + RearProjection)
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
			this.HolesNumber = 6;
			this.CoverThickness = 34;
			this.FrontProjection = 10;
			this.BorderThickness = 18;
			this.RearProjection = 6;
			this.CentralHoleDepth = 20;
			this.PosteriorWallThickness = 14;
			this.OutDiameterCentralHole = 400;
			this.HolesDistance = 450;
			this.InDiameterCentralHole = 372;
			this.BearingCoverDiameter = 490;
			this.HolesDiameter = 22;
			this.DistanceAroundHoles = 36;
			this.Color = -7303024;
			this.AngleCut = 0;
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
			this.HolesNumber = HolesNumber;
			this.CoverThickness = CoverThickness;
			this.FrontProjection = FrontProjection;
			this.BorderThickness = BorderThickness;
			this.RearProjection = RearProjection;
			this.CentralHoleDepth = CentralHoleDepth;
			this.PosteriorWallThickness = PosteriorWallThickness;
			this.OutDiameterCentralHole = OutDiameterCentralHole;
			this.HolesDistance = HolesDistance;
			this.InDiameterCentralHole = InDiameterCentralHole;
			this.BearingCoverDiameter = BearingCoverDiameter;
			this.HolesDiameter = HolesDiameter;
			this.DistanceAroundHoles = DistanceAroundHoles;
			this.Color = Color;
			this.AngleCut = AngleCut;
		}

        /// <summary>
        /// Число отверстий - n
        /// </summary>
        public int HolesNumber { get; private set; }

        /// <summary>
        /// Толщина крышки - H
        /// </summary>
        public int CoverThickness { get; private set; }

        /// <summary>
        /// Выступ спереди - h
        /// </summary>
        public int FrontProjection { get; private set; }

        /// <summary>
        /// Толщина окантовки - h1
        /// </summary>
        public int BorderThickness { get; private set; }

        /// <summary>
        /// Выступ сзади - h2
        /// </summary>
        public int RearProjection { get; private set; }

        /// <summary>
        /// Глубина центрального отверстия - l
        /// </summary>
        public int CentralHoleDepth { get; private set; }

        /// <summary>
        /// Толщина задней стенки - s
        /// </summary>
        public int PosteriorWallThickness { get; private set; }

        /// <summary>
        /// Диаметр внешней стенки центрального отверстия - D
        /// </summary>
        public int OutDiameterCentralHole { get; private set; }

        /// <summary>
        /// Расстояние между отверстиями - D1
        /// </summary>
        public int HolesDistance { get; private set; }

        /// <summary>
        /// Диаметр внутренней стенки центрального отверстия - D2
        /// </summary>
        public int InDiameterCentralHole { get; private set; }

		/// <summary>
		/// Диаметр крышки подшипника - D3
		/// </summary>
		public int BearingCoverDiameter { get; private set; }

		/// <summary>
		/// Диаметр отверрстий - d
		/// </summary>
		public int HolesDiameter { get; private set; }

		/// <summary>
		/// Диаметр вокруг отверстий - d1
		/// </summary>
		public int DistanceAroundHoles { get; private set; }

		/// <summary>
		/// Цвет детали
		/// </summary>
		public int Color { get; private set; }

		/// <summary>
		/// Угол разреза
		/// </summary>
		public int AngleCut { get; private set; }

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

            return a.HolesNumber == b.HolesNumber
                && a.CoverThickness == b.CoverThickness
                && a.FrontProjection == b.FrontProjection
                && a.RearProjection == b.RearProjection
                && a.BorderThickness == b.BorderThickness
                && a.CentralHoleDepth == b.CentralHoleDepth
                && a.PosteriorWallThickness == b.PosteriorWallThickness
                && a.OutDiameterCentralHole == b.OutDiameterCentralHole
                && a.HolesDistance == b.HolesDistance
                && a.InDiameterCentralHole == b.InDiameterCentralHole
				&& a.BearingCoverDiameter == b.BearingCoverDiameter
				&& a.DistanceAroundHoles == b.DistanceAroundHoles
				&& a.HolesDiameter == b.HolesDiameter
				&& a.Color == b.Color
				&& a.AngleCut == b.AngleCut;
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
