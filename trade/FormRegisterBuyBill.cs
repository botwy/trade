/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 09.09.2016
 * Time: 9:30
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
	/// Description of FormRegisterBuyBill.
	/// </summary>
	public partial class FormRegisterBuyBill : Form
	{
		//ListBuyBills list_bb;
		List<BuyBill> list_bb;
		//BuyBill[] arr_bb;
		TradeApp app;
		public FormRegisterBuyBill(TradeApp app)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//this.list_bb=DB.GetAll<BuyBill>();
			this.list_bb=DB.GetAll<BuyBill>();
			
			
			//this.list_bb=new ListBuyBills();
			//foreach (BuyBill b in lb) this.list_bb.Add(b);
			//this.list_bb=list_bb;
			LoadBuyBills();
			
		this.app=app;
			if (this.app!=null) {
		app.ChangingApp +=new EventHandler(app_ChangingApp);
			}
		}
		
		void app_ChangingApp() {
			this.list_bb=DB.GetAll<BuyBill>();
			LoadBuyBills ();
		}
		
		
		void LoadBuyBills () {
			DataTable dt = new DataTable();
			dt.Columns.Add("ID накладной");
			dt.Columns.Add("Номер накладной");
			dt.Columns.Add("Дата накладной");
			dt.Columns.Add("Итого кол-во");
			dt.Columns.Add("Сумма");
			dt.Columns.Add("Поставщик");
			
		//	this.arr_bb=this.list_bb.GetAll();
			
		//	foreach (BuyBill bb in this.arr_bb) {
			foreach (BuyBill bb in this.list_bb) {	
		//foreach (BuyBill bb in DB.GetAll<BuyBill>()) {	
				dt.Rows.Add(bb.Id,bb.Number_instance,bb.Date,bb.Total_quantity,bb.Total_sum,bb.Provider.Title);
			}
			
		dataGridView1.DataSource=dt;
		if (dataGridView1.RowCount>0)
		dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
		//dataGridView1.Columns[0].Visible=false;
		}
		
		
		void DataGridView1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			object obj=dataGridView1[0,e.RowIndex].Value;
			//label1.Text=obj.ToString();
			if (obj.ToString()!="") {
			//int number_bill=int.Parse(obj.ToString());	
			//int id=int.Parse(obj.ToString());	
			string id=obj.ToString();	
			//BuyBill bb=this.list_bb.Get(number_bill-1);
			//BuyBill bb=this.list_bb.GetById(id);
		
			//BuyBill bb=this.list_bb.Find(x=>x.Id==id);
			BuyBill bb=DB.GetDocById<BuyBill>(id);
			if (bb==null) {
				MessageBox.Show("Накладная не найдена в базе данных");
				return;
			}
			//MessageBox.Show(bb.Storage.Title);
			Form1 secondForm = new Form1(bb);
			secondForm.MdiParent=this.MdiParent;
			secondForm.Show();
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
