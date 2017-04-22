/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 09.09.2016
 * Time: 18:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of FormRegisterSellBill.
	/// </summary>
	public partial class FormRegisterSellBill : Form
	{
	//	ListSellBills list_sb;
	//	SellBill[] arr_sb;
		List<SellBill> list_sb;
		TradeApp app;
		public FormRegisterSellBill(TradeApp app)
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		//	this.list_sb=list_sb;
		
		this.list_sb=DB.GetAll<SellBill>();
			LoadSellBills();
			
			this.app=app;
			if (this.app!=null) {
		app.ChangingApp +=new EventHandler(app_ChangingApp);
			}
		}
		
		void app_ChangingApp() {
			this.list_sb=DB.GetAll<SellBill>();
			LoadSellBills ();
		}
		
		void LoadSellBills () {
			DataTable dt = new DataTable();
			dt.Columns.Add("ID накладной");
			dt.Columns.Add("Номер накладной");
			dt.Columns.Add("Дата накладной");
			dt.Columns.Add("Итого кол-во");
			dt.Columns.Add("Сумма");
			dt.Columns.Add("Покупатель");
			
		//	this.arr_sb=this.list_sb.GetAll();
			
		//	foreach (SellBill sb in this.arr_sb) {
		//	foreach (SellBill sb in DB.GetAll<SellBill>()) {
	foreach (SellBill sb in this.list_sb) {		
			
				dt.Rows.Add(sb.Id,sb.Number_instance,sb.Date,sb.Total_quantity,sb.Total_sum,sb.Consumer.Title);
			}
		dataGridView1.DataSource=dt;
		//MessageBox.Show(dataGridView1.RowCount.ToString());
		if (dataGridView1.RowCount>0)
	dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
		
	
		}
		
		
		void DataGridView1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
			object obj=dataGridView1[0,e.RowIndex].Value;
			//label1.Text=obj.ToString();
			if (obj.ToString()!="") {
			//int number=int.Parse(obj.ToString());		
			//int id=int.Parse(obj.ToString());	
			string id=obj.ToString();
		//	SellBill sb=this.list_sb.Get(number_bill-1);
			
			//SellBill sb=this.list_sb.Find(x=>x.Id==id);
			SellBill sb=DB.GetDocById<SellBill>(id);
			if (sb==null) {
				MessageBox.Show("Накладная не найдена в базе данных");
				return;
			}
			
			FormSell sellForm = new FormSell(sb);
			sellForm.MdiParent=this.MdiParent;
			sellForm.Show();
			   }
		}
		
		void form_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)

      {
		if (this.app!=null) {
			app.ChangingApp -=new EventHandler(app_ChangingApp);
			}
			
		}	
		
		
	}
}
