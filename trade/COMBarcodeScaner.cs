using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace trade.Barcode
{
    /// <summary>
    /// Класс подключения сканера штрихкода по интерфейсу RS232
    /// </summary>
    public class COMBarcodeScaner : BarcodeBase, IBarcodeScaner
    {
        protected SerialPort port;
        /// <summary>
        /// Коструктор
        /// Открывает COM1
        /// </summary>
        public COMBarcodeScaner()
        {
            port = new SerialPort("COM1");
            Initialize();
        }

        /// <summary>
        /// Коструктор
        /// </summary>
        /// <param name="portName">Имя порта</param>
        public COMBarcodeScaner(string portName)
        {
            port = new SerialPort(portName);
            Initialize();
        }

        /// <summary>
        /// Подготовка параметров
        /// </summary>
        protected void Initialize()
        {
            suffix = new int[] { 13, 10 };
        }

        /// <summary>
        /// Подключение к источнику данных
        /// </summary>
        /// <returns>True в случае успеха</returns>
        public new bool Connect()
        {
            // Соединение
            try
            {
                port.Open();
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                connect = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошбика подключения сканера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect = false;
            }
            return connect;
        }


        /// <summary>
        /// Отключение от источника данных
        /// </summary>
        /// <returns>True в случае успеха</returns>
        public new bool Disconnect()
        {
            // Отсоединение
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                connect = false;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошбика подключения сканера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (port.IsOpen) connect = true;
                else connect = false;
                return false;
            }
        }

        /// <summary>
        /// Обработка поступающих данных
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        protected void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!connect) return;
            string code = port.ReadExisting();
            foreach (char data in code.ToCharArray())
                Read((int)data);
        }
    }
}
