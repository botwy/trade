/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 22.10.2016
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
namespace trade
{
	/// <summary>
	/// Description of FormOneProduct.
	/// </summary>
	public partial class FormOneProduct : Form
	{
		TradeApp app;
		Product prod;
		public FormOneProduct(TradeApp app, Product prod)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.app=app;
			this.prod=prod;
			textBox1.Text=this.prod.Title;
			textBox2.Text=this.prod.Price_buy.ToString();
			textBox4.Text=this.prod.Quantity.ToString();
		//	label6.Text=this.prod.Price_buy.ToString();
			textBox3.Text=this.prod.Barcode;
			this.Text=this.prod.Title+"-Карточка товара";
			
			UpdateMarkupTypeList();
			
			foreach (MarkupType m_type in DB.GetAll<MarkupType>())
				comboBox1.Items.Add(m_type.Title);
		}
		
		void UpdateMarkupTypeList() {
			DataTable dt = new DataTable();
			dt.Columns.Add("X");
			dt.Columns.Add("Тип наценки");
			dt.Columns.Add("фиксир. цена");
			
			
			if (prod.List_markupType==null) return;
			
			foreach (KeyValuePair<MarkupType,float> keyValue in prod.List_markupType)
				dt.Rows.Add("x",keyValue.Key.Title,keyValue.Value.ToString());
			
			dataGridView1.DataSource=dt;
			dataGridView1.Columns[0].Width=20;
			dataGridView1.Columns[0].ReadOnly=true;
			dataGridView1.Columns[1].ReadOnly=true;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//int barcode_value;
			float price_buy_value;
			if (!Validator.TextBoxToFloat<Product>(textBox2,out price_buy_value))
			{
				textBox2.Text=DB.GetUnitById<Product>(this.prod.Id.ToString()).Price_buy.ToString();
				return;
			}
			
		float new_price_buy=price_buy_value;
		string new_barcode=textBox3.Text;
		
		prod.Price_buy=new_price_buy;
		prod.Barcode=new_barcode;
	//	float sum=new_price_buy;
//			DB.UpdateProdPriceBuy(new RowDocStruct(prod
//			                                       ,prod.Quantity
//			                                       ,new_price_buy
//			                                       ,sum));
		DB.UpdateUnit<Product>(this.prod);
		Product u_prod=DB.GetUnitById<Product>(prod.Id.ToString());
		label6.Text="Текущая цена закупки: "+u_prod.Price_buy.ToString();
		label9.Text="Текущий штрихкод: "+u_prod.Barcode;
		this.Text=u_prod.Title+"-Карточка товара";
		app.EventOneProductUpdate(u_prod);
			                                       
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			this.Text=this.prod.Title+"-Карточка товара *";
		}
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			this.Text=this.prod.Title+"-Карточка товара *";
		}
		
		
		
	
		
		void Button2Click(object sender, EventArgs e)
		{
			MarkupType m_type=DB.GetUnitByTitle<MarkupType>(comboBox1.Text);
			float percent=float.Parse(textBox5.Text);
			//MessageBox.Show(prod.List_markupType.ContainsKey(m_type).ToString());
			
			if (prod.List_markupType!=null) {
			foreach (KeyValuePair<MarkupType,float> keyValue in prod.List_markupType) {
				if (keyValue.Key.Id==m_type.Id) {
				MessageBox.Show("Фиксир. цена для такого типа наценки уже есть у этого товара");
                return;				
				}
			}
			}
			
			
			    prod.List_markupType.Add(m_type,percent);
			UpdateMarkupTypeList();
			this.Text=this.prod.Title+"-Карточка товара *";
		//	DB.UpdateUnit<Product>(this.prod);
			
			
		}
		
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			MarkupType cur_mtype=null;
			if ((e.ColumnIndex==0)&&(dataGridView1[e.ColumnIndex,e.RowIndex].Value.ToString()=="x")) {
				string mtype_name=(dataGridView1[1,e.RowIndex].Value).ToString();
				//MarkupType cur_mtype= DB.GetUnitByTitle<MarkupType>(mtype_name);
				
			//	if (cur_mtype!=null) {
					foreach (KeyValuePair<MarkupType, float> keyValue in prod.List_markupType) {
				if (keyValue.Key.Title==mtype_name) {
					cur_mtype=keyValue.Key;
					
				//	MessageBox.Show(cur_mtype.Title);
					
				}
				
				
					}
			
			if (cur_mtype!=null)
				this.prod.List_markupType.Remove(cur_mtype);
			
			
			//	}
			
					UpdateMarkupTypeList();
					this.Text=this.prod.Title+"-Карточка товара *";
			}
		}
		
		void DataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
	MarkupType cur_mtype=null;
		
	 if (e.ColumnIndex==2) {
//			
			object obj=dataGridView1[e.ColumnIndex,e.RowIndex].Value;
			object obj_mtype_name=dataGridView1[1,e.RowIndex].Value;
			//int new_quantity=(obj.ToString()!="")?int.Parse(obj.ToString()):0;
//			if (!Validator.DgvCell<SellBill>(obj.ToString(),out new_quantity)) {
//				UpdateTotalAndDataGridView();
//				return;
//			}
			
				float new_percent=float.Parse(obj.ToString());
				string mtype_name=obj_mtype_name.ToString();
		
	foreach (KeyValuePair<MarkupType, float> keyValue in prod.List_markupType) {
				if (keyValue.Key.Title==mtype_name) {
						cur_mtype=keyValue.Key;
						
			//		keyValue.Value=new_percent; //ReadOnly
           //	MessageBox.Show(cur_mtype.Title);
					}
				}
				
		if (cur_mtype!=null)
				prod.List_markupType[cur_mtype]=new_percent;
			UpdateMarkupTypeList();
		this.Text=this.prod.Title+"-Карточка товара *";
			
		}
	
	}	
		
		
	}
}
