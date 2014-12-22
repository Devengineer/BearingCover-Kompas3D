using System.Windows.Forms;

namespace bearingCover
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using Kompas6API5;
    using Kompas6Constants3D;

    /// <summary>
    /// Класс для отрисовки крышки подшипника
    /// </summary>
    public class BearingCoverDrawer
    {
		/// <summary>
        /// Объект КОМПАС-3D
        /// </summary>
        private readonly KompasObject _kompas;

        /// <summary>
        /// Документ КОМПАС-3D
        /// </summary>
        private readonly ksDocument3D _document;

        /// <summary>
        /// Модель параметров крышки подшипника
        /// </summary>
        private readonly BearingCoverModel _model;

		/// <summary>
		/// Окружение
		/// </summary>
		private const double _ambient = .5;

		/// <summary>
		/// Рассеивание
		/// </summary>
		private const double _diffuse = .6;

		/// <summary>
		/// Зеркальность
		/// </summary>
		private const double _specularity = .8;

		/// <summary>
		/// Блеск
		/// </summary>
		private const double _shininess = .8;

		/// <summary>
		/// Прозрачность
		/// </summary>
		private const double _transparency = 1;

		/// <summary>
		/// Излучение
		/// </summary>
		private const double _emission = .5;

        /// <summary>
        /// Конструктор класса <see cref="BearingCoverDrawer"/>
        /// </summary>
        /// <param name="ksObject">Объект КОМПАС-3D</param>
        /// <param name="ksDocument">Документ КОМПАС-3D</param>
        /// <param name="_model">Модель параметров крышки подшипника</param>
        public BearingCoverDrawer(KompasObject ksObject, ksDocument3D ksDocument, BearingCoverModel model)
        {
            _kompas = ksObject;
            _document = ksDocument;
            _model = model;
        }

        /// <summary>
        /// Нарисовать крышку подшипника
        /// </summary>
        /// <param name="_model">Параметры крышки подшипника</param>
        public void Draw()
        {
            // Численные константы
            // Первый параметр - смещение по оси
            // Второй, если есть - длина элемента вдоль той же оси
            try
            {
				DrawExBear(0, _model.CoverThickness);
				DrawBorder(_model.FrontProjection, _model.BorderThickness);
				DrawInBear(_model.CentralHoleDepth, -(_model.CentralHoleDepth));
				DrawHoles((_model.CoverThickness - _model.RearProjection),
					-(_model.BorderThickness), _model.HolesNumber);
				DrawAroundHoles((_model.CoverThickness - _model.RearProjection),
					-1, _model.HolesNumber);
				Fillet(5);
				if (_model.AngleCut != 0)
				{
					Cut(50, _model.AngleCut);
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show("При отрисовке крышки подшипника произошла ошибка: " + ex.ToString());
            }
        }

		/// <summary>
		/// Нарисовать внешнюю стенку крышки подшипника
		/// </summary>
		/// <param name="start">Точка начала</param>
		/// <param name="length">Длина</param>
		private void DrawExBear(int start, int length)
		{
			ksEntity sketch;
			ksSketchDefinition sketchDef;

			var radius = _model.OutDiameterCentralHole / 2;

			CreateSketch(out sketch, out sketchDef, start);
			var editSketch = (ksDocument2D)sketchDef.BeginEdit();

			editSketch.ksCircle(0, 0, radius, 1);

			sketchDef.EndEdit();

			ExtrudeSketch(sketch, length);
		}

		/// <summary>
		/// Нарисовать центральное отверстие крышки подшипника
		/// </summary>
		/// <param name="start">Точка начала</param>
		/// <param name="length">Длина</param>
		private void DrawInBear(int start, int length)
		{
			ksEntity sketch;
			ksSketchDefinition sketchDef;

			var radius = _model.InDiameterCentralHole / 2;

			CreateSketch(out sketch, out sketchDef, start);
			var editSketch = (ksDocument2D)sketchDef.BeginEdit();

			editSketch.ksCircle(0, 0, radius, 1);

			sketchDef.EndEdit();

			// Выдавить
			ExtrudeSketch(sketch, length);
		}

		/// <summary>
		/// Нарисовать окантовку крышки подшипника
		/// </summary>
		/// <param name="start">Точка начала</param>
		/// <param name="length">Длина</param>
		private void DrawBorder(int start, int length)
		{
			ksEntity sketch;
			ksSketchDefinition sketchDef;

			// Радиус крышки подшипника
			var radius = _model.BearingCoverDiameter / 2;

			// Создать эскиз
			CreateSketch(out sketch, out sketchDef, start);
			var editSketch = (ksDocument2D)sketchDef.BeginEdit();

			editSketch.ksCircle(0, 0, radius, 1);

			sketchDef.EndEdit();

			// Выдавить
			ExtrudeSketch(sketch, length);
		}

		/// <summary>
		/// Нарисовать отверстия
		/// </summary>
		/// <param name="start">Точка начала</param>
		/// <param name="length">Длина</param>
		/// <param name="holesNumber">Число отверстий</param>
		private void DrawHoles(int start, int length, int holesNumber)
		{
			ksEntity sketch;
			ksSketchDefinition sketchDef;

			CreateSketch(out sketch, out sketchDef, start);
			var editSketch = (ksDocument2D)sketchDef.BeginEdit();

			// Радиус отверстий
			var radius = _model.HolesDiameter / 2;

			// Расстояние от центра до отверстий
			var distance = _model.HolesDistance / 2;

			// Координаты X, Y и угол поворота
			double x = 0;
			double y = 0;
			double angle = 0;

			// Создание отверстий
			for (int i = 1; i <= holesNumber; i++)
			{
				y = distance * Math.Cos(angle);
				x = distance * Math.Sin(angle);

				editSketch.ksCircle(x, y, radius, 1);

				angle = angle + (360 / holesNumber) * (Math.PI / 180);
			}

			sketchDef.EndEdit();

			// Выдавить
			ExtrudeSketch(sketch, length);
		}

		/// <summary>
		/// Нарисовать вырез вокруг отверстий
		/// </summary>
		/// <param name="start">Точка начала</param>
		/// <param name="length">Длина</param>
		/// <param name="holesNumber">Число отверстий</param>
		private void DrawAroundHoles(int start, int length, int holesNumber)
		{
			ksEntity sketch;
			ksSketchDefinition sketchDef;

			CreateSketch(out sketch, out sketchDef, start);
			var editSketch = (ksDocument2D)sketchDef.BeginEdit();

			// Радиус отверстий
			var radius = _model.DistanceAroundHoles / 2;

			// Расстояние от центра до отверстий
			var distance = _model.HolesDistance / 2;

			// Координаты X, Y и угол поворота
			double x = 0;
			double y = 0;
			double angle = 0;

			// Создание отверстий
			for (int i = 1; i <= holesNumber; i++)
			{
				y = distance * Math.Cos(angle);
				x = distance * Math.Sin(angle);

				editSketch.ksCircle(x, y, radius, 1);

				angle = angle + (360 / holesNumber) * (Math.PI / 180);
			}

			sketchDef.EndEdit();

			// Выдавить
			ExtrudeSketch(sketch, length);
		}

        /// <summary>
        /// Создать эскиз
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="sketchDef">Определение эскиза</param>
        /// <param name="offset">Смещение от начальной плоскости</param>
        /// <param name="startPlane">Начальная плоскость</param>
        private void CreateSketch(out ksEntity sketch, out ksSketchDefinition sketchDef, double offset = 0, short startPlane = (short)Obj3dType.o3d_planeXOY)
        {
            // Создаем компонент детали
            var part = (ksPart)_document.GetPart((short)Part_Type.pNew_Part);
            if (part == null)
            {
                throw new Exception("Невозможно создать компонент детали");
            }

            // Создаем эскиз
            sketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            if (sketch == null)
            {
                throw new Exception("Невозможно создать эскиз");
            }

            sketchDef = (ksSketchDefinition)sketch.GetDefinition();
            if (sketchDef == null)
            {
                throw new Exception("Невозможно получить доступ к интерфейсу свойств эскиза");
            }

            var basePlane = (ksEntity)part.GetDefaultEntity(startPlane);
            // Создаем смещенную плоскость
            ksEntity entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            if (entityOffsetPlane == null)
            {
                throw new Exception("Невозможно создать смещенную плоскость");
            }

            ksPlaneOffsetDefinition offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
            if (offsetDef == null)
            {
                throw new Exception("Невозможно получить объект параметров для смещенной плоскости");
            }

            offsetDef.direction = offset < 0 ? false : true;
            offsetDef.offset = Math.Abs(offset);			// расстояние от базовой плоскости
            offsetDef.SetPlane(basePlane);
            entityOffsetPlane.hidden = true;
            entityOffsetPlane.Create();						// создать смещенную плоскость

            sketchDef.SetPlane(entityOffsetPlane);
            sketch.Create();
        }

        /// <summary>
        /// Выдавить эскиз
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="height">Длина объекта в направлении выдавливания</param>
        /// <param name="direction">Направление выдавливания</param>
        /// <param name="thickness">Толщина стенки</param>
        private void ExtrudeSketch(ksEntity sketch, double height, short direction = (short)Direction_Type.dtNormal, int thickness = 0, int angle = 0)
        {
            // Создаем компонент детали
            var part = (ksPart)_document.GetPart((short)Part_Type.pNew_Part);
            if (part == null)
            {
                throw new Exception("Невозможно создать компонент детали");
            }

			// Направление выдавливания
            var extr = height >= 0 ? (ksEntity)part.NewEntity((short)Obj3dType.o3d_baseExtrusion)
                : (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            if (extr == null)
            {
                throw new Exception("Невозможно создать операцию выдавливания");
            }

            var extrDef = extr.GetDefinition();
            if (extrDef == null)
            {
                throw new Exception("Невозможно получить интерфейс параметров операции выдавливания");
            }
            // Выдавливаем
            extrDef.directionType = direction;
            extrDef.SetSideParam(direction == (short)Direction_Type.dtNormal ? true : false, (short)End_Type.etBlind, Math.Abs(height), angle, false);
            if (thickness > 0)
            {
                extrDef.SetThinParam(true, direction == (short)Direction_Type.dtNormal ? true : false, thickness, thickness);
            }
            extrDef.SetSketch(sketch);
			extr.SetAdvancedColor(_model.Color, _ambient, _diffuse, _specularity, _shininess,
				_transparency, _emission);
            extr.Create();
        }

		/// <summary>
		/// Скругление
		/// <param name="radius">Радиус скругления</param>
		/// <param name="n">Индекс</param>
		private void Fillet(int radius)
		{
			// Создаем компонент детали
			var part = (ksPart)_document.GetPart((short)Part_Type.pTop_Part);
			if (part == null)
			{
				throw new Exception("Невозможно создать компонент детали");
			}

			// Получаем интерфейс объекта "скругление"
			var fillet = (ksEntity)part.NewEntity((short)Obj3dType.o3d_fillet);
			if (fillet == null)
			{
				throw new Exception("Невозможно создать операцию скругления");
			}

			// Получаем интерфейс параметров объекта "скругление"
			var filletDef = fillet.GetDefinition();
			if (filletDef == null)
			{
				throw new Exception("Невозможно получить интерфейс параметров операции скругления");
			}

			// Скругление
			// Радис скругления
			filletDef.radius = radius;
			// Не продолжать по касательным ребрам
			filletDef.tangent = false;
			// Получаем массив ребер детали
			var EntityCollectionPart =
				(ksEntityCollection)part.EntityCollection((short)Obj3dType.o3d_edge);
			// Получаем массив скругляемых ребер
			var EntityCollectionFillet = (ksEntityCollection)filletDef.array();
			EntityCollectionFillet.Clear();
			// Заполняем массив скругляемых ребер
			EntityCollectionFillet.Add(EntityCollectionPart.GetByIndex(0));
			EntityCollectionFillet.Add(EntityCollectionPart.GetByIndex(1));
			EntityCollectionFillet.Add(EntityCollectionPart.GetByIndex(2));
			EntityCollectionFillet.Add(EntityCollectionPart.GetByIndex(3));
			EntityCollectionFillet.Add(EntityCollectionPart.GetByIndex(4));
			EntityCollectionFillet.Add(EntityCollectionPart.GetByIndex(6));
			fillet.SetAdvancedColor(_model.Color, _ambient, _diffuse, _specularity, _shininess,
				_transparency, _emission);
			fillet.Create();
		}

		/// <summary>
		/// Разрез детали
		/// </summary>
		/// <param name="start">Точка начала</param>
		/// <param name="angle">Угол разреза</param>
		private void Cut(int start, double angle)
		{
			ksEntity sketch;
			ksSketchDefinition sketchDef;

			CreateSketch(out sketch, out sketchDef, start);
			var editSketch = (ksDocument2D)sketchDef.BeginEdit();

			// Расстояние от центра до точки
			var distance = 300;

			// Координаты X, Y и угол поворота
			double x1 = 0;
			double y1 = 0;
			double angleRad = 0;

			// Углы в радианы
			angleRad = angle * (Math.PI / 180);

			y1 = distance * Math.Cos(angleRad);
			x1 = distance * Math.Sin(angleRad);

			editSketch.ksLineSeg(0, 0, 0, distance, 1);
			editSketch.ksLineSeg(0, 0, x1, y1, 1);
			editSketch.ksArcByAngle(0, 0, distance, 90, 90 - angle, -1, 1);

			sketchDef.EndEdit();

			// Выдавить
			ExtrudeSketch(sketch, -50);
		}
    }
}