/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 21.10.2016
 * Time: 16:54
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
	/// Description of FormPartners.
	/// </summary>
	public partial class FormPartners : Form
	{
		TradeApp app;
		public FormPartners(TradeApp app)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			LoadPartners();
				this.app=app;
			if (this.app!=null) {
				
			    app.ChangingAnyPartners += new EventHandler(form_ChangingAny);
		        app.ChangingOnePartner += new PartnerEventHandler(form_ChangingOne);
				}
		}
		
		
		void CreateDtHeader(DataTable dt) {
		dt.Columns.Add("Id контрагента");
			dt.Columns.Add("Наименование контрагента");
			dt.Columns.Add("Номер телефона");
			dt.Columns.Add("E-mail");	
		}
				
		void form_ChangingAny() {
			//dataGridView1.Rows.Add(prod.Title,prod.Price_buy,prod.Quantity,prod.Barcode);
			LoadPartners();
		//	if (dataGridView1.RowCount!=null)
		//	dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
		}	
void form_ChangingOne(Partner ch_item) {
		
			DataTable dt=new DataTable();
			CreateDtHeader(dt);
			
			List<Partner> list=DB.GetAll<Partner>();
		  int index=list.Count-1;
		
				for (int i=0; i<list.Count; i++) {			
				Partner item=list[i];
				if (item.Id==ch_item.Id) index=i;
				dt.Rows.Add(item.Id,item.Title,item.Phone,item.E_mail);
			}
			
			dataGridView1.DataSource=dt;
			if (dataGridView1.RowCount>0)
			dataGridView1.CurrentCell=dataGridView1.Rows[index].Cells[1];
		}	
		
		
		void LoadPartners() {

			
			DataTable dt=new DataTable();
			CreateDtHeader(dt);
			
			
			
			foreach (Partner item in DB.GetAll<Partner>()) {

				dt.Rows.Add(item.Id,item.Title,item.Phone,item.E_mail);
				
			}
			
			dataGridView1.DataSource=dt;
if (dataGridView1.RowCount>0)			
dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[1];
			
		}
		
	void DataGridView1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
			object obj=dataGridView1[0,e.RowIndex].Value;
			//label1.Text=obj.ToString();
			if (obj.ToString()!="") {
			//int number=int.Parse(obj.ToString());		
			int id=int.Parse(obj.ToString());	
		//	SellBill sb=this.list_sb.Get(number_bill-1);
			
		Partner pa=DB.GetUnitById<Partner>(id.ToString());
		if (pa!=null) {
			FormOnePartner f = new FormOnePartner(this.app, pa);
			f.MdiParent=this.MdiParent;
			f.Show();
		}
			   }
		}
	
void form_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)

      {
		if (this.app!=null) {
				 app.ChangingAnyPartners += new EventHandler(form_ChangingAny);
		        app.ChangingOnePartner += new PartnerEventHandler(form_ChangingOne);
			}
			
		}	
		
		
	}
}
