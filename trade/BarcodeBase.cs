using System;



namespace trade.Barcode
{
    #region delegate BarcodeHandler
    /// <summary>
    /// Обработчик события получения штрих кода
    /// </summary>
    /// <param name="barcode">Штрих код</param>
    public delegate void BarcodeHandler(string barcode);
    #endregion

    // Обработка данных от сканера
public delegate void ReadBarcode(string code);
    
    #region IBarcodeScaner
    /// <summary>
    /// Интерфейс устройства
    /// </summary>
    public interface IBarcodeScaner
    {
        bool Connect();
        bool Disconnect();
        event BarcodeHandler GetBarcode;
    }
    #endregion

    #region BarcodeReadStatus
    /// <summary>
    /// Набор статусов поиска кода
    /// </summary>
    public enum BarcodeReadStatus { Wait, ReadPrefix, ReadBarcode, ReadSuffix };
    #endregion

    #region BarcodeScaner
    /// <summary>
    /// Базовый класс для сканеров
    /// </summary>
    public abstract class BarcodeBase
    {
        protected const int MAX_LENGHT  = 13;
        protected const int EAN8        = 8;
        protected const int EAN13       = 13;
        protected int[] prefix;
        protected int prefixIndex;
        protected int[] suffix;
        protected int suffixIndex;
        protected string barcode;
        protected bool connect;
        protected BarcodeReadStatus status;
        public event BarcodeHandler GetBarcode;

        public BarcodeBase()
        {
            prefix = null;
            suffix = null;
            connect = false;
            reset();
        }

        // включить
        public bool Connect()
        {
            connect = true;
            return true;
        }

        // выключить
        public bool Disconnect()
        {
            connect = false;
            return true;
        }

        //// префикс
        public int[] Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        // постфикс
        public int[] Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        // сбросить настройки
        protected void reset()
        {
            prefixIndex = 0;
            suffixIndex = 0;
            barcode = "";
            status = BarcodeReadStatus.Wait;
        }

        /// <summary>
        /// Посимвольный анализ
        /// Поиск сочетаний суффикса и префикса, передача полученного кода
        /// </summary>
        /// <param name="data">Код символа</param>
        protected void Read(Int32 data)
        {
            if (!connect)
            {
                reset();
                return;
            }
            switch (status)
            {
                case BarcodeReadStatus.Wait:
                    if (prefix == null) status = BarcodeReadStatus.ReadBarcode;
                    else status = BarcodeReadStatus.ReadPrefix;
                    Read(data);
                    break;
                case BarcodeReadStatus.ReadPrefix:
                    if (prefix == null)
                    {
                        status = BarcodeReadStatus.ReadBarcode;
                        Read(data);
                        break;
                    }
                    else if (prefix[prefixIndex] == data)
                    {
                        prefixIndex++;
                        if (prefixIndex == prefix.Length)
                            status = BarcodeReadStatus.ReadBarcode;
                    }
                    else reset();
                    break;
                case BarcodeReadStatus.ReadBarcode:
                    if (suffix[suffixIndex] == data)
                    {
                        status = BarcodeReadStatus.ReadSuffix;
                        Read(data);
                    }
                    else if (!ReadBarcode(data)) reset();
                    break;
                case BarcodeReadStatus.ReadSuffix:
                    if (suffix[suffixIndex] == data)
                    {
                        if (suffixIndex == suffix.Length - 1)
                        {
                            SendBarcode();
                            reset();
                        }
                        else
                            suffixIndex++;
                    }
                    else
                        reset();
                    break;
            }
        }

        /// <summary>
        /// Обработка непосредственно штрих-кода
        /// Сюда проверки писать
        /// </summary>
        /// <param name="data">Байт информации</param>
        /// <returns>True в случае успеха</returns>
        protected bool ReadBarcode(int data)
        {
            //проверка кода символа, только цифры 48-57
            if (data < 48 || data > 57)
                return false;
            // проверка длинны, до 13 символов 
            else if (barcode.Length + 1 > 13)
                return false;
            else
            {
                barcode += (char)data;
                return true;
            }
        }

        /// <summary>
        /// Отправка штрих-кода
        /// </summary>
        protected void SendBarcode()
        {
            if(GetBarcode == null) return;
            int codeLength = barcode.Length;
            switch (codeLength)
            {
                case EAN8:
                    GetBarcode(barcode);
                    break;
                case EAN13:
                    GetBarcode(barcode);
                    break;
                default:
                    break;
            }

        }
    }
}

    #endregion