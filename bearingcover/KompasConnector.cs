namespace bearingCover
{
    using System;
    using System.Runtime.InteropServices; // Для COMException
    using System.Windows.Forms;
    using Kompas6API5;

    /// <summary>
    /// Класс, используемый для взаимодействия с KOMPAS-3D
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Экземпляр объекта КОМПАС-3D
        /// </summary>
        private KompasObject _instance;

        /// <summary>
        /// Экземпляр объекта КОМПАС-3D - свойство
        /// </summary>
        public KompasObject Instance
        {
            get
            {
                if (_instance == null)
                {
                    JustCreated = true;
                    return (_instance = CreateKompasObject());
                }

                try
                {
                    var lookStyle = _instance.lookStyle;
                    JustCreated = false;
                    return _instance;
                }
                catch (COMException)    // Вылетает, если закрыли компас
                {
                    JustCreated = true;
                    return (_instance = CreateKompasObject());
                }
                catch (Exception ex)
                {
                    JustCreated = true;
                    MessageBox.Show(string.Format("Произошло исключение при попытке доступа к КОМПАС API:\n{0}", ex.Message),
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        /// <summary>
        /// Создает объект КОМПАС-3D
        /// </summary>
        /// <returns>Объект КОМПАС-3D</returns>
        private static KompasObject CreateKompasObject()
        {
            const string progID = "KOMPAS.Application.5";
            var type = Type.GetTypeFromProgID(progID);
            var ksObject = Activator.CreateInstance(type) as KompasObject;
            if (ksObject == null)
            {
                throw new Exception("Не удалось создать объект КОМПАС-3D");
            }
            return ksObject;
        }

        /// <summary>
        /// Флаг, указывающий на факт создания объекта КОМПАС-3D последним обращением к свойству Instance
        /// </summary>
        public bool JustCreated { get; set; }

        /// <summary>
        /// Завершить работу с КОМПАС-3D
        /// </summary>
        public void QuitKompas()
        {
            if (_instance == null)
            {
                return;
            }

            // Пытаемся завершить работу с КОМПАС-3D
            try
            {
                _instance.Quit();
            }
            catch
            {
                // Если произошла ошибка, ничего не делаем
                // Т.к. пользователь все равно решил завершить работу с КОМПАС-3D
            }

            _instance = null;
        }
    }

}
