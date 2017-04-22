/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 17.10.2016
 * Time: 13:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using trade.Barcode;

namespace trade
{
	/// <summary>
	/// Description of FormInputBarcode.
	/// </summary>
	public partial class FormInputBarcode : Form
	{
		 COMBarcodeScaner scaner;
		 GetDataFromOtherForm sender;
	//	 string barcode;
		public FormInputBarcode(GetDataFromOtherForm sender)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			scaner=new COMBarcodeScaner(Config.barcode_port);
			scaner.Connect();
			scaner.GetBarcode += new BarcodeHandler(com_scaner_ReceiveBarcode);
		
		this.sender=sender;	
		}

void SetDataInvoke(string code) {
	if (this.InvokeRequired) {
		ReadBarcode d= new ReadBarcode(SetDataInvoke);
		this.Invoke(d,code);
	}else{
	//MessageBox.Show(barcode);
    this.textBox1.Text = code;
	//Form1 main=this.Owner as Form1;
	//if (main!=null) main.curr_barcode=code;
	this.sender.Invoke(code);
	
	}	
		}
		
void DoCloseInvoke()
{
  // InvokeRequired required compares the thread ID of the
  // calling thread to the thread ID of the creating thread.
  // If these threads are different, it returns true.
  if (this.InvokeRequired)
  { 
  // DoCloseCallback d = new DoCloseCallback(DoClose);
   // this.Invoke(d);
  this.BeginInvoke(new MethodInvoker(()=> this.Close()));
  }
  else
  {
  	this.Close();
  }
}		
		
public void com_scaner_ReceiveBarcode(string code) {

	SetDataInvoke(code);
	DoCloseInvoke();
}

void FormInputBarcodeFormClosing(object sender, System.ComponentModel.CancelEventArgs e)

      {
	if (scaner!=null) {
		scaner.GetBarcode -= new BarcodeHandler(com_scaner_ReceiveBarcode);
		scaner.Disconnect();
		scaner=null;
	}
		}

	}
}
