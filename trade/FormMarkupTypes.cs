/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 24.11.2016
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace trade
{
	/// <summary>
	/// Description of FormMarkupTypes.
	/// </summary>
	public partial class FormMarkupTypes : Form
	{
		TradeApp app;
		public FormMarkupTypes(TradeApp app)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			LoadItems();
		}
		
		void CreateDtHeader(DataTable dt) {
			dt.Columns.Add("Id типа наценок");
			dt.Columns.Add("Наименование типа наценок");
			dt.Columns.Add("Базовая наценка (в %)");
			
		}
		
		void LoadItems() {
			
			DataTable dt=new DataTable();
			CreateDtHeader(dt);
			
		
			foreach (MarkupType item in DB.GetAll<MarkupType>()) 

				dt.Rows.Add(item.Id,item.Title,item.Basic_percent);
			
			
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
			
		MarkupType markupType=DB.GetUnitById<MarkupType>(id.ToString());
		if (markupType!=null) {
			FormOneMarkupType f = new FormOneMarkupType(this.app, markupType);
			f.MdiParent=this.MdiParent;
			f.Show();
		}
			   }
		}
	}
}
