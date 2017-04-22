/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 28.10.2016
 * Time: 11:20
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
	/// Description of FormStorages.
	/// </summary>
	public partial class FormStorages : Form
	{
	
		TradeApp app;
		
		public FormStorages(TradeApp app)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
	
			LoadItems();
			
			this.app=app;
			if (this.app!=null) {
				app.CreatingStorage += new StorageEventHandler(form_Creating);
			    app.ChangingAnyStorages += new EventHandler(form_ChangingAny);
			    app.ChangingOneStorage += new StorageEventHandler(form_ChangingOne);
			}
		}
		
		void CreateDtHeader(DataTable dt) {
			dt.Columns.Add("Id склада");
			dt.Columns.Add("Наименование склада");
			
		}
		
		
		void form_Creating(Storage storage) {
		
			LoadItems();
			if (dataGridView1.RowCount>0)
			dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
		}
	
	void form_ChangingAny() {
		
			LoadItems();
			if (dataGridView1.RowCount>0)
			dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
		}
		
void form_ChangingOne(Storage ch_storage) {
		
			DataTable dt=new DataTable();
			CreateDtHeader(dt);
			
			List<Storage> list=DB.GetAll<Storage>();
		  int index=list.Count-1;
		
				for (int i=0; i<list.Count; i++) {			
				Storage storage=list[i];
				if (storage.Id==ch_storage.Id) index=i;
				dt.Rows.Add(storage.Id,storage.Title);
			}
			
			dataGridView1.DataSource=dt;
			if (dataGridView1.RowCount>0)
			dataGridView1.CurrentCell=dataGridView1.Rows[index].Cells[1];
		}		
		                     
		
		void LoadItems() {
			
			DataTable dt=new DataTable();
			CreateDtHeader(dt);
			
		
			foreach (Storage item in DB.GetAll<Storage>()) 

				dt.Rows.Add(item.Id,item.Title);
			
			
			dataGridView1.DataSource=dt;

			
		}
		
			void DataGridView1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
			object obj=dataGridView1[0,e.RowIndex].Value;
			//label1.Text=obj.ToString();
			if (obj.ToString()!="") {
			//int number=int.Parse(obj.ToString());		
			int id=int.Parse(obj.ToString());	
		//	SellBill sb=this.list_sb.Get(number_bill-1);
			
		Storage storage=DB.GetUnitById<Storage>(id.ToString());
		if (storage!=null) {
			FormOneStorage f = new FormOneStorage(this.app, storage);
			f.MdiParent=this.MdiParent;
			f.Show();
		}
			   }
		}
			
void form_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)

      {
		if (this.app!=null) {
				app.CreatingStorage -= new StorageEventHandler(form_Creating);
			    app.ChangingAnyStorages -= new EventHandler(form_ChangingAny);
			    app.ChangingOneStorage -= new StorageEventHandler(form_ChangingOne);
			}
			
		}	
	}
}
