using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace trade.Barcode
{
    /// <summary>
    /// ����� ����������� ������� ��������� �� ���������� RS232
    /// </summary>
    public class COMBarcodeScaner : BarcodeBase, IBarcodeScaner
    {
        protected SerialPort port;
        /// <summary>
        /// ����������
        /// ��������� COM1
        /// </summary>
        public COMBarcodeScaner()
        {
            port = new SerialPort("COM1");
            Initialize();
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="portName">��� �����</param>
        public COMBarcodeScaner(string portName)
        {
            port = new SerialPort(portName);
            Initialize();
        }

        /// <summary>
        /// ���������� ����������
        /// </summary>
        protected void Initialize()
        {
            suffix = new int[] { 13, 10 };
        }

        /// <summary>
        /// ����������� � ��������� ������
        /// </summary>
        /// <returns>True � ������ ������</returns>
        public new bool Connect()
        {
            // ����������
            try
            {
                port.Open();
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                connect = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "������ ����������� �������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connect = false;
            }
            return connect;
        }


        /// <summary>
        /// ���������� �� ��������� ������
        /// </summary>
        /// <returns>True � ������ ������</returns>
        public new bool Disconnect()
        {
            // ������������
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                connect = false;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "������ ����������� �������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (port.IsOpen) connect = true;
                else connect = false;
                return false;
            }
        }

        /// <summary>
        /// ��������� ����������� ������
        /// </summary>
        /// <param name="sender">�����������</param>
        /// <param name="e">��������� �������</param>
        protected void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!connect) return;
            string code = port.ReadExisting();
            foreach (char data in code.ToCharArray())
                Read((int)data);
        }
    }
}
