using System;



namespace trade.Barcode
{
    #region delegate BarcodeHandler
    /// <summary>
    /// ���������� ������� ��������� ����� ����
    /// </summary>
    /// <param name="barcode">����� ���</param>
    public delegate void BarcodeHandler(string barcode);
    #endregion

    // ��������� ������ �� �������
public delegate void ReadBarcode(string code);
    
    #region IBarcodeScaner
    /// <summary>
    /// ��������� ����������
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
    /// ����� �������� ������ ����
    /// </summary>
    public enum BarcodeReadStatus { Wait, ReadPrefix, ReadBarcode, ReadSuffix };
    #endregion

    #region BarcodeScaner
    /// <summary>
    /// ������� ����� ��� ��������
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

        // ��������
        public bool Connect()
        {
            connect = true;
            return true;
        }

        // ���������
        public bool Disconnect()
        {
            connect = false;
            return true;
        }

        //// �������
        public int[] Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        // ��������
        public int[] Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        // �������� ���������
        protected void reset()
        {
            prefixIndex = 0;
            suffixIndex = 0;
            barcode = "";
            status = BarcodeReadStatus.Wait;
        }

        /// <summary>
        /// ������������ ������
        /// ����� ��������� �������� � ��������, �������� ����������� ����
        /// </summary>
        /// <param name="data">��� �������</param>
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
        /// ��������� ��������������� �����-����
        /// ���� �������� ������
        /// </summary>
        /// <param name="data">���� ����������</param>
        /// <returns>True � ������ ������</returns>
        protected bool ReadBarcode(int data)
        {
            //�������� ���� �������, ������ ����� 48-57
            if (data < 48 || data > 57)
                return false;
            // �������� ������, �� 13 �������� 
            else if (barcode.Length + 1 > 13)
                return false;
            else
            {
                barcode += (char)data;
                return true;
            }
        }

        /// <summary>
        /// �������� �����-����
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