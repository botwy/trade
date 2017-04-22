/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 07.09.2016
 * Time: 14:11
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
	/// Description of Form2.
	/// </summary>
	public partial class FormProducts : Form
	{
	//	ListUnits list_prod;
	//	Product[] arr_prod;
		TradeApp app;
		
		public FormProducts(TradeApp app, ListUnits list_prods)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		//	this.list_prod=list_prods;
			LoadProducts();
			
			this.app=app;
			if (this.app!=null) {
				app.CreatingProduct += new ProductEventHandler(formProducts_CreatingProduct);
			    app.ChangingAnyProducts += new EventHandler(formProducts_ChangingAnyProducts);
			    app.ChangingOneProduct += new ProductEventHandler(formProducts_ChangingOneProduct);
			}
		}
		
		void CreateDtHeader(DataTable dt) {
			dt.Columns.Add("Id товара");
			dt.Columns.Add("Наименование товара");
			dt.Columns.Add("Цена закупки");
			dt.Columns.Add("Штрихкод");
			foreach (Storage st in DB.GetAll<Storage>())
				dt.Columns.Add(st.Title);
		}
		
		
		void formProducts_CreatingProduct(Product prod) {
			//dataGridView1.Rows.Add(prod.Title,prod.Price_buy,prod.Quantity,prod.Barcode);
			LoadProducts();
			if (dataGridView1.RowCount>0)
			dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
		}
	
	void formProducts_ChangingAnyProducts() {
			//dataGridView1.Rows.Add(prod.Title,prod.Price_buy,prod.Quantity,prod.Barcode);
		
			LoadProducts();
			if (dataGridView1.RowCount>0)
			dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
		}
		
void formProducts_ChangingOneProduct(Product ch_prod) {
		
			DataTable dt=new DataTable();
			CreateDtHeader(dt);
			
			List<Product> list_prod=DB.GetAll<Product>();
		  int index=list_prod.Count-1;
			List<Storage> list=DB.GetAll<Storage>();
				for (int i=0; i<list_prod.Count; i++) {			
				Product prod=list_prod[i];
				if (prod.Id==ch_prod.Id) index=i;
				//dt.Rows.Add(prod.Id,prod.Title,prod.Price_buy,prod.Quantity,prod.Barcode);
		
				object[] data_row=new object[4+list.Count];
				data_row[0]=prod.Id;
				data_row[1]=prod.Title;
				data_row[2]=prod.Price_buy;
				data_row[3]=prod.Barcode;
				int n=4;
				foreach (Storage st in list) {
					data_row[n]=DB.GetProdStockAtStorage(prod,st);
					n++;
				}
				dt.Rows.Add(data_row);
		  
		  }
			
			dataGridView1.DataSource=dt;
			if (dataGridView1.RowCount>0)
			dataGridView1.CurrentCell=dataGridView1.Rows[index].Cells[1];
		}		
		                     
		
		void LoadProducts() {
			
			DataTable dt=new DataTable();
			CreateDtHeader(dt);
			
			List<Storage> list=DB.GetAll<Storage>();
			
			foreach (Product prod in DB.GetAll<Product>()) {
				
				object[] data_row=new object[4+list.Count];
				data_row[0]=prod.Id;
				data_row[1]=prod.Title;
				data_row[2]=prod.Price_buy;
				data_row[3]=prod.Barcode;
				int i=4;
				foreach (Storage st in list) {
					data_row[i]=DB.GetProdStockAtStorage(prod,st);
					i++;
				}
				dt.Rows.Add(data_row);
				
			
			}
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
			
		Product prod=DB.GetUnitById<Product>(id.ToString());
		if (prod!=null) {
			FormOneProduct f = new FormOneProduct(this.app, prod);
			f.MdiParent=this.MdiParent;
			f.Show();
		}
			   }
		}
			
void form_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)

      {
		if (this.app!=null) {
				app.CreatingProduct -= new ProductEventHandler(formProducts_CreatingProduct);
			    app.ChangingAnyProducts -= new EventHandler(formProducts_ChangingAnyProducts);
			    app.ChangingOneProduct -= new ProductEventHandler(formProducts_ChangingOneProduct);
			}
			
		}	
			
	}
}
