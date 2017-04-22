/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 26.09.2016
 * Time: 12:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;

namespace trade
{
	/// <summary>
	/// Description of FormReportStock.
	/// </summary>
	public partial class FormReportStock : Form
	{
		
		ListQReportStruct list_qr;
		
		public FormReportStock(ListQReportStruct list_qr)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.list_qr=list_qr;
			
			foreach (Storage storage in DB.GetAll<Storage>())
				comboBox1.Items.Add(storage.Title);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			DataTable dt=new DataTable();
			dt.Columns.Add("Id");
			dt.Columns.Add("Дата");
			dt.Columns.Add("Товар");
			dt.Columns.Add("Остаток");
			dt.Columns.Add("Склад");
			
			dt.PrimaryKey=new DataColumn[1]{dt.Columns[2]};
			
		//	RowQuantityReportStruct[] arr_qr=this.list_qr.GetAll();
		//	foreach(RowQuantityReportStruct qr in arr_qr) {
		Storage storage=DB.GetUnitByTitle<Storage>(comboBox1.Text);
		List<RowQuantityReportStruct> list_rowq;
		if (storage==null) 
			list_rowq=DB.GetAll<RowQuantityReportStruct>();
		else list_rowq=DB.GetAllRowQRepByStorage(storage);
		
		foreach(RowQuantityReportStruct qr in list_rowq) {
				if (qr.date.Date<=dateTimePicker1.Value.Date)	{
				
				DataRow dr=dt.Rows.Find(qr.product.Title);
					if (dr==null) {
					if (qr.storage!=null)
					dt.Rows.Add(qr.id, qr.date, qr.product.Title, qr.stock_quantity, qr.storage.Title);
					else 
					dt.Rows.Add(qr.id, qr.date, qr.product.Title, qr.stock_quantity);	
				}else{
				//	MessageBox.Show(qr.id+" "+qr.product.Title+" "+qr.date.ToString()+" "+qr.stock_quantity+"/"+DateTime.Parse(dr[1].ToString()));
					//if(qr.date>DateTime.Parse(dr[0].ToString())) {
					if(qr.id>int.Parse(dr[0].ToString())) {	
						dr[3]=qr.stock_quantity;
						dr[1]=qr.date;
						dr[0]=qr.id;
					}
				}
				
				}
			}
			
			dataGridView1.DataSource=dt;
			dataGridView1.Columns[0].Visible=false;
			dataGridView1.Columns[1].Visible=false;
			
			dataGridView1.Sort(dataGridView1.Columns[1],ListSortDirection.Ascending) ;
		}
	}
}
