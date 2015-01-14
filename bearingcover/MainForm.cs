using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace bearingCover
{
    using System.Drawing;
    using Kompas6API5;
    using Kompas6Constants3D;

    public partial class MainForm : Form
    {
        /// <summary>
        /// Коннектор API КОМПАС-3D
        /// </summary>
        private KompasConnector _connector;

        /// <summary>
        /// Модель параметров крышки подшипника
        /// </summary>
        private BearingCoverModel _paramsModel;

        /// <summary>
        /// Отрисовщик модели
        /// </summary>
        private BearingCoverDrawer _drawer;

		/// <summary>
		/// Стандартный цвет детали
		/// </summary>
		private readonly Color _defaultColorRGB = Color.FromArgb(144, 144, 144);

		/// <summary>
		/// Цвет детали
		/// </summary>
		private int _partColor;

        public MainForm()
        {
            InitializeComponent();
            _connector = new KompasConnector();
            _paramsModel = null;
			_partColor = Color.FromArgb(_defaultColorRGB.B, _defaultColorRGB.G,
				_defaultColorRGB.R).ToArgb();
			colorPanel.BackColor = _defaultColorRGB;
        }

		/// <summary>
		/// Получить параметры модели
		/// </summary>
		/// <returns></returns>
        private BearingCoverModel GetCurrentParams()
        {
            return new BearingCoverModel(int.Parse(holesNumber.Text),
				int.Parse(coverThickness.Text), int.Parse(frontProjection.Text),
				int.Parse(borderThickness.Text), int.Parse(rearProjection.Text),
				int.Parse(centralHoleDepth.Text), int.Parse(posteriorWallThickness.Text),
				int.Parse(outDiameterCentralHole.Text), int.Parse(holesDistance.Text),
				int.Parse(inDiameterCentralHole.Text), int.Parse(bearingCoverDiameter.Text),
				int.Parse(holesDiameter.Text), int.Parse(distanceAroundHoles.Text),
				this._partColor, int.Parse(angleCut.Text));
        }

        /// <summary>
        /// Выход
        /// </summary>
        /// <param name="sender">Объект - "отправитель" сообщения</param>
        /// <param name="e">Параметрв события</param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Построение модели в КОМПАС
        /// </summary>
        /// <param name="sender">Объект - "отправитель" сообщения</param>
        /// <param name="e">Параметрв события</param>
        private void buildButton_Click(object sender, EventArgs e)
        {
			if (!CheckForInt())
			{
				return;
			}

			// Получаем параметры модели
			var currentParams = GetCurrentParams();

			if (!currentParams.CheckH())
			{
				return;
			}

			if (!currentParams.CheckParams())
			{
				return;
			}

			// Получаем объект КОМПАС-3D
            var kompas = _connector.Instance;
            kompas.Visible = true;

            if (!_connector.JustCreated)
            {
                if (_paramsModel == currentParams)
                {
                    MessageBox.Show("Модель с такими параметрами уже построена!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_paramsModel != null)
                {
                    if (MessageBox.Show("Вы действительно хотите перестроить существующую модель?", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            // Получаем параметры модели
            _paramsModel = GetCurrentParams();

			// Начало отсчета
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			for (int count = 0; count < 1; count++)
			{
				// Создаем документ
				var doc = (ksDocument3D)kompas.ActiveDocument3D();
				if (doc == null || doc.reference == 0)
				{
					doc = (ksDocument3D)kompas.Document3D();
					doc.Create(false, true);

					doc.author = "";
					doc.comment = "Крышка подшипника";
					doc.UpdateDocumentParam();
				}

				// Удаляем все что в документе
				ksPart partTop = doc.GetPart((short)Part_Type.pTop_Part);
				EntityCollection entities = partTop.EntityCollection(0);

				// Первые 6 элементов - начало координат, плоскости и оси
				// Остальное удаляем
				var entitiesCount = entities.GetCount() - 1;
				for (int i = entitiesCount; i > 6; i--)
				{
					ksEntity entity = entities.GetByIndex(i);
					doc.DeleteObject(entity);
				}

				try
				{
					_drawer = new BearingCoverDrawer(kompas, doc, _paramsModel);
					_drawer.Draw();
				}
				catch (Exception ex)
				{
					MessageBox.Show("При отрисовке крышки подшипника произошла ошибка: " + ex.ToString());
				}
			}

			// Конец отсчета
			stopwatch.Stop();
			
			// Результат
			Console.WriteLine("Построение завершилось за {0} секунд",
				stopwatch.Elapsed.TotalSeconds);
        }

        /// <summary>
        /// Обработчик события "форма закрыта"
        /// </summary>
        /// <param name="sender">Объект - "отправитель" сообщения</param>
        /// <param name="e">Параметрв события</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _connector.QuitKompas();
        }

		/// <summary>
		/// Проверка на корректность измененного значения
		/// </summary>
		/// <param name="sender">Объект - "отправитель" сообщения</param>
		/// <param name="e">Параметрв события</param>
		private void CheckForInt(object sender, EventArgs e)
		{
			var box = sender as TextBox;
			int output;
			if (box != null)
			{
				// Не целое число или меньше 0
				if (!int.TryParse(box.Text, out output))
				{
					MessageBox.Show("Значением параметра должно быть положительное целое число",
						"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					box.Focus();
					box.SelectAll();
				}
			}
		}

		/// <summary>
		/// Проверка на корректность измененного значения
		/// </summary>
		private bool CheckForInt()
		{
			int output;
			if (!int.TryParse(holesNumber.Text, out output) ||
				!int.TryParse(coverThickness.Text, out output) ||
				!int.TryParse(frontProjection.Text, out output) ||
				!int.TryParse(borderThickness.Text, out output) ||
				!int.TryParse(rearProjection.Text, out output) ||
				!int.TryParse(centralHoleDepth.Text, out output) ||
				!int.TryParse(posteriorWallThickness.Text, out output) ||
				!int.TryParse(outDiameterCentralHole.Text, out output) ||
				!int.TryParse(holesDistance.Text, out output) ||
				!int.TryParse(inDiameterCentralHole.Text, out output) ||
				!int.TryParse(bearingCoverDiameter.Text, out output) ||
				!int.TryParse(holesDiameter.Text, out output) ||
				!int.TryParse(distanceAroundHoles.Text, out output) ||
				!int.TryParse(angleCut.Text, out output))
			{
				MessageBox.Show("Значением параметра должно быть положительное целое число",
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		/// <summary>
		/// Проверка изменения параметра
		/// </summary>
		/// <param name="sender">Объект - "отправитель" сообщения</param>
		/// <param name="e">Параметры события</param>
		private void ParamInputLeave(object sender, EventArgs e)
		{
			// Проверка изменения параметра
			CheckForInt(sender, e);

			// Получаем параметры модели
			var currentParams = GetCurrentParams();

			if (!currentParams.CheckParams())
			{
				var box = sender as TextBox;
				if (box != null)
				{
					box.Focus();
					box.SelectAll();
				}
			}
		}

		/// <summary>
		/// Изменение цвета детали
		/// </summary>
		/// <param name="sender">Объект - "отправитель" сообщения</param>
		/// <param name="e">Параметры события</param>
		private void partColor_Click(object sender, EventArgs e)
		{
			ColorDialog clrDialog = new ColorDialog();
			clrDialog.ShowDialog();
			_partColor = Color.FromArgb(clrDialog.Color.B, clrDialog.Color.G,
				clrDialog.Color.R).ToArgb();
			colorPanel.BackColor = clrDialog.Color;
		}
    }
}
