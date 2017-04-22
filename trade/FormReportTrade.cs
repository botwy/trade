/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 17.09.2016
 * Time: 18:32
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
	/// Description of FormReportTrade.
	/// </summary>
	public partial class FormReportTrade : Form
	{
		ListTradeOperation list_to;
		public FormReportTrade(ListTradeOperation list_to)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.list_to=list_to;
			
			foreach (Storage storage in DB.GetAll<Storage>())
				comboBox1.Items.Add(storage.Title);
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			DataTable dt=new DataTable();
			dt.Columns.Add("Id Накладной");
			dt.Columns.Add("Товар");
			dt.Columns.Add("Id товара");
			dt.Columns.Add("Количество продано");
			dt.Columns.Add("Сумма проданного");
			dt.Columns.Add("Прибыль");
			dt.Columns.Add("Контрагент");
			dt.Columns.Add("Склад");
			
			dt.PrimaryKey=new DataColumn[1]{dt.Columns[2]};
			
			Storage storage = DB.GetUnitByTitle<Storage>(comboBox1.Text);
			List<TradeOperation> list_tradeo;
			if (storage==null)
				list_tradeo=DB.GetAll<TradeOperation>();
			else
				list_tradeo=DB.GetAllTradeOperationByStorage(storage);
			//TradeOperation[] arr_to=list_to.GetAll();
			//foreach (TradeOperation to in arr_to) {
			foreach (TradeOperation to in list_tradeo) {
				if ((to.Date.Date>=dateTimePicker1.Value.Date)
				    &&(to.Date.Date<=dateTimePicker2.Value.Date)) {
					
					DataRow dr=dt.Rows.Find(to.Product.Id);
					if (dr==null) {
						if (to.Storage!=null)
					dt.Rows.Add(to.Doc_id
							,to.Product.Title
						        ,to.Product.Id    
					            ,to.Quantity
					            ,to.Sum
					            ,to.Profit
					           ,to.Partner.Title
					          ,to.Storage.Title);
						else
							dt.Rows.Add(to.Doc_id
							,to.Product.Title
						        ,to.Product.Id    
					            ,to.Quantity
					            ,to.Sum
					            ,to.Profit
					           ,to.Partner.Title);
					}else{
						dr[3]=int.Parse(dr[3].ToString())+to.Quantity;
						dr[4]=float.Parse(dr[4].ToString())+to.Sum;
						dr[5]=float.Parse(dr[5].ToString())+to.Profit;
					}
				}
				
			}
			dataGridView1.DataSource=dt;
		}
	}
}
